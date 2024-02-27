<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Register.aspx.cs" Inherits="RideYouRent.Register" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0px;
        }
        .auto-style2 {
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
             <asp:Label ID="LabelRegister" runat="server" Text="Register" Font-Bold="True" Font-Size="XX-Large" ForeColor="#0099FF"></asp:Label>
        </div>
        <div>
            <hr />
        </div>
        <div>
            <table style="width: 100%;">
                
                <tr>
                    <td>
                        <asp:Label ID="LabelName" runat="server" Text="Full Name" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxName" runat="server" CssClass="auto-style1" Height="44px" Width="245px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 286px; height: 54px;">
                        <asp:Label ID="LabelUsername" runat="server" Text="Username" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td style="width: 373px; height: 54px;">
                        <asp:TextBox ID="TextBoxUsername" runat="server" Width="248px" Height="44px"></asp:TextBox>
                    </td>    
                </tr>
                <tr>
                    <td style="width: 286px">
                        <asp:Label ID="LabelPassword" runat="server" Text="Password" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td style="width: 373px">
                        <asp:TextBox ID="TextBoxPassword" runat="server" Width="250px" Height="44px"></asp:TextBox>
                    </td>      
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="LabelConfirmPassword" runat="server" Text="ConfirmPassword" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxConfirmPassword" runat="server" Height="44px" Width="249px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelEmail" runat="server" Text="Email" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxEmail" runat="server" Height="44px" Width="249px"></asp:TextBox>
                    </td>
                </tr>
                <td>
                    <asp:Label ID="LabelPhone" runat="server" Text="Phone" Font-Bold="True" Font-Size="X-Large"></asp:Label>  
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPhone" runat="server" Height="44px" Width="249px"></asp:TextBox>
                </td>
                
                <tr>
                    <td style="height: 54px">

                        <asp:HyperLink ID="LinkSendToLogin" runat="server" Font-Size="Large" NavigateUrl="~/Login.aspx">Go To Login Page</asp:HyperLink>

                    </td>
                    <td style="height: 54px">
                       
                        <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="Medium" Height="44px" OnClick="Button1_Click" Text="Submit" Width="155px" />
                       
                    </td>
                </tr>
                </table>   
        






        </div>
        <asp:Label ID="Label1" runat="server" Font-Size="Large"></asp:Label>
    </form>
</body>
</html>
