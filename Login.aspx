<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RideYouRent.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 15px;
        }
        .auto-style2 {
            margin-left: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
             &nbsp;<asp:Label ID="Label1" runat="server" Text="LOGIN" Font-Bold="True" Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>
            </div>
            <div>
            <hr />
            </div>
        <div>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 286px; height: 54px;">
                        <asp:Label ID="Label2" runat="server" Text="Username" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td style="width: 373px; height: 54px;">
                        <asp:TextBox ID="TextBox1" runat="server" Height="50px" Width="240px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </td>    
                </tr>
                <tr>
                    <td style="width: 286px">
                        <asp:Label ID="Label3" runat="server" Text="Password" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td style="width: 373px">
                        <asp:TextBox ID="TextBox2" runat="server" Height="50px" Width="240px"></asp:TextBox>
                    </td>      
                </tr> 
                <hr/>  
                <tr>
                    <td style="height: 54px">

                        <asp:HyperLink ID="LinkToRegister" runat="server" Font-Bold="False" Font-Size="Large" NavigateUrl="~/Register.aspx">Register New Inspector</asp:HyperLink>

                    </td>
                    <td style="height: 54px">
                        <asp:Button ID="ButtonLogin" runat="server" Font-Bold="True" Font-Size="Large" Height="50px" Text="Login" Width="155px" OnClick="ButtonLogin_Click" />
                        <asp:Button ID="Button1" runat="server" CssClass="auto-style1" Font-Bold="True" Height="50px" Text="Show" Width="140px" Font-Size="Large" OnClick="ShowButton_Click" />
                        <asp:Button ID="Button2" runat="server" CssClass="auto-style2" Font-Bold="True" Font-Size="Large" Height="49px" OnClick="ClearButton_Click" Text="Clear" Width="141px" />
                    </td>
                </tr>
                </table>   
        </div>
       <p> 
           &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Font-Size="Medium"></asp:Label>
       </p>
        

    </form>
</body>
</html>
