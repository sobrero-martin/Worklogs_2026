using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Worklogs_2026.BD.Data.Entities;
using Worklogs_2026.Repositorio.Repository;
using Worklogs_2026.Shared.Constants;
using Worklogs_2026.Shared.DTO;

namespace Worklogs_2026.Server.Controllers
{
    [ApiController]
    [Route("api/worklogs")]
    public class WorkLogController : ControllerBase
    {
        private readonly IWorkLogRepository repository;
        private readonly IOutputCacheStore outputCacheStore;

        private const string cacheKey = "WorklogsCache";

        public WorkLogController(IWorkLogRepository repository,
                                 IOutputCacheStore outputCacheStore)
        {
            this.repository = repository;
            this.outputCacheStore = outputCacheStore;
        }

        [HttpGet("list/{uploadedFileID:int}")]
        [AllowAnonymous]
        [OutputCache(Tags = new[] { cacheKey })]
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

            Response.Headers["Cache-Control"] = $"public, max-age={GlobalConstants.CacheDurationInSeconds}";
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
