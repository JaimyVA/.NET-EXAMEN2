using Microsoft.AspNetCore.Mvc;
using MovieStoreExamen.Areas.Identity.Data;
using MovieStoreExamen.Data;
using MovieStoreExamen.Services;

namespace MovieStoreExamen.Controllers
{
    public class ApplicationController : Controller
    {
        protected readonly ApplicationUser _user;
        protected readonly ApplicationDbContext _context;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ILogger<ApplicationController> _logger;
        protected ApplicationController(ApplicationDbContext context,
                                        IHttpContextAccessor httpContextAccessor,
                                        ILogger<ApplicationController> logger)
        {
            _logger = logger;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            //string? userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            //if (userName == null)
            //    userName = "-";
            //_user = context.Users.FirstOrDefault(u=>u.UserName == userName);
            _user = SessionUser.GetUser(httpContextAccessor.HttpContext);
        }
    }
}
