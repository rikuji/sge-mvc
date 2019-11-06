using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.Models
{
    public class TurmaProfessor
    {
        public int Id { get; set; }
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }
    }
}
