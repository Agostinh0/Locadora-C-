using System;
using System.Collections.Generic;
using System.Text;
using Locadora.controladores.models;
using System.Linq;
namespace Locadora.dados
{
    class FilmeDAO
    {
        public List<Filme> filmes;

        private static readonly FilmeDAO instance = new FilmeDAO();

        static FilmeDAO()
        {

        }

        public FilmeDAO()
        {
            this.filmes = new List<Filme>();
        }

        public static FilmeDAO Instance
        {
            get
            {
                return instance;
            }
        }

        //Método salvar
        public Boolean Salvar(Filme filme)
        {
            if (!this.filmes.Contains(filme))
            {
                this.filmes.Add(filme);

                return true;
            }

            return false;
        }

        //Método buscar
        public Filme Buscar(string titulo)
        {

            foreach (Filme filme in filmes)
            {
                if (filme.Nome == titulo)
                {
                    return filme;
                }
            }

            return null;
        }

        //Método listar todos
        public string Listar()
        {
            foreach (Filme filme in filmes) {
                return filme.ToString();
            }

            return null;
        }

        //Método remover 
        public void Remover(Filme filme)
        {

            for (int i = 0; i < filmes.Count; i++) {
                if (filmes.ElementAt(i).Nome.Equals(filme.Nome)) { 
                    filmes.RemoveAt(i);
                }
            }
        }

        //Método editar
        public void Editar(Filme filme, string nome, string diretor, DateTime lancamento, double preco, 
            string genero, string sinopse)
        {

            foreach (Filme f in filmes)
            {
                if (f.Id == filme.Id)
                {
                    f.Nome = nome;
                    f.Diretor = diretor;
                    f.Lancamento = lancamento;
                    f.Preco = preco;
                    f.Genero = genero;
                    f.Sinopse = sinopse;
                }
            }
        }
    }
}
