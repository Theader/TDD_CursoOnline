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
            if (cursoJaSalvo != null)
                throw new ArgumentException("Nome do Curso já existe na base!");

            Enum.TryParse(typeof(PublicoAlvo), cursoDTO.PublicoAlvo, out var _publicoAlvo);
            if (_publicoAlvo == null)
                throw new ArgumentException("Publico Alvo Inválido!");

            var curso =
                new Curso(cursoDTO.Nome, cursoDTO.Descricao, cursoDTO.CargaHoraria
                         , (PublicoAlvo)_publicoAlvo, cursoDTO.Valor);
            CursoRepository.Adicionar(curso);
        }
    }
}
