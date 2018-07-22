<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="LatihanUas._Default" %>

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
            width: 17px;
        }
        .style3
        {
        }
        .style4
        {
            width: 181px;
        }
        .style5
        {
        }
        .style9
        {
            width: 6px;
        }
        .style10
        {
            width: 71px;
        }
        .style11
        {
        }
        .style12
        {
        }
        .style13
        {
            width: 113px;
        }
        .style14
        {
            width: 347px;
        }
        .style15
        {
            width: 82px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:1200px; height:800px; margin:auto; background:silver">
    <table style="height: 228px; width: 1100px">
    <tr>
        <td class="style1" colspan="4">DATA KEPENDUDUKAN</td>
        <td class="style5">&nbsp;</td>
        <td class="style15">&nbsp;</td>
        <td class="style13">&nbsp;</td>
        <td class="style10">&nbsp;</td>
        <td class="style11" colspan="3">
            &nbsp;</td>
    </tr>
      <tr>
        <td class="style14">&nbsp;</td>
        <td class="style2">&nbsp;</td>
        <td class="style3">&nbsp;</td>
        <td class="style4">&nbsp;</td>
        <td class="style5">&nbsp;</td>
        <td class="style15">&nbsp;</td>
        <td class="style13">&nbsp;</td>
        <td class="style10">&nbsp;</td>
        <td class="style11">&nbsp;</td>
        <td class="style9">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
     <tr>
        <td class="style14">No kendaraan</td>
        <td class="style2">&nbsp;</td>
        <td class="style3" colspan="2">
            <asp:TextBox ID="TextBox9" runat="server" Width="245px"></asp:TextBox>
         </td>
        <td class="style5">&nbsp;</td>
        <td class="style15">&nbsp;</td>
        <td class="style13">Jenis Kelamin</td>
        <td class="style10">&nbsp;</td>
        <td class="style11" colspan="3">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="166px" RepeatDirection="Horizontal">
                <asp:ListItem Text="Pria" Value="L"></asp:ListItem>
                <asp:ListItem Text="Wanita" Value="W"></asp:ListItem>
            </asp:RadioButtonList>
                    </td>
    </tr>
     <tr>
        <td class="style14">Nama</td>
        <td class="style2">&nbsp;</td>
        <td class="style3" colspan="9">
            <asp:TextBox ID="TextBox8" runat="server" Width="953px"></asp:TextBox>
         </td>
    </tr>
     <tr>
        <td class="style14">Alamat</td>
        <td class="style2">&nbsp;</td>
        <td class="style3" colspan="9">
            <asp:TextBox ID="TextBox7" runat="server" Width="954px" TextMode="MultiLine" 
                Height="62px"></asp:TextBox>
                    </td>
    </tr>
     <tr>
        <td class="style14">Kelurahan</td>
        <td class="style2">&nbsp;</td>
        <td class="style3" colspan="3">
            <asp:TextBox ID="TextBox3" runat="server" Width="511px"></asp:TextBox>
         </td>
        <td class="style15">&nbsp;</td>
        <td class="style13">RT/RW</td>
        <td class="style10">&nbsp;</td>
        <td class="style11">
            <asp:TextBox ID="TextBox4" runat="server" Width="78px"></asp:TextBox>
         </td>
        <td class="style9">/</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server" Width="76px"></asp:TextBox>
         </td>
    </tr>
     <tr>
        <td class="style14">Pekerjaan</td>
        <td class="style2">&nbsp;</td>
        <td class="style3">
            <asp:Button ID="btnCari" runat="server" Text="Cari" Width="53px" />
         </td>
        <td class="style4">
            <asp:TextBox ID="txtCari" runat="server" Width="178px"></asp:TextBox>
                    </td>
        <td class="style5">
            <asp:TextBox ID="TextBox1" runat="server" Width="250px"></asp:TextBox>
         </td>
        <td class="style15">&nbsp;</td>
        <td class="style13">Status</td>
        <td class="style10">&nbsp;</td>
        <td colspan="3">
            <asp:TextBox ID="TextBox6" runat="server" Width="168px"></asp:TextBox>
                    </td>
        
    </tr>
     <tr>
        <td class="style14">Pendapatan</td>
        <td class="style2">&nbsp;</td>
        <td class="style3" colspan="2">
            <asp:TextBox ID="TextBox10" runat="server" Width="246px"></asp:TextBox>
         </td>
        <td class="style5" colspan="2">
            <asp:TextBox ID="TextBox11" runat="server" Width="312px"></asp:TextBox>
         </td>
        <td class="style12" colspan="5">
            <asp:TextBox ID="TextBox12" runat="server" Width="359px"></asp:TextBox>
         </td>
    </tr>
     <tr>
        <td class="style14">&nbsp;</td>
        <td class="style2">&nbsp;</td>
        <td class="style3" colspan="2">
            <asp:Button ID="Button1" runat="server" Text="Simpan" Width="69px" />
            <asp:Button ID="Button2" runat="server" Text="Reset" Width="70px" />
                    </td>
        <td class="style5">&nbsp;</td>
        <td class="style15">&nbsp;</td>
        <td class="style13">&nbsp;</td>
        <td class="style10">&nbsp;</td>
        <td class="style11">&nbsp;</td>
        <td class="style9">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    
    </table>
    
    </div>
    </form>
</body>
</html>
