namespace Aula19_GerenciadorDeItensDeCompras;

using System.IO;

public class Program
{
    static void Main(string[] args)
    {
        // 1. Estrutura
        string path = @"C:\Dev\Curso_C#\AULAS\Aula19_GerenciadorDeListaDeCompras\";
        string fileName = "shopping_list.txt";
        string filePath = path + fileName;

        List<string> shoopingList = new List<string>();

        // Lógica
        if (File.Exists(filePath))
        {
            shoopingList.AddRange(File.ReadAllLines(filePath)); // Irá sobreescrever o arquivo, caso ele já exista
        }

        while (true)
        {
            Console.WriteLine("\n=== LISTA DE COMPRAS ===");
            Console.WriteLine("1. Adicionar item");
            Console.WriteLine("2. Remover item");
            Console.WriteLine("3. Exibir lista");
            Console.WriteLine("4. Limpar sua lista");
            Console.WriteLine("5. Exportar lista em .txt");

            Console.Write("Escolha um número para continuar: ");
            string choiceUser = Console.ReadLine();

            switch (choiceUser)
            {
                case "1":
                    Console.Write("Digite o nome do item para adicionar: ");
                    string itemInsert = Console.ReadLine();

                    if (!string.IsNullOrEmpty(itemInsert))
                    {
                        shoopingList.Add(itemInsert);
                        Console.Write($"Item '{itemInsert}' adicionado com sucesso!\n");
                    }
                    else
                    {
                        Console.WriteLine("ERRO: O item não pode ser vazio!");
                    }
                break;

                case "2":
                    Console.Write("Digite o nome do item para remover: ");
                    string itemToRemove = Console.ReadLine();

                    if (shoopingList.Remove(itemToRemove))
                    {
                        Console.WriteLine($"Item '{itemToRemove}' removido com sucesso!");
                    }
                    else
                    {
                        Console.Write($"Item '{itemToRemove}' não encontrado!");
                    }
                break;

                case "3":
                    Console.WriteLine("\nItens na sua Lista de Compras: ");
                    if (shoopingList.Count == 0)
                    {
                        Console.Write("Sua lista está vazia!");
                    }
                    else
                    {
                        for (int i = 0; i < shoopingList.Count; i++)
                        {
                            Console.Write($"{i + 1}. {shoopingList[i]}");
                            Console.WriteLine();
                        }
                    }
                break;

                case "4":
                    Console.WriteLine("Limpando a sua lista...");
                    Thread.Sleep(2000);
                    shoopingList.Clear();

                    Console.WriteLine("Lista limpada!");
                break;

                case "5":
                    File.WriteAllLines(filePath, shoopingList);
                    Console.WriteLine("Exportando Lista...");
                    Thread.Sleep(1000);
                    
                    Console.WriteLine("Lista exportada e salva com sucesso!");
                    return;

                default:
                    Console.WriteLine("ERRO: Opção Inválida. Tente novamente");
                break;
            }

        }

    }
}