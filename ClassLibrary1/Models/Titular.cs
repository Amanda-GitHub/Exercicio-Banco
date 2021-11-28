using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Models
{
    public class Titular
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public int CartaoCidadao { get; set; }
        public int Contribuinte { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<Cartao> Cartoes { get; set; }
        public ICollection<TipoConta> TiposConta { get; set; }
        public ICollection<TipoProduto> TiposProduto { get; set; }
    }
}
