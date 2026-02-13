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
                        <asp:Button ID="btnCrear" runat="server" Text="Nuevo" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:RadioButtonList ID="rblCuentas" runat="server" RepeatDirection="Horizontal" Width="80%">
                            <asp:ListItem Selected="True" Value="opcAho">Ahorros</asp:ListItem>
                            <asp:ListItem Value="opcCte">Corriente</asp:ListItem>
                            <asp:ListItem Value="opcCdt">CDT</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMsj" runat="server" Font-Bold="True" ForeColor="Red" Width="98%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlGral" runat="server">
                            <table align="center" class="auto-style4">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNroCta" runat="server" Text="Nro. Cuenta:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNroCta" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFecCreac" runat="server" Text="Fecha Creación:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFecCreac" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlAhorro" runat="server" BackColor="#FF9966">
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
