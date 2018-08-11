<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="UASTerakhir._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
 <form id="form1" runat="server">
    <div style="background:silver; height:500px; width:800px; margin:auto">
        <table>
            <tr>
                <td>Input Data Barang</td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
             <tr>
                <td>KODE</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtKode" runat="server"></asp:TextBox></td>
            </tr>
            
             <tr>
                <td>NAMA</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtNama" runat="server"></asp:TextBox></td>
            </tr>
            
             <tr>
                <td>HARGA</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtHarga" runat="server"></asp:TextBox></td>
            </tr>
            
             <tr>
                <td>JUMLAH</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="txtJumlah" runat="server"></asp:TextBox></td>
            </tr>
            
             <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
             <tr>
                <td colspan="3">
                    <asp:Button ID="btnSimpan" runat="server" Text="Simpan" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
