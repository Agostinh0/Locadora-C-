using System;
using System.Collections.Generic;
using System.Text;
using Locadora.dados;
using Locadora.controladores.models;

namespace Locadora.controladores
{
    class ControladorNotaFiscal
    {
        public NotaFiscalDAO notaFiscalDAO;

        //Singleton
        private static readonly ControladorNotaFiscal instance = new ControladorNotaFiscal();

        static ControladorNotaFiscal()
        {

        }

        public ControladorNotaFiscal()
        {
            this.notaFiscalDAO = NotaFiscalDAO.Instance;
        }

        public static ControladorNotaFiscal Instance
        {
            get
            {
                return instance;
            }
        }

        public Boolean Salvar(NotaFiscal notaFiscal)
        {
            if (notaFiscal == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.notaFiscalDAO.Salvar(notaFiscal);
                return true;
            }
        }

        public NotaFiscal Buscar(int id) {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            else {
                return notaFiscalDAO.Buscar(id);
            }
        }

        public List<NotaFiscal> Listar()
        {
            return this.notaFiscalDAO.Listar();
        }

        public void Remover(NotaFiscal notaFiscal)
        {
            if (notaFiscal == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.notaFiscalDAO.Remover(notaFiscal);
            }
        }

        public void Editar(NotaFiscal notaFiscal, int nDias, string formaPagamento)
        {
            if (notaFiscal == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                this.notaFiscalDAO.Editar(notaFiscal, nDias, formaPagamento);
            }
        }
    }
}
