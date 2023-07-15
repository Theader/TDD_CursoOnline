using CursoOnline.Dominio.Cursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Web.Controllers
{
    public class CursoController : Controller
    {
        // GET: CursoController
        public IActionResult Index()
        {
            return View("Index",);
        }

        // GET: CursoController/Details/5
        public IActionResult Novo()
        {
            return View();
        }

        // GET: CursoController/Salvar
        [HttpPost]
        public ActionResult Salvar(CursoDTO model)
        {
            return Ok();
        }
    }
}
