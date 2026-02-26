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
        public clsAhorro(int tipoDoc, int nroDoc, string titular, float valor, int tipoAhor, float porcint)
        {
            intTipoDoc = tipoDoc;
            intNroDcto = nroDoc;
            strTitular = titular;
            fltSaldo = valor;
            intTipoAhor = tipoAhor;
            fltporcInt = porcint;
            rutaFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos", "ctaAhorros.txt");
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
            try
            {
                if (nroCta <= 0)
                {
                    strError = "Número de cuenta nó válido";
                    return false;
                }
                clsGenerales og = new clsGenerales();
                List<string> datos = og.leerArchivo(rutaFile, nroCta);
                if (datos.Count <= 0 )
                {
                    strError = "No se encontró la cuenta de ahorros #" + nroCta;
                    og = null;
                    return false;
                }
                strFecCreac = datos[1];
                intTipoDoc = int.Parse(datos[2]);
                intNroDcto = int.Parse(datos[3]);
                strTitular = datos[4];
                fltSaldo = float.Parse(datos[5]);
                intTipoAhor = int.Parse(datos[6]);
                fltporcInt = float.Parse(datos[7]);

                return true;
            }
            catch
            {

                strError = "Error en consultar la cuenta de ahorros";
                return false;
            }
        }
        public override bool Crear()
        {
            if (!Validar())
                return false;
            try
            {
                clsGenerales og = new clsGenerales();
                intNroCta = og.UltimoId(rutaFile) + 1;
                if (intNroCta <= 0)
                {
                    strError = "Error en consultar cuenta de ahorros";
                    return false;
                }
                strFecCreac = DateTime.Now.ToShortDateString();
                string rgtro = intNroCta + ":" + strFecCreac + ":" + intTipoDoc + ":" + intNroDcto + ":" +
                    strTitular + ":" + fltSaldo.ToString() + ":" + intTipoAhor + ":" + fltporcInt;

                StreamWriter grabar = new StreamWriter(rutaFile, true);
                grabar.WriteLine(rgtro);
                grabar.Close();
                return true;
            }
            catch (Exception)
            {

                strError = "Error en grabar";
                return false;
            }
        }
        public override bool Deposito(int nroCta, float valor)
        {
            bool encontrado = false;
            float saldoAct, newSaldo;

            try
            {
                List<string> lineas = File.ReadAllLines(rutaFile).ToList();
                for (int i = 0; i < lineas.Count(); i++)
                {
                    string[] campos = lineas[i].Split(':');
                    if (campos.Length > 0 && campos[0].Equals(nroCta.ToString()))
                    {
                        saldoAct = Convert.ToSingle(campos[5]);
                        newSaldo = saldoAct + valor;
                        string newRgro = campos[0] + ":" + campos[1] + ":" + campos[2] + ":" + campos[3] + ":" +
                            campos[4] + ":" + newSaldo + ":" + campos[6] + ":" + campos[7];
                        lineas[i] = newRgro;
                        File.WriteAllLines(rutaFile, lineas);
                        encontrado = true;
                        break;
                    }
                }
                if (!encontrado)
                {
                    strError = "No se emcontró la cuenta #" + nroCta;
                }
                return encontrado;
            }
            catch (Exception err)
            {

                strError = err.Message;
                return false;
            }
        }
        public override bool Retiro(int nroCta, float valor)
        {
            bool encontrado = false;
            float saldoAct, newSaldo;

            try
            {
                List<string> lineas = File.ReadAllLines(rutaFile).ToList();
                for (int i = 0; i < lineas.Count(); i++)
                {
                    string[] campos = lineas[i].Split(':');
                    if (campos.Length > 0 && campos[0].Equals(nroCta.ToString()))
                    {
                        saldoAct = Convert.ToSingle(campos[5]);
                        if (saldoAct >= valor)
                        {
                            newSaldo = saldoAct - valor;
                            string newRgro = campos[0] + ":" + campos[1] + ":" + campos[2] + ":" + campos[3] + ":" +
                                campos[4] + ":" + newSaldo + ":" + campos[6] + ":" + campos[7];
                            lineas[i] = newRgro;
                            File.WriteAllLines(rutaFile, lineas);
                            encontrado = true;
                            break;
                        }
                        else
                            strError = "Saldo insuficiente en la cuenta #" + nroCta;
                    }
                }
                if (!encontrado)
                {
                    strError = "No se emcontró la cuenta #" + nroCta;
                }
                return encontrado;
            }
            catch (Exception err)
            {

                strError = err.Message;
                return false;
            }
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
        public clsCorriente(int tipoDoc, int nroDoc, string titular, float valor, float LimSobreGiro, string repLeg)
        {
            intTipoDoc = tipoDoc;
            intNroDcto = nroDoc;
            strTitular = titular;
            fltSaldo = valor;
            fltLimSobreGiro = LimSobreGiro;
            strRepresLeg = repLeg;
            rutaFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos", "ctaCorriente.txt");
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
            try
            {
                if (nroCta <= 0)
                {
                    strError = "Número de cuenta nó válido";
                    return false;
                }
                clsGenerales og = new clsGenerales();
                List<string> datos = og.leerArchivo(rutaFile, nroCta);
                if (datos.Count <= 0)
                {
                    strError = "No se encontró la cuenta corriente #" + nroCta;
                    og = null;
                    return false;
                }
                strFecCreac = datos[1];
                intTipoDoc = int.Parse(datos[2]);
                intNroDcto = int.Parse(datos[3]);
                strTitular = datos[4];
                fltSaldo = float.Parse(datos[5]);
                fltLimSobreGiro = float.Parse(datos[6]);
                strRepresLeg = datos[7];

                return true;
            }
            catch
            {

                strError = "Error en consultar la cuenta corriente";
                return false;
            }
        }
        public override bool Crear()
        {
            if (!Validar())
                return false;
            try
            {
                clsGenerales og = new clsGenerales();
                intNroCta = og.UltimoId(rutaFile) + 1;
                if (intNroCta <= 0)
                {
                    strError = "Error en consultar cuenta corriente";
                    return false;
                }
                strFecCreac = DateTime.Now.ToShortDateString();
                string rgtro = intNroCta + ":" + strFecCreac + ":" + intTipoDoc + ":" + intNroDcto + ":" +
                    strTitular + ":" + fltSaldo.ToString() + ":" + fltLimSobreGiro + ":" + strRepresLeg;

                StreamWriter grabar = new StreamWriter(rutaFile, true);
                grabar.WriteLine(rgtro);
                grabar.Close();
                return true;
            }
            catch (Exception)
            {

                strError = "Error en grabar";
                return false;
            }
        }
        public override bool Deposito(int nroCta, float valor)
        {
            bool encontrado = false;
            float saldoAct, newSaldo;

            try
            {
                List<string> lineas = File.ReadAllLines(rutaFile).ToList();
                for (int i = 0; i < lineas.Count(); i++)
                {
                    string[] campos = lineas[i].Split(':');
                    if (campos.Length > 0 && campos[0].Equals(nroCta.ToString()))
                    {
                        saldoAct = Convert.ToSingle(campos[5]);
                        newSaldo = saldoAct + valor;
                        string newRgro = campos[0] + ":" + campos[1] + ":" + campos[2] + ":" + campos[3] + ":" +
                            campos[4] + ":" + newSaldo + ":" + campos[6] + ":" + campos[7];
                        lineas[i] = newRgro;
                        File.WriteAllLines(rutaFile, lineas);
                        encontrado = true;
                        break;
                    }
                }
                if (!encontrado)
                {
                    strError = "No se emcontró la cuenta #" + nroCta;
                }
                return encontrado;
            }
            catch (Exception err)
            {

                strError = err.Message;
                return false;
            }
        }
        public override bool Retiro(int nroCta, float valor)
        {
            bool encontrado = false;
            float saldoAct, newSaldo;

            try
            {
                List<string> lineas = File.ReadAllLines(rutaFile).ToList();
                for (int i = 0; i < lineas.Count(); i++)
                {
                    string[] campos = lineas[i].Split(':');
                    if (campos.Length > 0 && campos[0].Equals(nroCta.ToString()))
                    {
                        saldoAct = Convert.ToSingle(campos[5]);
                        if (saldoAct >= valor)
                        {
                            newSaldo = saldoAct - valor;
                            string newRgro = campos[0] + ":" + campos[1] + ":" + campos[2] + ":" + campos[3] + ":" +
                                campos[4] + ":" + newSaldo + ":" + campos[6] + ":" + campos[7];
                            lineas[i] = newRgro;
                            File.WriteAllLines(rutaFile, lineas);
                            encontrado = true;
                            break;
                        }
                        else
                            strError = "Saldo insuficiente en la cuenta #" + nroCta;
                    }
                }
                if (!encontrado)
                {
                    strError = "No se emcontró la cuenta #" + nroCta;
                }
                return encontrado;
            }
            catch (Exception err)
            {

                strError = err.Message;
                return false;
            }
        }
        #endregion

        #region Metodos privados
        private bool Validar()
        {
            if (intTipoDoc <= 0)
            {
                strError = "El tipo de documento no es valido";
                return false;
            }

            if (intNroDcto <= 0)
            {
                strError = "El numero de cuenta no es valido";
                return false;
            }
            if (strTitular.Trim() == " ")
            {
                strError = "El titular es incorrecto";
                return false;
            }
            if (fltSaldo < -fltLimSobreGiro)
            {
                strError = "El saldo supera el limite de sobregiros ";
                return false;
            }
            if (fltLimSobreGiro <= 0)
            {
                strError = "El limite de sobregiro no es valido";
                return false;
            }
            if (strRepresLeg.Trim() == " ")
            {
                strError = "El representante legal no es valido";
                return false;
            }

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

        public clsCDT(int tipoDoc, int nroDoc, string titular, float valor, int cantMeses, float PorcInt)
        {
            intTipoDoc = tipoDoc;
            intNroDcto = nroDoc;
            strTitular = titular;
            fltSaldo = valor;
            intMeses = cantMeses;
            fltPorcInt = PorcInt;
            rutaFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos", "ctaCDT.txt");
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
            if (intTipoDoc <= 0)
            {
                strError = "El tipo de documento no es valido";
                return false;
            }
            if (intNroDcto <= 0)
            {
                strError = "El numero de cuenta no es valido";
                return false;
            }
            if (strTitular.Trim() == " ")
            {
                strError = "El titular es incorrecto";
                return false;
            }
            if (fltSaldo <= 0)
            {
                strError = "El saldo es un valor incorrecto ";
                return false;
            }
            if (intMeses <= 0)
            {
                strError = "La cantidad de meses es incorrecto";
                return false;
            }
            if (fltPorcInt <= 0 || fltPorcInt > 50)
            {
                strError = "El porcentaje de intres de CDT no es valido, debe ser menor al 50% y mayor a 0";
            }

            return true;
        }
        #endregion

        #region Metodos publicos
        public override bool Buscar(int nroCta)
        {
            try
            {
                if (nroCta <= 0)
                {
                    strError = "Número de cuenta nó válido";
                    return false;
                }
                clsGenerales og = new clsGenerales();
                List<string> datos = og.leerArchivo(rutaFile, nroCta);
                if (datos.Count <= 0)
                {
                    strError = "No se encontró la cuenta CDT #" + nroCta;
                    og = null;
                    return false;
                }
                strFecCreac = datos[1];
                intTipoDoc = int.Parse(datos[2]);
                intNroDcto = int.Parse(datos[3]);
                strTitular = datos[4];
                fltSaldo = float.Parse(datos[5]);
                intMeses = int.Parse(datos[6]);
                fltPorcInt = float.Parse(datos[7]);

                return true;
            }
            catch
            {

                strError = "Error en consultar la cuenta CDT";
                return false;
            }
        }
        public override bool Crear()
        {
            if (!Validar())
                return false;
            try
            {
                clsGenerales og = new clsGenerales();
                intNroCta = og.UltimoId(rutaFile) + 1;
                if (intNroCta <= 0)
                {
                    strError = "Error en consultar cuenta CDT";
                    return false;
                }
                strFecCreac = DateTime.Now.ToShortDateString();
                string rgtro = intNroCta + ":" + strFecCreac + ":" + intTipoDoc + ":" + intNroDcto + ":" +
                    strTitular + ":" + fltSaldo.ToString() + ":" + intMeses + ":" + fltPorcInt;

                StreamWriter grabar = new StreamWriter(rutaFile, true);
                grabar.WriteLine(rgtro);
                grabar.Close();
                return true;
            }
            catch (Exception)
            {

                strError = "Error en grabar";
                return false;
            }
        }
        #endregion
    }
}
