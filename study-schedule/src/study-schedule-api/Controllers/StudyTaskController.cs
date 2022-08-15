using Microsoft.AspNetCore.Mvc;
using study_schedule_api.Classes;
using System.Net;
using Microsoft.EntityFrameworkCore;
using study_schedule_api.DbContexts;
using System.Linq;

namespace study_schedule_api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudyTaskController : BaseController
    {
        private readonly ILogger<StudyTaskController> _logger;

        public StudyTaskController(ILogger<StudyTaskController> logger, MyContext dbContext) : base(dbContext)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("items")]
        [ProducesResponseType(typeof(IEnumerable<StudyClassResponse>), (int)HttpStatusCode.OK)]
        public IEnumerable<StudyClassResponse> GetTasks()
        {
            var tasks = _dbContext.StudyTask.ToList<StudyTask>();

            var ret = new List<StudyClassResponse>();
            tasks.ForEach(item =>
            {
                ret.Add(new StudyClassResponse
                {
                    StudyClass = item,
                    Message = ""
                });
            });

            return ret.ToArray();
        }

        [HttpPost]
        [Route("insert")]
        // [ProducesResponseType(typeof(StudyClassResponse), (int)HttpStatusCode.OK)]
        // [ProducesResponseType(typeof(StudyClassResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult InsertTask([FromBody] StudyTask study)
        {
            var ret = new StudyClassResponse { Message = "/studytask/insert: not implemented" };

            if (ret == null)
            {
                return BadRequest(ret);
            }

            try
            {
                study.CreationDate = DateTime.Now;
                study.UpdateDate = DateTime.Now;
                _dbContext.StudyTask.Add(study);
                _dbContext.SaveChanges();
                ret.StudyClass = _dbContext.StudyTask.FirstOrDefault<StudyTask>();
                ret.Message = "/studytask/insert: register created succesfully.";
            }
            catch (Exception ex)
            {
                ret.Message = string.Format("/studytask/insert: internal error {0}.", ex.Message);
            }
            return Ok(ret);
        }

        [HttpGet]
        [Route("remove")]
        [ProducesResponseType(typeof(StudyClassResponse), (int)HttpStatusCode.OK)]
        public StudyClassResponse RemoveTask(int id)
        {
            return new StudyClassResponse() { Message = "/studytask/remove: not implemented" };
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(typeof(StudyClassResponse), (int)HttpStatusCode.OK)]
        public StudyClassResponse UpdateTask([FromBody] StudyTask study)
        {
            return new StudyClassResponse() { Message = "/studytask/update: not implemented" };
        }
    }
}