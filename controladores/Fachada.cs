using System;
using System.Collections.Generic;
using System.Text;
using Locadora.controladores.models;

namespace Locadora.controladores
{
    class Fachada
    {
        private readonly ControladorCliente controladorCliente;
        private readonly ControladorFilme controladorFilme;
        private readonly ControladorNotaFiscal controladorNotaFiscal;
        private static readonly Fachada instance = new Fachada();

        static Fachada() {}
        public static Fachada Instance{ get {return instance;} }

        public Fachada()
        {
            this.controladorCliente = ControladorCliente.Instance;
            this.controladorFilme = ControladorFilme.Instance;
            this.controladorNotaFiscal = ControladorNotaFiscal.Instance;
        }

        //Cliente
        public Boolean SalvarCliente(Cliente cliente) {
            return controladorCliente.Salvar(cliente);
        }

        public List<Cliente> ListarClientes() {
            return controladorCliente.Listar();
        }

        public Cliente BuscarCliente(string cpf) {
            return controladorCliente.Buscar(cpf);
        }

        public Cliente PesquisarCliente(string cpf) {
            return controladorCliente.Pesquisar(cpf);
        }

        public void RemoverCliente(Cliente cliente) {
            this.controladorCliente.Remover(cliente);
        }

        public void EditarCliente(Cliente cliente, string nome, Endereco endereco, Boolean premium) {
            this.controladorCliente.Editar(cliente, nome, endereco, premium);
        }

        //Filme
        public Boolean SalvarFilme(Filme filme)
        {
            return controladorFilme.Salvar(filme);
        }

        public string ListarFilmes()
        {
            return controladorFilme.Listar();
        }

        public Filme BuscarFilme(int id) {
            return controladorFilme.Buscar(id);
        }
        public void RemoverFilme(Filme filme)
        {
            this.controladorFilme.Remover(filme);
        }

        public void EditarFilme(Filme filme, string nome, string diretor, DateTime lancamento, double preco,
            string genero, string sinopse)
        {
            this.controladorFilme.Editar(filme, nome, diretor, lancamento, preco, genero, sinopse);
        }

        //Nota Fiscal
        public Boolean SalvarNotaFiscal(NotaFiscal notaFiscal)
        {
            return controladorNotaFiscal.Salvar(notaFiscal);
        }

        public List<NotaFiscal> ListarNotasFiscais()
        {
            return controladorNotaFiscal.Listar();
        }

        public NotaFiscal BuscarNotaFiscal(int id) {
            return controladorNotaFiscal.Buscar(id);
        }
        public void RemoverNotaFiscal(NotaFiscal notaFiscal)
        {
            this.controladorNotaFiscal.Remover(notaFiscal);
        }

        public void EditarNotaFiscal(NotaFiscal notaFiscal, int nDias, string formaPagamento)
        {
            this.controladorNotaFiscal.Editar(notaFiscal, nDias, formaPagamento);
        }

    }
}