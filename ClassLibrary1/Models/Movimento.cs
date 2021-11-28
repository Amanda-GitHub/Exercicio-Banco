using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary1.Models
{
    public class Movimento
    {
        public int Id { get; set; }
        public string TipoMovimento { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        [ForeignKey("Conta")]
        public int NumeroConta { get; set; }
        public Conta Conta { get; set; }
    }
}
