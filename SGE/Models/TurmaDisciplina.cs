using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.Models
{
    public class TurmaDisciplina
    {
        public int Id { get; set; }
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public int DisciplinaId { get; set; }
    }
}

