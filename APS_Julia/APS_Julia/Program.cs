﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_Julia
{
    class Program
    {
        private static List<Biblioteca> listaLivros = new List<Biblioteca>(); 
        static void Main(string[] args)
        {

            String opcao;
            int id;
            Boolean continuar = true;
            Biblioteca pesquisaLivro;

            do
            {
                Console.WriteLine("****************************");
                Console.WriteLine("\nCadastro - Biblioteca" + Environment.NewLine);
                Console.WriteLine("Menu" + Environment.NewLine);
                Console.WriteLine("01 - Incluir");
                Console.WriteLine("02 - Alterar");
                Console.WriteLine("03 - Excluir");
                Console.WriteLine("04 - Listar");
                Console.WriteLine("05 - Pesquisar");
                Console.WriteLine("06 - Sair" + Environment.NewLine);
                Console.WriteLine("Digite a opção desejada:");
                opcao = Console.ReadLine();
                Console.WriteLine("****************************");

                switch (opcao)
                {
                    case "01":
                        listaLivros.Add(inserirLivro(0));
                        break;
                    case "02":
                        Console.WriteLine("\nAlterar");

                        Console.WriteLine("\nIndique o Id:");

                        id = Convert.ToInt32(Console.ReadLine());

                        pesquisaLivro = listaLivros.Find(x => x.Id == id);

                        if (pesquisaLivro != null)
                        {
                            Console.WriteLine("\nId: " + pesquisaLivro.Id);
                            Console.WriteLine("Nome: " + pesquisaLivro.Nome);
                            Console.WriteLine("Autor: " + pesquisaLivro.Autor);
                            Console.WriteLine("Editora: " + pesquisaLivro.Editora + Environment.NewLine);
                        }
                        else
                        {
                            Console.WriteLine("Nenhum elemento encontrado!");
                        }

                        listaLivros.RemoveAll(x => x.Id == id);

                        listaLivros.Add(inserirLivro(id));

                        break;
                    case "03":
                        Console.WriteLine("\nExcluir" + Environment.NewLine);

                        Console.WriteLine("Indique o Id:");

                        id = Convert.ToInt32(Console.ReadLine());

                        listaLivros.RemoveAll(x => x.Id == id);

                        Console.WriteLine();

                        Console.WriteLine("\nLivro excluído com sucesso!" + Environment.NewLine);

                        break;
                    case "04":
                        Console.WriteLine("\nListagem" + Environment.NewLine);
                        listagem();
                        break;
                    case "05":
                        Console.WriteLine("\nPesquisar");
                        pesquisar();
                        break;
                    case "06":
                        Console.WriteLine("Seu aplicativo foi encerrado!");
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção não existente!");
                        break;
                }
            } while (continuar);

            Console.ReadKey();
        }

        private static Biblioteca inserirLivro(int id)
        {
            Biblioteca livro = new Biblioteca();

            if (id != 0)
            {
                Console.WriteLine("\nEdição de Livro");
                livro.Id = id;
                Console.Write("\nInsira o nome: ");
                livro.Nome = Console.ReadLine();
                Console.Write("Insira o autor: ");
                livro.Autor = Console.ReadLine();
                Console.Write("Insira a editora: ");
                livro.Editora = Console.ReadLine();

                Console.WriteLine("\nEdição efetuada com sucesso!\n");
            }
            else
            {
                Console.WriteLine("\nCadastro de Livro");
                Console.Write("\nInsira o id: ");
                livro.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Insira o nome: ");
                livro.Nome = Console.ReadLine();
                Console.Write("Insira o autor: ");
                livro.Autor = Console.ReadLine();
                Console.Write("Insira a editora: ");
                livro.Editora = Console.ReadLine();

                Console.WriteLine("\nCadastro efetuado com sucesso!\n");
            }
            return livro;
        }

        private static Biblioteca listagem()
        {
            foreach (Biblioteca livrinhos in listaLivros)
            {
                Console.WriteLine("Id: " + livrinhos.Id);
                Console.WriteLine("Nome: " + livrinhos.Nome);
                Console.WriteLine("Autor: " + livrinhos.Autor);
                Console.WriteLine("Editora: " + livrinhos.Editora + Environment.NewLine);
            }
            return null;
        }

        private static Biblioteca pesquisar()
        {
            String opcao2;
            String pesquisa;
            Biblioteca pesquisaLivro = null;

            Console.WriteLine("01 - Por Id");
            Console.WriteLine("02 - Por Nome");
            Console.WriteLine("03 - Por Autor");
            Console.WriteLine("04 - Por Editora");

            Console.Write("\nIndique a opção: ");
            opcao2 = Console.ReadLine();

            switch (opcao2)
            {
                case "01":
                    Console.Write("Insira o Id: ");
                    pesquisa = Console.ReadLine();
                    pesquisaLivro = listaLivros.Find(x => x.Id == Convert.ToInt32(pesquisa));
                    break;
                case "02":
                    Console.Write("Insira o Nome: ");
                    pesquisa = Console.ReadLine();
                    pesquisaLivro = listaLivros.Find(x => x.Nome == pesquisa);
                    break;
                case "03":
                    Console.Write("Insira o Autor: ");
                    pesquisa = Console.ReadLine();
                    pesquisaLivro = listaLivros.Find(x => x.Autor == pesquisa);
                    break;
                case "04":
                    Console.Write("Insira o Editora: ");
                    pesquisa = Console.ReadLine();
                    pesquisaLivro = listaLivros.Find(x => x.Editora == pesquisa);
                    break;
                default:
                    Console.WriteLine("Opção não existente!");
                    break;

            }

            if (pesquisaLivro != null)
            {
                Console.WriteLine("\nId: " + pesquisaLivro.Id);
                Console.WriteLine("Nome: " + pesquisaLivro.Nome);
                Console.WriteLine("Autor: " + pesquisaLivro.Autor);
                Console.WriteLine("Editora: " + pesquisaLivro.Editora + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("Nenhum elemento encontrado!");
            }
            return null;
        }
    }
}
