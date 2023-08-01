using CursoOnline.Dominio._Base;
using System;

namespace CursoOnline.Dominio.Cursos
{
    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio CursoRepository;

        public ArmazenadorDeCurso(ICursoRepositorio _CursoRepository)
        {
            this.CursoRepository = _CursoRepository;
        }

        public void Armazenar(CursoDTO cursoDTO)
        {
            var cursoJaSalvo = CursoRepository.ObterPeloNome(cursoDTO.Nome);

            Enum.TryParse(typeof(PublicoAlvo), cursoDTO.PublicoAlvo, out var _publicoAlvo);

            ValidadorDeRegra.Novo()
                .Quando(cursoJaSalvo != null, Resource.NomeDoCursoJaExiste)
                .Quando(_publicoAlvo == null, Resource.PublicoAlvoInvalido)
                .DispararExcecaoSeExistir();
                                

            var curso =
                new Curso(cursoDTO.Nome, cursoDTO.Descricao, cursoDTO.CargaHoraria
                         , (PublicoAlvo)_publicoAlvo, cursoDTO.Valor);
            if(cursoDTO.Id > 0)
            {
                curso = CursoRepository.ObterPorId(cursoDTO.Id);
                curso.AlterarNome(cursoDTO.Nome);
                curso.AlterarValor(cursoDTO.Valor);
                curso.AlterarCargaHoraria(cursoDTO.CargaHoraria);

            }
            if(cursoDTO.Id == 0)
            {
                CursoRepository.Adicionar(curso);
            }
        }
    }
}
