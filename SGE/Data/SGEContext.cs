using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SGE.Models
{
    public class SGEContext : DbContext
    {
        public SGEContext(DbContextOptions<SGEContext> options)
            : base(options)
        {
        }

        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<AnoDisciplina> AnoDisciplina { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<Turma> Turma { get; set; }
        
    }
}
