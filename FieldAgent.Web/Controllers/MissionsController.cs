using FieldAgent.Core.Entities;
using FieldAgent.Core.Interfaces.DAL;
using FieldAgent.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FieldAgent.Web.Controllers
{
    [Route("api/agents/{agentId}/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        private readonly IMissionRepository _missionRepo;

        public MissionsController(IMissionRepository missionRepo)
        {
            _missionRepo = missionRepo;
        }

        [HttpGet]
        [Route("/api/agents/{agentId}/missions/{missionId}", Name = "GetMission")]
        public IActionResult GetMission(int missionId)
        {
            var result = _missionRepo.Get(missionId);
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
        [Route("/api/agents/{agentId}/missions")]
        public IActionResult InsertMission(MissionModel missionModel)
        {
            if (ModelState.IsValid)
            {
                Mission mission = new Mission
                {
                    MissionId = missionModel.MissionId, 
                    CodeName = missionModel.CodeName,
                    Notes = missionModel.Notes,
                    StartDate = missionModel.StartDate,
                    ProjectedEndDate = missionModel.ProjectedEndDate,
                    ActualEndDate = missionModel.ActualEndDate,
                    OperationalCost = missionModel.OperationalCost,
                    AgencyId = missionModel.AgencyId
                };

                var result = _missionRepo.Insert(mission);

                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetMission), new {agentId = missionModel.AgentId, missionId = result.Data.MissionId}, result.Data);
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

        [HttpDelete("{missionId}")]
        public IActionResult DeleteMission(int missionId)
        {
            var findResult = _missionRepo.Get(missionId);
            if (!findResult.Success)
            {
                return NotFound(findResult.Message);
            }

            var result = _missionRepo.Delete(missionId);

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
        [Route("/api/agents/{agentId}/missions/")]
        public IActionResult UpdateMission(MissionModel missionModel)
        {
            if (ModelState.IsValid && missionModel.MissionId > 0)
            {
                Mission mission = new Mission
                {
                    MissionId = missionModel.MissionId,
                    CodeName = missionModel.CodeName,
                    Notes = missionModel.Notes,
                    StartDate = missionModel.StartDate,
                    ProjectedEndDate = missionModel.ProjectedEndDate,
                    ActualEndDate = missionModel.ActualEndDate,
                    OperationalCost = missionModel.OperationalCost,
                    AgencyId = missionModel.AgencyId
                };

                var findResult = _missionRepo.Get(mission.MissionId);
                if (!findResult.Success)
                {
                    return NotFound(findResult.Message);
                }

                var result = _missionRepo.Update(mission);
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
                if (missionModel.MissionId < 1)
                    ModelState.AddModelError("MissionId", "Invalid Mission ID");
                return BadRequest(ModelState);
            }
        }

    }
}
