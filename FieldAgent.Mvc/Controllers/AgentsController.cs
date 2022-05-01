using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace FieldAgent.Mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentRepository _agentRepo;

        public AgentsController(IAgentRepository agentRepo)
        {
            _agentRepo = agentRepo;
        }

        ////GetAgents??
        //[HttpGet]
        //[Route("api/[controller]")]
        //public List<Agent> GetAgents()
        //{
        //    var agents = new List<Agent>();
        //    int i = 1;
        //    var result = _agentRepo.Get()
        //    while()
        //}


        [HttpGet]
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
                return BadRequest(result.Message);
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddAgent(AgentModel agentModel)
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
                    return Ok(result.Data);
                    //return CreatedAtRoute(nameof(GetAgent), new { id = result.Data.agentId }, result.Data);
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


        //Delete
        //Put - UpdateAgent
        //GetMissions

    }
}
