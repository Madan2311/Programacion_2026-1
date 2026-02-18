<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmHerencia.aspx.cs" Inherits="webCtasBanc.frmHerencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Practica  #1 - Herencia y Poliformismo</title>
    <style type="text/css">
        .auto-style1 {
            width: 90%;
            border: 3px solid #008080;
            text-align: center;
        }
        .auto-style2 {
            color: #660066;
            font-family: "Times New Roman", Times, serif;
        }
        .auto-style3 {
            height: 33px;
        }
        .auto-style4 {
            width: 90%;
            border: 1px solid #008080;
        }
        .auto-style5 {
            width: 90%;
            border: 1px solid #008080;
        }
        .auto-style6 {
            height: 26px;
        }
        .auto-style7 {
            height: 26px;
            width: 274px;
            font-size: medium;
        }
        .auto-style8 {
            width: 274px;
            font-size: medium;
        }
        .auto-style9 {
            height: 34px;
        }
        .auto-style10 {
            width: 274px;
            height: 34px;
        }
        .auto-style11 {
            height: 29px;
        }
        .auto-style12 {
            height: 26px;
            width: 156px;
        }
        .auto-style13 {
            height: 34px;
            width: 156px;
            text-align: right;
        }
        .auto-style14 {
            width: 156px;
            font-size: medium;
        }
        .auto-style15 {
            height: 26px;
            width: 207px;
        }
        .auto-style16 {
            height: 34px;
            width: 207px;
            text-align: right;
        }
        .auto-style17 {
            width: 207px;
            font-size: medium;
        }
        .auto-style18 {
            width: 280px;
            font-size: medium;
        }
        .auto-style19 {
            height: 29px;
            width: 280px;
            text-align: center;
        }
        .auto-style20 {
            height: 29px;
            text-align: right;
        }
        .auto-style21 {
            text-align: right;
        }
        .auto-style22 {
            width: 280px;
            text-align: center;
        }
        .auto-style23 {
            width: 90%;
            border-color: #006666;
        }
        .auto-style25 {
            width: 277px;
        }
        .auto-style26 {
            width: 203px;
            text-align: right;
        }
        .auto-style27 {
            font-size: medium;
        }
        .auto-style28 {
            width: 203px;
            font-size: medium;
        }
        .auto-style29 {
            width: 277px;
            font-size: medium;
        }
        .auto-style34 {
            width: 160px;
            font-size: medium;
        }
        .auto-style35 {
            width: 160px;
            text-align: right;
        }
        .auto-style36 {
            width: 161px;
            text-align: right;
        }
        .auto-style37 {
            width: 278px;
        }
        .auto-style38 {
            width: 161px;
        }
        .auto-style39 {
            width: 281px;
            text-align: right;
        }
        .auto-style40 {
            width: 200px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2"><strong>CUENTAS BANCARIAS</strong></td>
                </tr>
                <tr>
                    <td style="width: 75%">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnCrear" runat="server" Text="Nuevo" OnClick="btnCrear_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:RadioButtonList ID="rblCuentas" runat="server" RepeatDirection="Horizontal" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="rblCuentas_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="opcAho">Ahorros</asp:ListItem>
                            <asp:ListItem Value="opcCte">Corriente</asp:ListItem>
                            <asp:ListItem Value="opcCdt">CDT</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMsj" runat="server" Font-Bold="True" ForeColor="Red" Width="98%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlGral" runat="server">
                            <table align="center" class="auto-style4">
                                <tr>
                                    <td class="auto-style27">&nbsp;</td>
                                    <td class="auto-style18">&nbsp;</td>
                                    <td class="auto-style27">&nbsp;</td>
                                    <td class="auto-style27">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style20">
                                        <asp:Label ID="lblNroCta" runat="server" Text="Nro. Cuenta:" CssClass="auto-style27"></asp:Label>
                                    </td>
                                    <td class="auto-style19">
                                        <asp:TextBox ID="txtNroCta" runat="server" ReadOnly="True" CssClass="auto-style27"></asp:TextBox>
                                    </td>
                                    <td class="auto-style20">
                                        <asp:Label ID="label" runat="server" Text="Fecha Creación:" CssClass="auto-style27"></asp:Label>
                                    </td>
                                    <td class="auto-style11">
                                        <asp:Label ID="lblFecCreac" runat="server" BorderColor="#006666" BorderWidth="1px" Text="."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style21">
                                        <asp:Label ID="lblTipoDoc" runat="server" Text="Tipo Dcto:" CssClass="auto-style27"></asp:Label>
                                    </td>
                                    <td class="auto-style22">
                                        <asp:DropDownList ID="ddlTipoDoc" runat="server" Width="58%" CssClass="auto-style27">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style21">
                                        <asp:Label ID="lblNroDoc" runat="server" Text="Nro. Dcto:" CssClass="auto-style27"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNroDoc" runat="server" CssClass="auto-style27"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style20">
                                        <asp:Label ID="lblTitular" runat="server" Text="Titular:" CssClass="auto-style27"></asp:Label>
                                    </td>
                                    <td class="auto-style19">
                                        <asp:TextBox ID="txtTitular" runat="server" CssClass="auto-style27"></asp:TextBox>
                                    </td>
                                    <td class="auto-style20">
                                        <asp:Label ID="lblSaldo" runat="server" Text="Valor / Saldo:" CssClass="auto-style27"></asp:Label>
                                    </td>
                                    <td class="auto-style11">
                                        <asp:TextBox ID="txtSaldo" runat="server" CssClass="auto-style27"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style27">&nbsp;</td>
                                    <td class="auto-style18">&nbsp;</td>
                                    <td class="auto-style27">&nbsp;</td>
                                    <td class="auto-style27">&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlAhorro" runat="server">
                            <table align="center" class="auto-style5">
                                <tr>
                                    <td class="auto-style12"></td>
                                    <td class="auto-style7">
                                        &nbsp;</td>
                                    <td class="auto-style15"></td>
                                    <td class="auto-style6"></td>
                                </tr>
                                <tr>
                                    <td class="auto-style13">
                                        <asp:Label ID="lblTipoCuenta" runat="server" Text="Tipo Cuenta:" CssClass="auto-style27"></asp:Label>
                                    </td>
                                    <td class="auto-style10">
                                        <asp:DropDownList ID="ddlTipoAhorro" runat="server" Width="59%" CssClass="auto-style27">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style16">
                                        <asp:Label ID="lblPorcInt" runat="server" Text="Porc. Interés:" CssClass="auto-style27"></asp:Label>
                                    </td>
                                    <td class="auto-style9">
                                        <asp:TextBox ID="txtPorIntAhorro" runat="server" CssClass="auto-style27"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style14">&nbsp;</td>
                                    <td class="auto-style8">&nbsp;</td>
                                    <td class="auto-style17">&nbsp;</td>
                                    <td class="auto-style27">&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlCorriente" runat="server" Visible="False">
                            <table align="center" class="auto-style23">
                                <tr>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style29">&nbsp;</td>
                                    <td class="auto-style28">&nbsp;</td>
                                    <td class="auto-style27">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style35">
                                        <asp:Label ID="lblRepres" runat="server" CssClass="auto-style27" Text="Representante:"></asp:Label>
                                    </td>
                                    <td class="auto-style25">
                                        <asp:TextBox ID="txtRepres" runat="server" CssClass="auto-style27"></asp:TextBox>
                                    </td>
                                    <td class="auto-style26">
                                        <asp:Label ID="lblLimSobreG" runat="server" CssClass="auto-style27" Text="Límite Sobregiro:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLimSobreG" runat="server" CssClass="auto-style27"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style34">&nbsp;</td>
                                    <td class="auto-style29">&nbsp;</td>
                                    <td class="auto-style28">&nbsp;</td>
                                    <td class="auto-style27">&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlBtns" runat="server">
                            <table align="center" class="auto-style23">
                                <tr>
                                    <td class="auto-style36">
                                        <asp:Label ID="lblVrTransac" runat="server" Text="Valor:"></asp:Label>
                                    </td>
                                    <td class="auto-style37">
                                        <asp:TextBox ID="txtVrTransac" runat="server" style="margin-left: 0px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnDepositar" runat="server" Text="Depositar" />
                                        <asp:Button ID="btnRetirar" runat="server" Text="Retirar" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style6">
                        <asp:Panel ID="pnlCDT" runat="server" Visible="False">
                            <table align="center" class="auto-style23">
                                <tr>
                                    <td class="auto-style38">&nbsp;</td>
                                    <td class="auto-style39">&nbsp;</td>
                                    <td class="auto-style40">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style38">
                                        <asp:Label ID="lblMesCDT" runat="server" style="text-align: right" Text="Cantidad Meses:"></asp:Label>
                                    </td>
                                    <td style="width: 277px">
                                        <asp:TextBox ID="txtMesCDT" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="auto-style40">
                                        <asp:Label ID="lblValorCDT" runat="server" Text="Valor CDT:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtValorCDT" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style38">&nbsp;</td>
                                    <td class="auto-style39">
                                        <asp:Label ID="lblPorIntCDT" runat="server" Text="Porc. Interés:" style="text-align: right"></asp:Label>
                                    </td>
                                    <td style="width: 200px">
                                        <asp:TextBox ID="txtPorIntCDT" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style38">&nbsp;</td>
                                    <td class="auto-style39">&nbsp;</td>
                                    <td class="auto-style40">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style6"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
