using CursoOnline.Dominio.Cursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoOnline.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;

        public CursoController(ArmazenadorDeCurso armazenadorDeCurso)
        {
            this._armazenadorDeCurso = armazenadorDeCurso;
        }
        // GET: CursoController
        public IActionResult Index()
        {
            return Ok();
            //return View("Index",);
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
            _armazenadorDeCurso.Armazenar(model);
            return Ok();
        }
    }
}
