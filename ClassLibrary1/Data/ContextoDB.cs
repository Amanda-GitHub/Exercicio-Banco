using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Data
{
    public class ContextoDB : DbContext
    {
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoConta> TiposConta { get; set; }
        public DbSet<TipoProduto> TiposProduto { get; set; }
        public DbSet<Titular> Titulares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>().HasData(
               new Conta() { Numero = 1, Agencia = "Lisboa", DataRegisto = DateTime.Today, Gerente = "José Luiz", });

            modelBuilder.Entity<Cartao>().HasData(
                new Cartao() { Anuidade = 20, DataEmissao = DateTime.Today, Emissor = "Visa", NumeroCartao = 1234, Plafond = 1000, Validade = new DateTime(2022, 11, 14, 0, 0, 0), IdTitular = 1 });

            modelBuilder.Entity<Produto>().HasData(
                new Produto() { Id = 1, Nome = "Cartão de débito", DataRegisto = new DateTime(2020, 11, 17, 18, 35, 0), Preco = 5 });

            modelBuilder.Entity<Titular>().HasData(
                new Titular() { Nome = "Fernando Soares", CartaoCidadao = 123456, Contribuinte = 222222777, Morada = "Rua ABC, 17 - Lisboa", DataNascimento = new DateTime(1980, 02, 17, 0, 0, 0), Id = 1 });

            modelBuilder.Entity<Movimento>().HasData(
                new Movimento() { Id = 1, TipoMovimento = "Levantamento MB", Data = DateTime.Today, Valor = 20, NumeroConta = 1 });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=BancoDB; Trusted_Connection=True");
        }


    }
        
}
