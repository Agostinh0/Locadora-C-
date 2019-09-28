using System;
using System.Collections.Generic;
using System.Text;
using Locadora.controladores.models;

namespace Locadora.controladores.models
{
    class NotaFiscal
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Filme Filme { get; set; }
        public double NumeroDias { get; set; }
        public string FormaPagamento { get; set; }
        public double ValorFinal { get; set; }

        public NotaFiscal(Cliente cliente, Filme filme, double nDias, string formaPagamento) {
            Random random = new Random();
            this.Id = random.Next(1000, 1000000);
            this.Cliente = cliente;
            this.Filme = filme;
            this.NumeroDias = nDias;
            this.FormaPagamento = formaPagamento;
            if (this.Cliente.Premium) {
                this.ValorFinal = (nDias * filme.Preco - (filme.Preco * 0.2));
            }else {
                    this.ValorFinal = (nDias * filme.Preco);
            }
        }

        public override string ToString()
        {
            string texto = "ID: " + this.Id;
            texto += "\nFilme: " + this.Filme.Nome;
            texto += "\nCliente: " + this.Cliente.Nome;
            texto += "\nCPF: " + this.Cliente.Cpf;
            texto += "\nQuantidade de dias: " + this.NumeroDias;
            texto += "\nValor a pagar: " + this.ValorFinal;
            return texto;

        }

    }
}
