﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="WebInput._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:1400px; height:900px ; background:silver; margin:auto; padding-top:10px">
        <div style="width:1380px; height:100px ; background:gray; margin:auto">
        </div>
        
        <div style="width:1380px; height:665px ; background:silver; margin:auto; margin-top:10px">
            <div style="width:300px; height:665px ; background:gray; float:left" >
            </div>
            
            <div style="width:1065px; height:665px ; background:gray; float:right">
                <div style="width:1045px; height:100px ; background:silver; margin:auto;margin-top:10px" >
                </div>
                <div style="width:1045px; height:420px ; background:silver;margin:auto; margin-top:10px">
                <table style="margin:auto">
                    <tr>
                        <td style="width:100px; margin:auto">NIM</td>
                        <td style="width:20px; margin:auto">:</td>
                        <td style="width:500px; margin:auto"><asp:TextBox ID="txtNim" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:100px; margin:auto">NAMA</td>
                        <td style="width:20px; margin:auto">:</td>
                        <td style="width:500px; margin:auto"><asp:TextBox ID="txtNama" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:100px; margin:auto">ALAMAT</td>
                        <td style="width:20px; margin:auto">:</td>
                        <td style="width:500px; margin:auto"><asp:TextBox ID="txtAlamat" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:100px; margin:auto">JURUSAN</td>
                        <td style="width:20px; margin:auto">:</td>
                        <td style="width:500px; margin:auto"><asp:TextBox ID="txtJurusan" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:100px; margin:auto">TELPON</td>
                        <td style="width:20px; margin:auto">:</td>
                        <td style="width:500px; margin:auto"><asp:TextBox ID="txtTelpon" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="btnSave" runat="server" Text="Save" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" />
                        </td>
                    </tr>
                </table>
                </div>
                <div style="width:1045px; height:100px ; background:silver;margin:auto; margin-top:10px">
                </div>
            </div>
        </div>
        
        <div style="width:1380px; height:100px ; background:gray; margin:auto; margin-top:10px">
        </div>
    
    </div>
    </form>
</body>
</html>
