using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompra.Models
{

  public enum ProdutoCategoria
  {
    Mercado,
    Escritorio,
    Manutencao
  }

  public class Produto
  {
    public string Nome { get; private set; }
    public ProdutoCategoria Categoria { get; private set; }
    public decimal ValorPago { get; private set; }
    public bool Comprado { get; private set; } = false;

    public Produto(string nome, ProdutoCategoria categoria)
    {
      Nome = nome;
      Categoria = categoria;
    }

    public void InformarValorPago(decimal valorPago)
    {
      ValorPago = valorPago;
      Comprado = true;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      if (Comprado)
        sb.Append($"{Nome}, categória: {Categoria}, {ValorPago.ToString("C")}, comprado: Sim");
      sb.Append($"{Nome}, categória: {Categoria}, {ValorPago.ToString("C")}, comprado: Não");

      return sb.ToString(); 
    }

  }
}