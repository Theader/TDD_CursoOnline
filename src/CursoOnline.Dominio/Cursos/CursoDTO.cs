﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnline.Dominio.Cursos
{
    public class CursoDTO
    {
        public string Nome { get;  set; }
        public int CargaHoraria { get;  set; }
        public string PublicoAlvo { get;  set; }
        public double Valor { get;  set; }
        public string Descricao { get;  set; }
        public int Id { get; set; }
    }
}
