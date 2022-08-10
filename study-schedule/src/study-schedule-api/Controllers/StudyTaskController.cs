using Microsoft.AspNetCore.Mvc;
using study_schedule_api.Classes;
using System.Net;

namespace study_schedule_api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StudyTaskController
    {
        private readonly ILogger<StudyTaskController> _logger;

        public StudyTaskController(ILogger<StudyTaskController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("items")]
        [ProducesResponseType(typeof(IEnumerable<StudyTask>), (int)HttpStatusCode.OK)]
        public IEnumerable<StudyTask> GetTasks()
        {
            // Needs implementation
            return new List<StudyTask>().ToArray();
        }

        [HttpPost]
        [Route("insert")]
        [ProducesResponseType(typeof(StudyClassResponse), (int)HttpStatusCode.OK)]
        public StudyClassResponse InsertTask([FromBody] StudyTask study)
        {
            var ret = new StudyClassResponse { Message = "Not Implemented " };
            return ret;
        }

        [HttpGet]
        [Route("remove")]
        [ProducesResponseType(typeof(StudyClassResponse), (int)HttpStatusCode.OK)]
        public StudyClassResponse RemoveTask(int id)
        {
            return new StudyClassResponse() { Message = "Not implemented" };
        }
    }
}