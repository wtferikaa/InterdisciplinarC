using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interdisciplinar.Models
{
    public class Ideia
    {
        public int? IdeiaId { get; set; }
        public String Nome { get; set; }
        public String DescricaoProblema { get; set; }
        public String Recomendacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAnalise { get; set; }
        public Boolean? Aprovado { get; set; }
        public String Resposta { get; set; } 


        public int? Id { get; set; }
        public Aluno Aluno { get; set; }
        
        public int IdIdeiaPai { get; set; }
        public Ideia IdeiaExistente { get; set; } 

        public int? IdIdeiaDepartamento { get; set; }
        public DepartamentoOpet DepartamentosOpet { get; set; }
    }
}