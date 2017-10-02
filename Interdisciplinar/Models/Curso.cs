using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interdisciplinar.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public String Nome { get; set; }
        public String Coordenador { get; set; }
        public String EmailCoordenador { get; set; }

    }
}