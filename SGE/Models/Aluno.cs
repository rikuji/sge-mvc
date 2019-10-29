using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public string Sexo { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public int TipoUsuarioId { get; set; }
        public Responsavel Responsavel { get; set; }
        public int ResponsavelId { get; set; }
    }
}
