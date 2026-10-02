using System;

namespace ProjetoAgenda
{
    internal class Program
    {
        private static Contatos minhasAgenda = new Contatos();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("    AGENDA DE CONTATOS — IFSP CUBATÃO        ");
                Console.WriteLine("==============================================");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar contato");
                Console.WriteLine("2. Pesquisar contato");
                Console.WriteLine("3. Alterar contato");
                Console.WriteLine("4. Remover contato");
                Console.WriteLine("5. Listar contatos");
                Console.WriteLine("==============================================");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao = -1;
                }

                Console.WriteLine();

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Encerrando o sistema...");
                        break;
                    case 1:
                        AdicionarContato();
                        break;
                    case 2:
                        PesquisarContato();
                        break;
                    case 3:
                        AlterarContato();
                        break;
                    case 4:
                        RemoverContato();
                        break;
                    case 5:
                        ListarContatos();
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        private static void AdicionarContato()
        {
            Console.WriteLine("--- ADICIONAR CONTATO ---");
            Console.Write("Informe o e-mail: ");
            string email = Console.ReadLine();

            if (minhasAgenda.pesquisar(new Contato(email)) != null)
            {
                Console.WriteLine("\nErro: Já existe um contato cadastrado com este e-mail.");
                return;
            }

            Console.Write("Informe o nome: ");
            string nome = Console.ReadLine();

            Data dtNasc = LerDataNascimento();

            Contato novoContato = new Contato(email, nome, dtNasc);
            CadastrarTelefones(novoContato);

            if (minhasAgenda.adicionar(novoContato))
            {
                Console.WriteLine("\nContato cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nFalha ao cadastrar o contato.");
            }
        }

        private static void PesquisarContato()
        {
            Console.WriteLine("--- PESQUISAR CONTATO ---");
            Console.Write("Informe o e-mail para pesquisa: ");
            string email = Console.ReadLine();

            Contato encontrado = minhasAgenda.pesquisar(new Contato(email));

            if (encontrado != null)
            {
                Console.WriteLine("\nContato Encontrado:");
                Console.WriteLine(encontrado.ToString());
                Console.WriteLine("\nTelefones cadastrados:");
                if (encontrado.Telefones.Count == 0)
                {
                    Console.WriteLine(" - Nenhum telefone registrado.");
                }
                else
                {
                    foreach (var tel in encontrado.Telefones)
                    {
                        Console.WriteLine($" - {tel}");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nContato não encontrado.");
            }
        }

        private static void AlterarContato()
        {
            Console.WriteLine("--- ALTERAR CONTATO ---");
            Console.Write("Informe o e-mail do contato que deseja alterar: ");
            string email = Console.ReadLine();

            Contato existente = minhasAgenda.pesquisar(new Contato(email));

            if (existente == null)
            {
                Console.WriteLine("\nContato não encontrado para alteração.");
                return;
            }

            Console.WriteLine($"\nAlterando dados para: {existente.Nome}");
            Console.Write("Novo nome: ");
            string novoNome = Console.ReadLine();

            Data novaData = LerDataNascimento();

            Contato contatoAtualizado = new Contato(email, novoNome, novaData);

            Console.Write("Deseja recadastrar os telefones? (S/N): ");
            string resp = Console.ReadLine().Trim().ToUpper();
            if (resp == "S")
            {
                CadastrarTelefones(contatoAtualizado);
            }
            else
            {
                foreach (var tel in existente.Telefones)
                {
                    contatoAtualizado.adicionarTelefone(tel);
                }
            }

            if (minhasAgenda.alterar(contatoAtualizado))
            {
                Console.WriteLine("\nContato alterado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nErro ao alterar o contato.");
            }
        }

        private static void RemoverContato()
        {
            Console.WriteLine("--- REMOVER CONTATO ---");
            Console.Write("Informe o e-mail do contato a ser removido: ");
            string email = Console.ReadLine();

            Contato c = new Contato(email);

            if (minhasAgenda.remover(c))
            {
                Console.WriteLine("\nContato removido com sucesso!");
            }
            else
            {
                Console.WriteLine("\nContato não encontrado.");
            }
        }

        private static void ListarContatos()
        {
            Console.WriteLine("--- LISTA DE CONTATOS ---");

            if (minhasAgenda.Agenda.Count == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado na agenda.");
                return;
            }

            for (int i = 0; i < minhasAgenda.Agenda.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {minhasAgenda.Agenda[i]}");
            }
        }

        private static Data LerDataNascimento()
        {
            int dia, mes, ano;
            Console.WriteLine("Data de Nascimento:");
            Console.Write("  Dia: ");
            int.TryParse(Console.ReadLine(), out dia);
            Console.Write("  Mês: ");
            int.TryParse(Console.ReadLine(), out mes);
            Console.Write("  Ano: ");
            int.TryParse(Console.ReadLine(), out ano);

            return new Data(dia, mes, ano);
        }

        private static void CadastrarTelefones(Contato contato)
        {
            string opcao;
            do
            {
                Console.Write("\nTipo do telefone (ex: Celular, Residencial, Trabalho): ");
                string tipo = Console.ReadLine();

                Console.Write("Número: ");
                string numero = Console.ReadLine();

                Console.Write("É o telefone principal? (S/N): ");
                bool principal = Console.ReadLine().Trim().ToUpper() == "S";

                contato.adicionarTelefone(new Telefone(tipo, numero, principal));

                Console.Write("Deseja adicionar outro telefone? (S/N): ");
                opcao = Console.ReadLine().Trim().ToUpper();

            } while (opcao == "S");
        }
    }
}