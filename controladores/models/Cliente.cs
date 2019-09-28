using System;
using System.Collections.Generic;
using System.Text;
using Locadora.dados;

namespace Locadora.controladores.models
{
    class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }
        public Boolean Premium { get; set; }
        public List<Filme> Filmes { get; set; }

        

        public Cliente(string nome, string cpf, Endereco endereco, Boolean premium) {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Endereco = endereco;
            this.Premium = premium;
            this.Filmes = new List<Filme>();
        }

        public override string ToString()
        {
            string texto = "Nome: " + this.Nome;
            texto += "\nCPF: " + this.Cpf;
            texto += "\nEndereço: " + this.Endereco.ToString();
            texto += "\nPremium: " + this.Premium;
            return texto;
        }

        public void Alugar(Cliente cliente, Filme filme) {

            if (!this.Filmes.Contains(filme))
            {
                NotaFiscal nota = new NotaFiscal(cliente, filme, 3, "Dinheiro");
                NotaFiscalDAO.Instance.Salvar(nota);
                this.Filmes.Add(filme);
            }
            else {
                Console.WriteLine("Filme já alugado");
            }
        }

    }
}
