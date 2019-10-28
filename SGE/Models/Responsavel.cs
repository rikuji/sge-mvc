using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.Models
{
    public class Responsavel
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(15)]
        public string CPF { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(15)]
        public string Celular { get; set; }
        [StringLength(15)]
        public string TelefoneFixo { get; set; }
        public DateTime DateNascimento { get; set; }
        [StringLength(15)]
        public string Sexo { get; set; }
        [StringLength(50)]
        public string Logradouro { get; set; }
        [StringLength(50)]
        public string Complemento { get; set; }
        [StringLength(50)]
        public string Bairro { get; set; }
        [StringLength(50)]
        public string Cidade { get; set; }
        [StringLength(50)]
        public string Estado { get; set; }
        [StringLength(2)]
        public string UF { get; set; }
        [StringLength(15)]
        public string CEP { get; set; }
        [StringLength(10)]
        public string Numero { get; set; }
        [StringLength(50)]
        public string ResposavelLegal { get; set; }
        [StringLength(50)]
        public string ResposavelFinanceiro { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public int TipoUsuarioId { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public int EstadoCivilId { get; set; }

    }
}
