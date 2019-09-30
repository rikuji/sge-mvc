using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Turno { get; set; }
        public string Registro { get; set; }
        [DisplayName("Tipo de Usuário")]
        public TipoUsuario TipoUsuario { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
