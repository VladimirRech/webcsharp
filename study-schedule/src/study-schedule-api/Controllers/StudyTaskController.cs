using Microsoft.AspNetCore.Mvc;
using study_schedule_api.Classes;
using System.Net;
using Microsoft.EntityFrameworkCore;
using study_schedule_api.DbContexts;

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

        [HttpGet("{id}")]
        [Route("remove")]
        [ProducesResponseType(typeof(StudyClassResponse), (int)HttpStatusCode.OK)]
        public IActionResult RemoveTask(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            StudyTask obj = _dbContext.StudyTask.Where(item => item.Id == id 
                && !item.Removed).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }

            try 
            {
                obj.Removed = true;
                obj.UpdateDate = DateTime.Now;

                if (ModelState.IsValid)
                {
                    _dbContext.Entry<StudyTask>(obj).State = EntityState.Modified;
                    _dbContext.SaveChanges();                    
                }
                else 
                {
                    return StatusCode(StatusCodes.Status417ExpectationFailed, "Dados inválidos.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateTask([FromBody] StudyTask study)
        {
            if (study == null)
            {
                return BadRequest();
            }

            StudyTask obj = _dbContext.StudyTask.Where(item => item.Id == study.Id).FirstOrDefault();

            if (obj == null)
            {
                return NotFound();
            }            

            try
            {
               obj.Title = study.Title;
               obj.Notes = study.Notes;
               obj.DueDate = study.DueDate;
               obj.UpdateDate = DateTime.Now;

                if (ModelState.IsValid)
                {
                    _dbContext.Entry<StudyTask>(obj).State = EntityState.Modified;
                    _dbContext.SaveChanges();                    
                }
                else 
                {
                    return StatusCode(StatusCodes.Status417ExpectationFailed, "Dados inválidos.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok();
        }
    }
}