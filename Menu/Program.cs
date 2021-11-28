using ClassLibrary1.Data;
using ClassLibrary1.Models;
using System;
using System.Linq;

namespace Menu
{
    public class Program
    {
        static void Main(string[] args)
        {
            string menu;
            do
            {
                Console.WriteLine("----BEM VINDO AO NOSSO BANCO---");
                Console.WriteLine("Selecione a opção desejada:");
                Console.WriteLine("1 - CRIAR CONTA\n2 - LISTAR DADOS DOS TITULARES\n3 - MOSTRAR MOVIMENTOS DA CONTA\n4 - ADICIONAR PRODUTO\n5 - ADICIONAR MOVIMENTO\n0 - SAIR");

                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        AdicionarConta();                                  
                        break;
                    case "2":
                        ConsultarTitulares();
                        break;
                    case "3":
                        MostrarMovimentos();
                        break;
                    case "4":
                        AdicionarProduto();
                        break;
                    case "5":
                        AdicionarMovimento();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do programa, até a próxima!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, agradecemos inserir uma opção válida!");
                        break;
                }

            } while (menu != "0");



            static void AdicionarConta()
            {
                using (ContextoDB banco = new ContextoDB())
                {
                    Console.WriteLine("1 - NOVO TITULAR\n2 - TITULAR EXISTENTE");
                    string opcao;
                    opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.WriteLine("Insira as informações do Titular");
                            Titular novoTitular = new Titular();
                            Console.WriteLine("Nome:");
                            novoTitular.Nome = Console.ReadLine();
                            Console.WriteLine("Morada:");
                            novoTitular.Morada = Console.ReadLine();
                            Console.WriteLine("Cartão Cidadão:");
                            novoTitular.CartaoCidadao = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Contribuinte:");
                            novoTitular.Contribuinte = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Data de Nascimento: aaaa/mm/dd");
                            novoTitular.DataNascimento = Convert.ToDateTime(Console.ReadLine());
                            banco.Titulares.Add(novoTitular);

                            Conta novaConta = new Conta();
                            Console.WriteLine("Data de início: aaaa/mm/dd");
                            novaConta.DataRegisto = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Agência:");
                            novaConta.Agencia = Console.ReadLine();
                            Console.WriteLine("Gerente:");
                            novaConta.Gerente = Console.ReadLine();
                            banco.Contas.Add(novaConta);

                            TipoConta novoTipoConta = new TipoConta();
                            Console.WriteLine("Tipo de Conta:");
                            novoTipoConta.Tipo = Console.ReadLine();
                            novoTipoConta.Conta = novaConta;
                            novoTipoConta.Titular = novoTitular;
                            banco.TiposConta.Add(novoTipoConta);
                            banco.SaveChanges();
                            break;
                        
                        case "2":
                            Console.WriteLine("Qual o ID do titular?");
                            Titular existente = banco.Titulares.Find(Convert.ToInt32(Console.ReadLine()));
                            Conta nova = new Conta();
                            Console.WriteLine("Data de início: aaaa/mm/dd");
                            nova.DataRegisto = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Agência:");
                            nova.Agencia = Console.ReadLine();
                            Console.WriteLine("Gerente:");
                            nova.Gerente = Console.ReadLine();
                            banco.Contas.Add(nova);

                            TipoConta novo = new TipoConta();
                            Console.WriteLine("Tipo de Conta:");
                            novo.Tipo = Console.ReadLine();
                            novo.Conta = nova;
                            novo.Titular = existente;
                            banco.TiposConta.Add(novo);
                            banco.SaveChanges();
                            break;

                        default:
                            Console.WriteLine("Opção inválida, agradecemos inserir uma opção válida!");
                            break;
                    }                  



                }
                
            }
            static void ConsultarTitulares()
            {
                using (ContextoDB banco = new ContextoDB())
                {
                    Console.WriteLine("Insira o ID do Titular:");
                    var titular = banco.Titulares.Find(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine($"Id: {titular.Id}\nNome:{titular.Nome}\nMorada:{titular.Morada}\nCartao Cidadão:{titular.CartaoCidadao}\nContribuinte:{titular.Contribuinte}\nData de Nascimento:{titular.DataNascimento}\nTipos de conta:{titular.TiposConta}");
                }
            }
            static void MostrarMovimentos()
            {
                using (ContextoDB banco = new ContextoDB())
                {
                    Console.WriteLine("Insira o Número da Conta:");                    
                    var consultar = banco.Contas.Find(Convert.ToInt32(Console.ReadLine()));
                    var movimento = banco.Movimentos.Where(m => m.NumeroConta == consultar.Numero);                   
                    
                    foreach (var item in movimento)
                    {
                        Console.WriteLine($"Tipo de movimento: {item.TipoMovimento}\nData: {item.Data}\nValor: {item.Valor}");
                    }
                    
                    
                }
            }
            static void AdicionarProduto()
            {
                using (ContextoDB banco = new ContextoDB())
                {
                    Console.WriteLine("Insira o Id do Titular:");
                    Titular idTitular = banco.Titulares.Find(Convert.ToInt32(Console.ReadLine()));
                    Produto novoProduto = new Produto();
                    Console.WriteLine("Insira o Nome do Produto:");
                    novoProduto.Nome = Console.ReadLine();
                    Console.WriteLine("Insira o Preço do Produto:");
                    novoProduto.Preco = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Insira a data de aquisição do Produto:");
                    novoProduto.DataRegisto = Convert.ToDateTime(Console.ReadLine());
                    banco.Produtos.Add(novoProduto);
                    TipoProduto novoTipo = new TipoProduto();
                    novoTipo.Produto = novoProduto;
                    novoTipo.Titular = idTitular;
                    banco.TiposProduto.Add(novoTipo);
                    banco.SaveChanges();
                  
                }
            }
            static void AdicionarMovimento()
            {
                using (ContextoDB banco = new ContextoDB())
                {
                    Console.WriteLine("Insira o Número da Conta:");
                    Conta numeroConta = banco.Contas.Find(Convert.ToInt32(Console.ReadLine()));
                    Movimento novo = new Movimento();
                    Console.WriteLine("Qual o tipo de movimento?");
                    novo.TipoMovimento = Console.ReadLine();
                    novo.Data = DateTime.Today;
                    Console.WriteLine("Qual o valor?");
                    novo.Valor = Convert.ToDecimal(Console.ReadLine());
                    novo.Conta = numeroConta;
                    banco.Movimentos.Add(novo);
                    banco.SaveChanges();
                }
            }

            
        }

    }
}