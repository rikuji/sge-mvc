using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.Models
{
    public class AlunoResponsavel
    {
        public int Id { get; set; }
        public Responsavel Responsavel { get; set; }
        public int ResponsavelId { get; set; }
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
    }
}
