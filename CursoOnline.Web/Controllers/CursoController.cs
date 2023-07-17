using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CursoOnline.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        private readonly IRepositorio<Curso> cursoRepositorio;

        public CursoController(ArmazenadorDeCurso armazenadorDeCurso, IRepositorio<Curso> cursoRepositorio)
        {
            this._armazenadorDeCurso = armazenadorDeCurso;
            this.cursoRepositorio = cursoRepositorio;
        }
        // GET: CursoController
        public IActionResult Index()
        {
            var cursos = cursoRepositorio.Consultar();
            if (cursos.Any())
            {
                var cursosDTOS = cursos.Select(c => new CursoParaListagemDTO()
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    CargaHoraria = c.CargaHoraria,
                    PublicoAlvo = c.PublicoAlvo.ToString(),
                    Valor = c.Valor,
                    Descricao = c.Descricao
                });
                return View("Index",PaginatedList<CursoParaListagemDTO>.Create(cursosDTOS,Request));
            }
            return View("Index", PaginatedList<CursoParaListagemDTO>.Create(null, Request));
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
