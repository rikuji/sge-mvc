﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.Models
{
    public class UserSecretaria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public int TipoUsuarioId { get; set; }

    }
}
