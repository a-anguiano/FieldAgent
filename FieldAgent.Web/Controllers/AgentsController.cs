using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace FieldAgent.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentRepository _agentRepo;
        private readonly IMissionRepository _missionRepo;
        private readonly IAliasRepository _aliasRepo;

        public AgentsController(IAgentRepository agentRepo, IMissionRepository missionRepo, IAliasRepository aliasRepo)
        {
            _agentRepo = agentRepo;
            _missionRepo = missionRepo;
            _aliasRepo = aliasRepo;
        }

        [HttpGet]   //, Authorize
        [Route("/api/[controller]/{agentId}", Name = "GetAgent")]
        public IActionResult GetAgent(int agentId)
        {
            var result = _agentRepo.Get(agentId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);  
            }
        }

        [HttpPost]
        public IActionResult InsertAgent(AgentModel agentModel)
        {
            if (ModelState.IsValid)
            {
                Agent agent = new Agent
                {
                    FirstName = agentModel.FirstName,
                    LastName = agentModel.LastName,
                    DateOfBirth = agentModel.DateOfBirth,
                    Height = agentModel.Height
                };

                var result = _agentRepo.Insert(agent);

                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetAgent), new { agentId = result.Data.AgentId }, result.Data);
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

        [HttpDelete("{agentId}")]   //[HttpDelete("{agentId}"), Authorize]
        public IActionResult DeleteAgent(int agentId)
        {
            var findResult = _agentRepo.Get(agentId);
            if (!findResult.Success)
            {
                return NotFound();
            }

            var result = _agentRepo.Delete(agentId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }

        [HttpPut]   //[HttpPut, Authorize]  
        public IActionResult UpdateAgent(AgentModel agentModel)
        {
            if (ModelState.IsValid && agentModel.AgentId > 0)
            {
                Agent agent = new Agent
                {
                    AgentId = agentModel.AgentId,
                    FirstName = agentModel.FirstName,
                    LastName = agentModel.LastName,
                    DateOfBirth = agentModel.DateOfBirth,
                    Height = agentModel.Height
                };

                var findResult = _agentRepo.Get(agent.AgentId);
                if (!findResult.Success)
                {
                    return NotFound(findResult.Message);
                }

                var result = _agentRepo.Update(agent);
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
                if (agentModel.AgentId < 1)
                    ModelState.AddModelError("AgentId", "Invalid Agent ID");
                return BadRequest(ModelState);
            }
        }
 
        [HttpGet]
        [Route("/api/agents/{agentId}/missions", Name = "GetMissions")]    
        public IActionResult GetMissions(int agentId)
        {
            var result = _missionRepo.GetByAgent(agentId);
            if (result.Success)
            {
                return Ok(
                     result.Data.Select(
                        m => new MissionModel()
                        {
                        MissionId = m.MissionId,
                        CodeName = m.CodeName,
                        Notes = m.Notes,
                        StartDate = m.StartDate,
                        ProjectedEndDate = m.ProjectedEndDate,
                        ActualEndDate = m.ActualEndDate,
                        OperationalCost = m.OperationalCost,
                        AgencyId = m.AgencyId,
                        AgentId = agentId  
                        }
                        )
                        );
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        [Route("/api/agents/{agentId}/aliases", Name = "GetAliases")] 
        public IActionResult GetAliases(int agentId)
        {
            var result = _aliasRepo.GetByAgent(agentId);
            if (result.Success)
            {
                return Ok(
                    result.Data.Select(
                        al => new AliasModel()
                        {
                            AliasId = al.AliasId,
                            AliasName = al.AliasName,
                            InterpolId = al.InterpolId,
                            Persona = al.Persona,
                            AgentId = al.AgentId
                        }
                        )
                    );
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
