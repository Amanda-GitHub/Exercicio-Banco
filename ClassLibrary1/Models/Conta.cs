using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Models
{
    public class Conta
    {
        [Key]
        public int Numero { get; set; }
        public DateTime DataRegisto { get; set; }
        public string Agencia { get; set; }
        public string Gerente { get; set; }


        public ICollection<TipoConta> TiposConta { get; set; }

        public ICollection<Movimento> Movimento { get; set; }

    }
}
