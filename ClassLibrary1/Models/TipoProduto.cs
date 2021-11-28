using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary1.Models
{
    public class TipoProduto
    {
        public int Id { get; set; }
        

        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }

        [ForeignKey("Titular")]
        public int IdTitular { get; set; }
        public Titular Titular { get; set; }
    }
}
