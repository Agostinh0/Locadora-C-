using System;
using System.Collections.Generic;
using System.Text;
using Locadora.dados;
using Locadora.controladores.models;

namespace Locadora.controladores
{
    class ControladorCliente
    {
        public ClienteDAO clienteDAO;

        //Singleton
        private static readonly ControladorCliente instance = new ControladorCliente();
        
        static ControladorCliente()
        {

        }

        public ControladorCliente()
        {
            this.clienteDAO = ClienteDAO.Instance;
        }

        public static ControladorCliente Instance
        {
            get
            {
                return instance;
            }
        }

        public Boolean Salvar(Cliente cliente) {
            if (cliente == null)
            {
                throw new ArgumentNullException();
            }
            else {
                this.clienteDAO.Salvar(cliente);
                return true;
            }
        }

        public Cliente Buscar(string cpf) {
            if (cpf == null) {
                throw new ArgumentNullException();
            }
            else {
                return this.clienteDAO.Buscar(cpf);
            }
        }

        public Cliente Pesquisar(string cpf) {
            if (cpf == null)
            {
                throw new ArgumentNullException();
            }
            else {
                return this.clienteDAO.Pesquisar(cpf);
            }
        }

        public List<Cliente> Listar() {
            return this.clienteDAO.Listar();
        }

        public void Remover(Cliente cliente) {
            if (cliente == null)
            {
                throw new ArgumentNullException();
            }
            else {
                this.clienteDAO.Remover(cliente);
            }
        }

        public void Editar(Cliente cliente, string nome, Endereco endereco, Boolean premium) {
            if (cliente == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.clienteDAO.Editar(cliente, nome, endereco, premium);
            }
        }
    }
}
