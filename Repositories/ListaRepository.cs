using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeCompra.Models;

namespace ListaDeCompra.Repositories
{
  public static class ListaRepository
  {
    private static List<ListaCompra> _listaCompras = new();

    public static void Adicionar(ListaCompra listaCompra)
    {
      _listaCompras.Add(listaCompra);
    }

    public static List<ListaCompra> ObterTodos()
    {
      return _listaCompras;
    }


  }
}