using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary1.Models
{
    public class TipoConta
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        [ForeignKey("Conta")]
        public int NumeroConta { get; set; }
        public Conta Conta { get; set; }

        [ForeignKey("Titular")]
        public int IdTitular { get; set; }
        public Titular Titular { get; set; }
    }
}
