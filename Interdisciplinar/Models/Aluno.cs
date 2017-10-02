using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interdisciplinar.Models
{
    public class Aluno
    {
        public int AlunoId{ get; set; }
        public String Nome { get; set; }
        public Decimal Telefone { get; set; }
        public String Email { get; set; }
        public String Turma { get; set; }
        public String Turno { get; set; }

        public int? CursoId { get; set; }
        public Curso Curso { get; set; }

    }
}