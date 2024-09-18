using Microsoft.AspNetCore.Mvc;

namespace Lista6.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class PessoaController : Controller
    {
        private 
        public IActionResult Index()
        {
            return View();
        }
    }
}
