using System;
using System.Collections.Generic;
using System.Text;
using Locadora.controladores.models;

namespace Locadora.dados
{
    class NotaFiscalDAO
    {
        public List<NotaFiscal> notasFiscais;

        private static readonly NotaFiscalDAO instance = new NotaFiscalDAO();

        static NotaFiscalDAO()
        {

        }

        public static NotaFiscalDAO Instance
        {
            get
            {
                return instance;
            }
        }

        public NotaFiscalDAO() {
            this.notasFiscais = new List<NotaFiscal>();
        }
        //Método salvar
        public Boolean Salvar(NotaFiscal notaFiscal)
        {
            if (!this.notasFiscais.Contains(notaFiscal))
            {
                this.notasFiscais.Add(notaFiscal);

                return true;
            }

            return false;
        }

        //Método buscar
        public NotaFiscal Buscar(int id)
        {

            foreach (NotaFiscal nota in notasFiscais)
            {
                if (nota.Id == id)
                {
                    return nota;
                }
            }

            return null;
        }

        //Método listar todos
        public List<NotaFiscal> Listar()
        {
            return this.notasFiscais;
        }

        //Método remover 
        public void Remover(NotaFiscal notaFiscal)
        {

            foreach (NotaFiscal n in notasFiscais)
            {
                if (n.Id == notaFiscal.Id)
                {
                    this.notasFiscais.Remove(n);
                }
            }
        }

        //Método editar
        public void Editar(NotaFiscal notaFiscal, int nDias, string formaPagamento)
        {

            foreach (NotaFiscal n in notasFiscais)
            {
                if (n.Id == notaFiscal.Id)
                {
                    n.NumeroDias = nDias;
                    n.FormaPagamento = formaPagamento; 
                    if (n.Cliente.Premium)
                    {
                        n.ValorFinal = (nDias * n.Filme.Preco - (n.Filme.Preco * 0.2));
                    }
                    else
                    {
                        n.ValorFinal = (nDias * n.Filme.Preco);
                    }

                }
            }
        }
    }
}
