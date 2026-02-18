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
        #region Atributos
        private int intTipoAhor;
        private float fltporcInt;
        #endregion

        #region Constructores
        public clsAhorro()
        {
            intNroCta = 0;
            strFecCreac = string.Empty;
            intTipoDoc = 0;
            intNroDcto = 0;
            intTipoAhor = 0;
            fltporcInt = 0;
            strTitular = string.Empty;
            fltSaldo = 0;
            rutaFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos", "ctaAhorros.txt");

        }
        public clsAhorro(int tipoDoc, int nroDoc, string titular, int valor, int tipoAhor, float porcint)
        {
            intTipoDoc = tipoDoc;
            intNroDcto = nroDoc;
            strTitular = titular;
            fltSaldo = valor;
            intTipoAhor = tipoAhor;
            fltporcInt = porcint;
        }
        #endregion

        #region propiedades
        public int TipoAhor
        {
            get { return intTipoAhor; }
            set { intTipoAhor = value; }
        }

        public float PorcIntAhor
        {
            get { return fltporcInt; }
            set { fltporcInt = value; }
        }

        #endregion

        #region Metodos publicos
        public override bool Buscar(int nroCta)
        {
            if (nroCta == 0)
                return false;

            return true;
        }
        public override bool Crear()
        {
            if (!Validar())
                return false;

            return true;
        }
        public override bool Deposito(int nroCta, float valor)
        {
            if (nroCta < 0)
                return false;

            if (valor < 0)
                return false;

            return true;
        }
        public override bool Retiro(int nroCta, float valor)
        {
            if ((nroCta <= 0) || (valor <= 0))
                return false;

            return true;
        }
        #endregion

        #region Metodos privados
        private bool Validar()
        {
            if (intTipoDoc <= 0)
            {
                strError = "El tipo de documento es incorrecto";
                return false;
            }
            if (intNroDcto <= 0)
            {
                strError = "El número de documento es incorrecto";
                return false;
            }
            if (strTitular.Trim() == "")
            {
                strError = "El titular es incorrecto";
                return false;
            }
            if (fltSaldo <= 0)
            {
                strError = "El saldo es incorrecto";
                return false;
            }
            if (intTipoAhor <= 0)
            {
                strError = "El tipo de ahorro es incorrecto";
                return false;
            }
            if (fltporcInt <= 0 || fltporcInt > 50)
            {
                strError = "El porcentaje de interes no pude ser menor a 0 ni superior a 50";
                return false;
            }

            return true;
        }
        #endregion

    }

    public class clsCorriente : clsTipo
    {
        #region Atributos
        private float fltLimSobreGiro;
        private string strRepresLeg;
        #endregion

        #region Constructores
        public clsCorriente()
        {
            intNroCta = 0;
            strFecCreac = string.Empty;
            intTipoDoc = 0;
            intNroDcto = 0;
            fltLimSobreGiro = 0;
            strRepresLeg = string.Empty;
            strTitular = string.Empty;
            fltSaldo = 0;
            rutaFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos", "ctaCorriente.txt");
        }
        public clsCorriente(int tipoDoc, int nroDoc, string titular, int valor, float LimSobreGiro, string repLeg)
        {
            intTipoDoc = tipoDoc;
            intNroDcto = nroDoc;
            strTitular = titular;
            fltSaldo = valor;
            fltLimSobreGiro = LimSobreGiro;
            strRepresLeg = repLeg;
        }
        #endregion

        #region Propiedades
        public float LimSobreGiro
        {
            get { return fltLimSobreGiro; }
            set { fltLimSobreGiro = value; }
        }
        public string Represent
        {
            get { return strRepresLeg; }
            set { strRepresLeg = value; }
        }
        #endregion

        #region Metodos publicos
        public override bool Buscar(int nroCta)
        {
            if (nroCta == 0)
                return false;

            return true;
        }
        public override bool Crear()
        {
            if (!Validar())
                return false;

            return true;
        }
        public override bool Deposito(int nroCta, float valor)
        {
            if (nroCta < 0)
                return false;

            if (valor < 0)
                return false;

            return true;
        }
        public override bool Retiro(int nroCta, float valor)
        {
            if ((nroCta <= 0) || (valor <= 0))
                return false;

            return true;
        }
        #endregion

        #region Metodos privados
        private bool Validar()
        {
            if (intTipoDoc <= 0)
            {
                strError = "El tipo de documento es incorrecto";
                return false;
            }
            if (intNroDcto <= 0)
            {
                strError = "El número de documento es incorrecto";
                return false;
            }
            if (strTitular.Trim() == "")
            {
                strError = "El titular es incorrecto";
                return false;
            }
            if (fltSaldo <= 0)
            {
                strError = "El saldo es incorrecto";
                return false;
            }
            if (fltLimSobreGiro <= 0)
            {
                strError = "El saldo es incorrecto";
                return false;
            }
            if (strRepresLeg == null) return false;

            return true;
        }
        #endregion
    }

    public class clsCDT: clsCuenta
    {
        #region Atributos
        private int intMeses;
        private float fltPorcInt;

        #endregion

        #region Constructor
        public clsCDT()
        {
            intNroCta = 0;
            strFecCreac = string.Empty;
            intTipoDoc = 0;
            intNroDcto = 0;
            intMeses = 0;
            fltPorcInt = 0;
            strTitular = string.Empty;
            fltSaldo = 0;
            rutaFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos", "ctaCDT.txt");
        }

        public clsCDT(int tipoDoc, int nroDoc, string titular, int valor, int cantMeses, float PorcInt)
        {
            intTipoDoc = tipoDoc;
            intNroDcto = nroDoc;
            strTitular = titular;
            fltSaldo = valor;
            intMeses = cantMeses;
            fltPorcInt = PorcInt;
        }
        #endregion

        #region Propiedades
        public float Valor
        {
            get { return fltSaldo; }
            set { fltSaldo = value; }
        }
        public int Meses
        {
            get { return intMeses; }
            set { intMeses = value; }
        }
        public float PorcIntCDT
        {
            get { return fltPorcInt; }
            set { fltPorcInt = value; }
        }
        #endregion

        #region Metodos privados
        private bool Validar()
        {
            if (strFecCreac == null) return false;
            if (intTipoDoc <= 0) return false;
            if (intNroDcto <= 0) return false;
            if (strTitular == null) return false;
            if (fltSaldo <= 0) return false;
            if (intMeses <= 0) return false;
            if (fltPorcInt <= 0) return false;

            return true;
        }
        #endregion

        #region Metodos publicos
        public override bool Buscar(int nroCta)
        {
            if (nroCta == 0)
                return false;

            return true;
        }
        public override bool Crear()
        {
            if (!Validar())
                return false;

            return true;
        }
        #endregion
    }
}
