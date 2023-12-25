using ListaDeCompra;
using ListaDeCompra.Models;
using ListaDeCompra.Repositories;

OperacaoInicial();


void OperacaoInicial()
{
  Console.ForegroundColor = ConsoleColor.Blue;
  Console.WriteLine("Informe a operação desejada");
  Console.WriteLine("1 - Criar Lista");
  Console.WriteLine("2 - Editar Lista");
  Console.WriteLine("3 - Obter Listas");
  Console.WriteLine("0 - Sair");
  Console.ForegroundColor = ConsoleColor.White;

  try
  {
    int operacaoDesejadaInicial = int.Parse(Console.ReadLine());

    while(operacaoDesejadaInicial >= 0 && operacaoDesejadaInicial <= 3)
    {
      switch(operacaoDesejadaInicial)
      {
        case 0:
          Console.Clear();
          Console.WriteLine("Processo Finalizado!");
          break;
        case 1:
          Console.Clear();
          OperacaoCriarLista();
          break;
        case 2:
          Console.Clear();
          OperacaoEditarLista();
          break;
        case 3:
          Console.Clear();
          OperacaoObterListas();
          break;
        default:
          Console.Clear();
          Console.WriteLine("Valor informado é invalido!");
          Thread.Sleep(1000);
          OperacaoInicial();
          break;
      }
      Console.Clear();
    }
  } catch (Exception ex)
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Algo deu errado tente novamente!");
    Console.ForegroundColor = ConsoleColor.White;
    OperacaoInicial();
  }
}

void OperacaoCriarLista()
{
  Console.Write("Nome da Lista: ");
  string nome = Console.ReadLine().Trim();
  Console.Write("Data desejada da compra: ");
  var data = Console.ReadLine();

  var listaCompra = new ListaCompra(nome, DateTime.Parse(data));
  ListaRepository.Adicionar(listaCompra);

  OperacaoInicial();
}

void OperacaoEditarLista()
{
  int operacaoDesejadaEditarLista = -1;
  while(!(operacaoDesejadaEditarLista >= 0 && operacaoDesejadaEditarLista <= 2))
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Informe a operação desejada");
    Console.WriteLine("1 - Adicionar produtos");
    Console.WriteLine("2 - Editar produtos");
    Console.WriteLine("0 - Voltar para Menu principal");
    Console.ForegroundColor = ConsoleColor.White;
    
    operacaoDesejadaEditarLista = int.Parse(Console.ReadLine());

    switch(operacaoDesejadaEditarLista)
    {
      case 0:
        Console.Clear();
        OperacaoInicial();
        break;
      case 1:
        Console.Clear();
        OperacaoAdicionarProduto();
        break;
      case 2:
        Console.Clear();
        OperacaoEditarProduto();
        break;
      default:
        Console.Clear();
        Console.WriteLine("Valor informado é invalido!");
        Thread.Sleep(3000);
        break;
    }
  }
}

string MenuAdicionarProduto()
{
  Console.ForegroundColor = ConsoleColor.Blue;
  Console.Write("Adicionar outro produto? (S - Sim, N - Não): ");
  Console.ForegroundColor = ConsoleColor.White;
  string adicionarProduto = ValidaAdicionarProduto(Console.ReadLine().ToUpper());
  return adicionarProduto;
}

void OperacaoAdicionarProduto()
{
  OperacaoObterListas();
  Console.Write("Informe o nome da Lista: ");

  var nomeListaDesejada = Console.ReadLine();
  var listaEscolhida = ListaRepository.ObterTodos().FirstOrDefault(x => x.Nome.ToLower() == nomeListaDesejada.ToLower());
  
  if (listaEscolhida == null)
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Lista selecionada não existe!");
    Console.ForegroundColor = ConsoleColor.White;
    OperacaoAdicionarProduto();
  }

  Console.Write("Nome do produto: ");
  string nomeProduto = Console.ReadLine();
  Console.Write("Categoria do produto: (0 - Mercado, 1 - Escritório, 2 Manutenção): ");
  string categoriaProduto = ValidaCategoriaProduto(Console.ReadLine());

  var produto = new Produto(nomeProduto, Enum.Parse<ProdutoCategoria>(categoriaProduto));
  listaEscolhida.AdicionarProduto(produto);

  string adicionarProduto = MenuAdicionarProduto();
 
  while (adicionarProduto != "N")
  {
    Console.Write("Nome do produto: ");
    nomeProduto = Console.ReadLine();
    Console.Write("Categoria do produto: (0 - Mercado, 1 - Escritório, 2 Manutenção): ");
    categoriaProduto = ValidaCategoriaProduto(Console.ReadLine());

    produto = new Produto(nomeProduto, Enum.Parse<ProdutoCategoria>(categoriaProduto));
    listaEscolhida.AdicionarProduto(produto);
    
    adicionarProduto = MenuAdicionarProduto();
  }
  OperacaoSalvarLista(listaEscolhida);
  OperacaoInicial();

}

void OperacaoEditarProduto()
{
  OperacaoObterListas();
  Console.Write("Informe o nome da Lista: ");

  var nomeListaDesejada = Console.ReadLine();
  var listaEscolhida = ListaRepository.ObterTodos().FirstOrDefault(x => x.Nome.ToLower() == nomeListaDesejada.ToLower());
  
  if (listaEscolhida == null)
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Lista selecionada não existe!");
    Console.ForegroundColor = ConsoleColor.White;
    OperacaoAdicionarProduto();
  }

  Console.Write("Nome do produto: ");
  string nomeProduto = Console.ReadLine();
  Console.Write("Categoria do produto: (0 - Mercado, 1 - Escritório, 2 Manutenção): ");
  string categoriaProduto = ValidaCategoriaProduto(Console.ReadLine());

  var produto = new Produto(nomeProduto, Enum.Parse<ProdutoCategoria>(categoriaProduto));
  listaEscolhida.AdicionarProduto(produto);

  string adicionarProduto = MenuAdicionarProduto();
 
  while (adicionarProduto != "N")
  {
    Console.Write("Nome do produto: ");
    nomeProduto = Console.ReadLine();
    Console.Write("Categoria do produto: (0 - Mercado, 1 - Escritório, 2 Manutenção): ");
    categoriaProduto = ValidaCategoriaProduto(Console.ReadLine());

    produto = new Produto(nomeProduto, Enum.Parse<ProdutoCategoria>(categoriaProduto));
    listaEscolhida.AdicionarProduto(produto);
    
    adicionarProduto = MenuAdicionarProduto();
  }
  OperacaoSalvarLista(listaEscolhida);
  OperacaoInicial();

}

void OperacaoObterListas()
{
  Console.WriteLine($"- Listas de compra -");
  var listas = ListaRepository.ObterTodos();
  

  if (listas == null || listas.Count == 0)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Não há listas no momento, por favor crie uma!");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine();
    OperacaoCriarLista();
  } else
  {
    Console.ForegroundColor = ConsoleColor.Green;
    for (int i = 0; i < listas.Count; i++)
    {
      Console.WriteLine($"{i + 1}: {listas[i].Nome} - {listas[i].DataDesejadaDaCompra}");
    }
    Console.WriteLine();
    OperacaoInicial();
  }
  Console.ForegroundColor = ConsoleColor.White;
}


string ValidaCategoriaProduto(string categoriaProduto)
{
  while (categoriaProduto != "0" && categoriaProduto != "1" && categoriaProduto != "2")
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Valor ({categoriaProduto}) Informado é invalido!");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Categoria do produto: (0 - Mercado, 1 - Escritório, 2 Manutenção): ");
    Console.ForegroundColor = ConsoleColor.White;
    
    categoriaProduto = Console.ReadLine();
  }
  return categoriaProduto;
}

string ValidaAdicionarProduto(string adicionarProduto)
{
while(adicionarProduto != "S" && adicionarProduto != "N")
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Valor ({adicionarProduto}) Informado é invalido!");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Adicionar outro produto? (S - Sim, N - Não): ");
    Console.ForegroundColor = ConsoleColor.White;
    
    adicionarProduto = Console.ReadLine().ToUpper();
  }
  return adicionarProduto;
}

void OperacaoSalvarLista(ListaCompra listaCompra)
{
  try
  {
    StreamWriter sw = new StreamWriter($"./{listaCompra.Nome.Trim()}.txt");
    sw.WriteLine($"Nome Lista: {listaCompra.Nome.Trim()}");
    sw.WriteLine($"Data prevista compra: {listaCompra.DataDesejadaDaCompra}");
    sw.WriteLine($"Produtos\n----");
    listaCompra.Produtos.ForEach(p => {
      sw.WriteLine(p);
    });
    sw.WriteLine($"----\n");
    sw.Close();
  }
  catch(Exception ex)
  {
    Console.WriteLine("Exception: " + ex.Message);
  }
  finally
  {
    Console.WriteLine("Executing finally block.");
  }

  Console.WriteLine("Lista criada!");
  Thread.Sleep(3000);
}




