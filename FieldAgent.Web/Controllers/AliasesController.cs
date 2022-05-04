using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FieldAgent.Web.Controllers
{
    [Route("api/agents/{agentId}/[controller]")]
    [ApiController]
    public class AliasesController : ControllerBase
    {
        private readonly IAliasRepository _aliasRepo;

        public AliasesController(IAliasRepository aliasRepo)
        {
            _aliasRepo = aliasRepo;
        }

        [HttpGet]
        [Route("/api/agents/{agentId}/aliases/{aliasId}", Name = "GetAlias")]
        public IActionResult GetAlias(int aliasId)
        {
            var result = _aliasRepo.Get(aliasId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost]
        //[Route("/api/agents/{agentId}/aliases")]
        public IActionResult InsertAlias(AliasModel aliasModel)
        {
            if (ModelState.IsValid)
            {
                Alias alias = new Alias
                {
                    AliasName = aliasModel.AliasName,
                    InterpolId = aliasModel.InterpolId,
                    Persona = aliasModel.Persona,
                    AgentId = aliasModel.AgentId
                };

                var result = _aliasRepo.Insert(alias);

                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetAlias), new { agentId = result.Data.AgentId, aliasId = result.Data.AliasId }, result.Data);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);

            }
        }

        [HttpDelete("{aliasId}")]
        public IActionResult DeleteAlias(int aliasId)
        {
            var findResult = _aliasRepo.Get(aliasId);
            if (!findResult.Success)
            {
                return NotFound(findResult.Message);
            }

            var result = _aliasRepo.Delete(aliasId);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut]
        [Route("/api/agents/{agentId}/aliases/")]    
        public IActionResult UpdateAlias(AliasModel aliasModel)
        {
            if (ModelState.IsValid && aliasModel.AliasId > 0)
            {
                Alias alias = new Alias
                {
                    AliasId = aliasModel.AliasId, //ID?
                    AliasName = aliasModel.AliasName,
                    InterpolId = aliasModel.InterpolId,
                    Persona = aliasModel.Persona,
                    AgentId = aliasModel.AgentId
                };

                var findResult = _aliasRepo.Get(alias.AliasId);
                if (!findResult.Success)
                {
                    return NotFound(findResult.Message);
                }

                var result = _aliasRepo.Update(alias);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                if (aliasModel.AliasId < 1)
                    ModelState.AddModelError("AliasId", "Invalid Alias ID");
                return BadRequest(ModelState);
            }
        }
    }
}
