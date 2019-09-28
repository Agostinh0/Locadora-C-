using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.controladores.models
{
    class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public DateTime Lancamento { get; set; }
        public double Preco { get; set; }
        public string Genero { get; set; }
        public string Sinopse { get; set; }

        public Filme(string nome, string diretor, DateTime lancamento, double preco, string genero, string sinopse)
        {
            Random random = new Random();
            this.Id = random.Next(1000, 1000000);
            this.Nome = nome;
            this.Diretor = diretor;
            this.Lancamento = lancamento;
            this.Preco = preco;
            this.Genero = genero;
            this.Sinopse = sinopse;
        }

        public override string ToString()
        {
            string texto = "-----------------------------";
            texto += "\nID: " + this.Id;
            texto += "\nNome: " + this.Nome;
            texto += "\nDiretor: " + this.Diretor;
            texto += "\nLancamento: " + this.Lancamento;
            texto += "\nPreco: R$" + this.Preco;
            texto += "\nGenero: " + this.Genero;
            texto += "\nSinopse: " + this.Sinopse;
            texto += "\n-----------------------------";
            return texto;
        }

    }
}
