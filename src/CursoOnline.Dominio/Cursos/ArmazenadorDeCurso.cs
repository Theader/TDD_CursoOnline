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
                .Quando(cursoJaSalvo != null, "Nome do Curso já existe na base!")
                .Quando(_publicoAlvo == null, "Publico Alvo Inválido!")
                .DispararExcecaoSeExistir();
                                

            var curso =
                new Curso(cursoDTO.Nome, cursoDTO.Descricao, cursoDTO.CargaHoraria
                         , (PublicoAlvo)_publicoAlvo, cursoDTO.Valor);
            CursoRepository.Adicionar(curso);           
        }
    }
}
