using study_schedule_api.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace study_schedule_api.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly MyContext _dbContext;

        public BaseController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}