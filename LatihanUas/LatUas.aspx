<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LatUas.aspx.vb" Inherits="LatihanUas.LatUas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
        }
        .style3
        {
            width: 10px;
        }
        .style4
        {
        }
        .style5
        {
            width: 68px;
        }
        .style6
        {
            width: 83px;
        }
        .style7
        {
            width: 333px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="height: 124px; width: 521px">
        <tr>
            <td class="style1" colspan="4">INPUT DATA PEGAWAI</td>
        </tr>
        <tr>
            <td class="style6">&nbsp;</td>
            <td class="style3">&nbsp;</td>
            <td class="style4" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">Nama</td>
            <td class="style3">:</td>
            <td class="style4" colspan="2">
                <asp:TextBox ID="txtNama" runat="server" Width="196px"></asp:TextBox>
                    </td>
        </tr>
        <tr>
            <td class="style6">Status</td>
            <td class="style3">:</td>
            <td class="style4" colspan="2">
                <asp:RadioButton ID="rdo1" runat="server" Text="Pria" GroupName="rdoStatus" />
                <asp:RadioButton ID="rdo2" runat="server" Text="Wanita" GroupName="rdoStatus"/>
                    </td>
        </tr>
        <tr>
            <td class="style6">Pendapatan</td>
            <td class="style3">:</td>
            <td class="style4" colspan="2">
                <asp:TextBox ID="txtPendapatan" runat="server" Width="194px">3500000</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">&nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">&nbsp;</td>
            <td class="style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="style6">&nbsp;</td>
            <td class="style2" colspan="2">
                <asp:Button ID="btnSimpan" runat="server" Text="Simpan" Width="70px" Mar />
                    </td>
            <td class="style7">
                <asp:Button ID="btnReset" runat="server" Text="Reset" Width="73px" />
                </td>
        </tr>
        <tr>
            <td class="style6">&nbsp;</td>
            <td class="style3">&nbsp;</td>
            <td class="style5">&nbsp;</td>
            <td class="style7">&nbsp;</td>
        </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
