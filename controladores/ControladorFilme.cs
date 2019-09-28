using System;
using System.Collections.Generic;
using System.Text;
using Locadora.controladores.models;
using Locadora.dados;


namespace Locadora.controladores
{
    class ControladorFilme
    {
        public FilmeDAO filmeDAO;

        //Singleton
        private static readonly ControladorFilme instance = new ControladorFilme();

        static ControladorFilme()
        {

        }

        public ControladorFilme()
        {
            this.filmeDAO = FilmeDAO.Instance;
        }

        public static ControladorFilme Instance
        {
            get
            {
                return instance;
            }
        }

        public Boolean Salvar(Filme filme)
        {
            if (filme == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.filmeDAO.Salvar(filme);
                return true;
            }
        }

        public Filme Buscar(string titulo) {
            if (titulo.Equals("")) {
                throw new ArgumentNullException();
            }
            else {
                return this.filmeDAO.Buscar(titulo);
            }
        }
           
        public string Listar()
        {
            return this.filmeDAO.Listar();
        }

        public void Remover(Filme filme)
        {
            if (filme == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.filmeDAO.Remover(filme);
            }
        }

        public void Editar(Filme filme, string nome, string diretor, DateTime lancamento, double preco,
            string genero, string sinopse)
        {
            if (filme == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.filmeDAO.Editar(filme, nome, diretor, lancamento, preco, genero, sinopse);
            }
        }
    }
}
