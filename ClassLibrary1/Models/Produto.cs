using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataRegisto { get; set; }
        public DateTime DataFinalizacao { get; set; }

        public ICollection<TipoProduto> TiposProduto { get; set; }
                
    }
}
