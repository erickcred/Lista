using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeCompra.Models
{
  public class ListaCompra
  {
    public readonly string Nome;
    public DateTime DataDesejadaDaCompra { get; set; }
    public List<Produto> Produtos { get; } = new();

    public ListaCompra(string nome, DateTime dataDesejadaDaCompra)
    {
      Nome = nome;
      DataDesejadaDaCompra = dataDesejadaDaCompra;
    }

    public void AdicionarProduto(Produto produto)
    {
      Produtos.Add(produto);
    }
  }
}