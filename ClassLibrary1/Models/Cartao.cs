using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary1.Models
{
    public class Cartao
    {
        [Key]
        public int NumeroCartao { get; set; }
        public string Emissor { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime Validade { get; set; }
        public decimal Anuidade { get; set; }
        public decimal Plafond { get; set; }


        [ForeignKey("Titular")]
        public int IdTitular { get; set; }
        public Titular Titular { get; set; }

    }
}
