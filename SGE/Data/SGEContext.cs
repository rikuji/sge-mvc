using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SGE.Models
{
    public class SGEContext : IdentityDbContext<IdentityUser> 
    {
        public SGEContext(DbContextOptions<SGEContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<AlunoResponsavel> AlunoResponsavel { get; set; }
        public DbSet<AnoDisciplina> AnoDisciplina { get; set; }
        public DbSet<CargoSecretaria> CargoSecretaria { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<TurmaDisciplina> TurmaDisciplina { get; set; }
        public DbSet<TurmaProfessor> TurmaProfessor { get; set; }
        public DbSet<UserSecretaria> UserSecretaria { get; set; }
        
        
    }
}
