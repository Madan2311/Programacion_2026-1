using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libCuentaBanc;

namespace libTiposCtas
{
    public class clsAhorro:clsTipo
    {
        #region Constructores
        public clsAhorro()
        {
            intNroCta = 0;
            strFecCreac = string.Empty;
            intTipoDoc = 0;
            intNroDcto = 0;
            strTitular = string.Empty;
            fltSaldo = 0;
            rutaFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos", "ctaAhorros.txt");

        }
        public clsAhorro(int tipoDoc, int nroDoc, string titular, int tipoAhor, float porcint)
        {
            intTipoDoc = tipoDoc;
            intNroDcto = nroDoc;
            strTitular = titular;
            intTipoAhor = tipoAhor;
            fltporcInt = porcint;
        }
        #endregion

        #region Atributos
        private int intTipoAhor;
        private float fltporcInt;
        #endregion

        #region propiedades

        #endregion

        #region Metodos publicos
        public override bool Buscar(int nroCta)
        {
            throw new NotImplementedException();
        }
        public override bool Crear()
        {
            throw new NotImplementedException();
        }
        public override bool Deposito(int nroCta, float valor)
        {
            throw new NotImplementedException();
        }
        public override bool Retiro(int nroCta, float valor)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Metodos privados

        #endregion
        
    }
}
