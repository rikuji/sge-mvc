using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public AnoDisciplina AnoDisciplina { get; set; }
        public int AnoDisciplinaId { get; set; }
    }
}
