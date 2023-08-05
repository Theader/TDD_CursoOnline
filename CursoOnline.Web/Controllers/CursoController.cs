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

        public IActionResult Editar(int id)
        {
            var curso = cursoRepositorio.ObterPorId(id);
            var dto = new CursoDTO
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Descricao = curso.Descricao,
                CargaHoraria = curso.CargaHoraria,
                Valor = curso.Valor
            };
            return View("NovoOuEditar", dto);
        }
        public IActionResult Novo()
        {
            return View("NovoOuEditar", new CursoDTO());
        }

        [HttpPost]
        public ActionResult Salvar(CursoDTO model)
        {
            _armazenadorDeCurso.Armazenar(model);           
            return Ok();
        }
    }
}
