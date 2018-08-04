<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="UAS._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 14px;
        }
        .style3
        {
            width: 224px;
        }
        .style4
        {
            width: 116px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:500px; height:500px; margin:auto; background:silver">
    <table>
    <tr>
        <td class="style1" colspan="3">INPUT DATA PENDAPTAN</td>
    
    </tr>
    <tr>
        <td class="style4">&nbsp;</td>
        <td class="style2">&nbsp;</td>
        <td class="style3">&nbsp;</td>
    
    </tr>
    <tr>
        <td class="style4">Nama</td>
        <td class="style2">:</td>
        <td class="style3">
            <asp:TextBox ID="txtNama" runat="server" Width="218px"></asp:TextBox>
                    </td>
    
    </tr>
    <tr>
        <td class="style4">Status</td>
        <td class="style2">:</td>
        <td class="style3">
            <asp:TextBox ID="txtSatus" runat="server" Width="218px">Tetap</asp:TextBox>
                    </td>
    
    </tr>
    <tr>
        <td class="style4">Jenis Kelamin</td>
        <td class="style2">:</td>
        <td class="style3">
        
            <asp:RadioButton ID="rdo1" runat="server" Text="Pria" GroupName="grp1" />
            <asp:RadioButton ID="rdo2" runat="server" Text="Wanita" GroupName="grp1"/>
                    </td>
    
    </tr>
    <tr>
        <td class="style4">Pendapatan</td>
        <td class="style2">:</td>
        <td class="style3">
            <asp:TextBox ID="txtPendapatan" runat="server" Width="219px" >3500000</asp:TextBox>
                    </td>
    
    </tr>
    <tr>
        <td class="style4">&nbsp;</td>
        <td class="style2">&nbsp;</td>
        <td class="style3">
            <asp:Button ID="Button1" runat="server" Text="Simpan" />
            <asp:Button ID="Button2" runat="server" Text="Reset" Width="54px" />
        </td>
    
    </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
