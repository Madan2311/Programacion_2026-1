using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Referencias locales
using libTiposCtas;

namespace webCtasBanc
{
    public partial class frmHerencia : System.Web.UI.Page
    {
        #region vbles miembro - atributos
        int intTipoDoc, intNroDoc, intTipoCta, intCantMes, intNroCta;
        string strTitular, strRepres;
        float fltSaldo, fltPorcIntAhorr, fltPorcIntCDT, fltCupoLim, fltVrTx;

        static int intTipo;

        #endregion

        #region metodos propios
        private void Mensaje( string txt)
        {
            lblMsj.Text = txt;
        }
        private void llenarComboTipDoc()
        {
            ddlTipoDoc.Items.Add(new ListItem("Seleccionar...", "0"));
            ddlTipoDoc.Items.Add(new ListItem("Cédular Ciudadania", "10"));
            ddlTipoDoc.Items.Add(new ListItem("NIT", "12"));
                ddlTipoDoc.Items.Add(new ListItem("Pasaporte", "14"));
            ddlTipoDoc.Items.Add(new ListItem("Permiso de Protección Temporal", "16"));
            ddlTipoDoc.Items.Add(new ListItem("NUIP", "18"));
                ddlTipoDoc.Items.Add(new ListItem("Cédula de Extrangeria", "20"));
        }
        private void llenarComboTipCta()
        {
            ddlTipoAhorro.Items.Add(new ListItem("Seleccionar...", "0"));
            ddlTipoAhorro.Items.Add(new ListItem("Normal", "1"));
            ddlTipoAhorro.Items.Add(new ListItem("Nóminal", "3"));
            ddlTipoAhorro.Items.Add(new ListItem("Nequi", "5"));
        }
        private void Limpiar()
        {
            txtNroCta.Text = string.Empty;
            lblFecCreac.Text = string.Empty;
            ddlTipoDoc.SelectedIndex = 0;
            txtNroDoc.Text = string.Empty;
            txtTitular.Text = string.Empty;
            txtSaldo.Text = string.Empty;
            ddlTipoAhorro.SelectedIndex = 0;
            txtPorIntAhorro.Text = string.Empty;
            txtPorIntCDT.Text = string.Empty;
            txtRepres.Text = string.Empty;
            txtLimSobreG.Text = string.Empty;
            txtVrTransac.Text = string.Empty;
            txtMesCDT.Text = string.Empty;
            Mensaje("");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                intTipo = 1; // 1: Ahorro, 2: Corriente, 3: CDT
                llenarComboTipDoc();
                llenarComboTipCta();
            }
        }

        protected void rblCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpiar();
            intTipo = rblCuentas.SelectedIndex + 1;
            pnlAhorro.Visible = false;
            pnlCorriente.Visible = false;
            pnlCDT.Visible = false;
            pnlBtns.Visible = false;
            switch (intTipo)
            {
                case 1:
                    pnlAhorro.Visible = true;
                    pnlBtns.Visible = true;
                    break;
                case 2: 
                    pnlCorriente.Visible = true;
                    pnlBtns.Visible = true;
                    break;
                default:
                    pnlCDT.Visible = true;
                    break;
            }
            ddlTipoDoc.Focus();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                Mensaje(string.Empty);

                intTipoDoc = Convert.ToInt32(ddlTipoDoc.SelectedValue);
                intNroDoc = Convert.ToInt32(txtNroDoc.Text);
                strTitular = txtTitular.Text;
                fltSaldo = Convert.ToSingle(txtSaldo.Text);

                switch (intTipo)
                {
                    case 1:
                        intTipoCta = Convert.ToInt32(ddlTipoAhorro.SelectedValue);
                        fltPorcIntAhorr = Convert.ToSingle(txtPorIntAhorro.Text);
                        clsAhorro oCtaAh = new clsAhorro(intTipoDoc, intNroDoc, strTitular, fltSaldo, intTipoCta, fltPorcIntAhorr);
                        if (!oCtaAh.Crear())
                        {
                            Mensaje(oCtaAh.Error);
                            oCtaAh = null;
                            return;
                        }
                        txtNroCta.Text = Convert.ToString(oCtaAh.NroCta);
                        lblLimSobreG.Text = oCtaAh.FecCreac;

                        Mensaje("Cuenta creada exitosamente");
                        break;
                    case 2:

                        break;
                    default:

                        break;
                }
            }
            catch (Exception err)
            {
                Mensaje(err.Message);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Mensaje(string.Empty);

                intNroCta = Convert.ToInt32(txtNroCta.Text);
                if (intNroCta < 0)
                {
                    Mensaje("Número de cuenta no válido");
                    txtNroCta.Focus();
                    return;
                }

                clsAhorro oAh = new clsAhorro();
                if (!oAh.Buscar(intNroCta))
                {
                    Mensaje(oAh.Error);
                    oAh = null;
                    return;
                }

                lblFecCreac.Text = oAh.FecCreac;
                ddlTipoDoc.SelectedValue = oAh.TipoDoc.ToString();
                txtNroDoc.Text = oAh.NroDcto.ToString();
                txtTitular.Text = oAh.Titular;
                txtSaldo.Text = oAh.Saldo.ToString();
                ddlTipoAhorro.SelectedValue = oAh.TipoAhor.ToString();
                txtPorIntAhorro.Text = oAh.PorcIntAhor.ToString();

                oAh = null;
                Mensaje("Busqueda exitosa");
            }
            catch (Exception err)
            {

                Mensaje(err.Message);
            }
        }
        protected void btnDepositar_Click(object sender, EventArgs e)
        {
            try
            {
                Mensaje(string.Empty);

                intNroCta = Convert.ToInt32(txtNroCta.Text);
                if (intNroCta < 0)
                {
                    Mensaje("Número de cuenta no válido");
                    txtNroCta.Focus();
                    return;
                }
                fltVrTx = Convert.ToSingle(txtVrTransac.Text);
                if ( fltVrTx <= 0)
                {
                    Mensaje("Valor no valido");
                    txtVrTransac.Focus();
                    return;
                }

                clsAhorro oAh = new clsAhorro();

                if (!oAh.Deposito(intNroCta, fltVrTx))
                {
                    Mensaje(oAh.Error);
                    oAh = null;
                    return;
                }

                btnConsultar_Click(null, null);
                Mensaje("Deposito realizado con éxito");
                oAh = null;
            }
            catch (Exception err)
            {

                Mensaje (err.Message);
            }
        }

        protected void btnRetirar_Click(object sender, EventArgs e)
        {

        }
    }
}