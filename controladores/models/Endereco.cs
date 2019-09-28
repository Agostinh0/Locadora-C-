using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.controladores.models
{
    class Endereco
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public Endereco(string logradouro, int numero, string complemento, string cep, string bairro, string cidade) {
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Cep = cep;
            this.Bairro = bairro;
            this.Cidade = cidade;
        }

        public override string ToString()
        {
            string texto = Logradouro + " n° " + Numero + " - " + Complemento;
            texto += "\n CEP: " + Cep + " " + Bairro + ", " + Cidade;

            return texto;
        }
    }
}
