using Microsoft.AspNetCore.Mvc;
using Worklogs_2026.BD.Data.Entities;
using Worklogs_2026.Repositorio.Repository;
using Worklogs_2026.Shared.DTO;

namespace Worklogs_2026.Server.Controllers
{
    [ApiController]
    [Route("api/worklogs")]
    public class WorkLogController : ControllerBase
    {
        private readonly IWorkLogRepository repository;

        public WorkLogController(IWorkLogRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("list/{uploadedFileID:int}")]
        public async Task<ActionResult<List<UploadedFilesListDTO>>> GetList(int uploadedFileID)
        {
            var list = await repository.GetList(uploadedFileID);
            if (list == null)
            {
                return NotFound("No list found(NULL).");
            }
            if (list.Count == 0)
            {
                return NotFound("No existing records on list.");
            }
            return Ok(list);
        }


        /*
        [HttpGet]
        public async Task<ActionResult<List<WorkLog>>> GetFull()
        {
            var list = await repository.GetFull();

            if (list == null)
            {
                return NotFound("No list found(NULL).");
            }

            if (list.Count == 0)
            {
                return NotFound("No existing records on list.");
            }

            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<WorkLog>> GetById(int id)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return NotFound($"No row found with ID {id}.");
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(WorkLog workLog)
        {
            try
            {
                await repository.Post(workLog);
                return Ok(workLog.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, WorkLog workLog)
        {
            var result = await repository.Put(id, workLog);
            return Ok($"Row with id {id} correctly updated");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await repository.Delete(id);
            if (!result)
            {
                return NotFound($"No row found with ID {id} to delete.");
            }
            return Ok($"Row with id {id} correctly deleted");
        }

        */
    }
}
