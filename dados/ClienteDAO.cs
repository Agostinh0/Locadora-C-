using System;
using System.Collections.Generic;
using System.Text;
using Locadora.controladores.models;
using System.Linq;

namespace Locadora.dados
{
    class ClienteDAO
    {
        public List<Cliente> clientes;
        private static readonly ClienteDAO instance = new ClienteDAO();

        static ClienteDAO() {

        }

        public ClienteDAO() {
            this.clientes = new List<Cliente>();
        }

        public static ClienteDAO Instance
        {
            get
            {
                return instance;
            }
        }

        //Método salvar
        public Boolean Salvar(Cliente cliente) {
            if (!this.clientes.Contains(cliente)) {
                this.clientes.Add(cliente);

                return true;
            }

            return false;
        }

        //Método buscar
        public Cliente Buscar(string cpf) {

            foreach (Cliente cliente in clientes) {
                if (cliente.Cpf.Equals(cpf)) {
                    return cliente;
                }
            }

            return null;
        }

        //Método listar todos
        public List<Cliente> Listar() {
            return this.clientes;
        }

        //Método remover 
        public Boolean Remover(Cliente cliente) {

            for (int i = 0; i < clientes.Count; i++) {
                if (clientes.Contains(cliente))
                {
                    if (clientes.ElementAt(i).Filmes.Count == 0)
                    {
                        this.clientes.RemoveAt(i);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else {
                    return false;
                }
            }

            return false;

        }

        //Método editar
        public void Editar(Cliente cliente, string nome, Endereco endereco, Boolean premium) {

            foreach (Cliente c in clientes) {
                if (c.Cpf.Equals(cliente.Cpf)) {
                    c.Nome = nome;
                    c.Endereco = endereco;
                    c.Premium = premium;
                }
            }
        }

        //Tentativa de criar um método Buscar usando LINQ
        public Cliente Pesquisar(string cpf) {

            IEnumerable<Cliente> query = from Cliente cliente in clientes
                        where cliente.Cpf == cpf
                        select cliente;

            foreach (Cliente cliente in query)
            {
                return cliente;
            }

            return null;
        }
    }
}
