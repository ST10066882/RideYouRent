<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Drivers.aspx.cs" Inherits="RideYouRent.Drivers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Enter New Driver" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True"></asp:Label>
    </div> 
    <hr />
    <div>
        <table class="w-100">
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label10" runat="server" Text="Driver ID"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label2" runat="server" Text="Full Name"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label3" runat="server" Text="Phone"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label5" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="156px" Height="31px"></asp:TextBox>
                    <asp:Button ID="Button4" runat="server" Height="41px" style="margin-left: 20px" Text="Add Driver" OnClick="AddDriverButton_Click" />
                    <br />
                    <br />
                    <asp:Label ID="Label17" runat="server" Font-Size="Large"></asp:Label>
                </td>
            </tr>
        </table>
         <hr />
        <p>
            <asp:Button ID="Button1" runat="server" Text="Show Updated Driver Table" Width="236px" style="margin-left: 95px" Height="50px" OnClick="Button1_Click" /><asp:Button ID="Button2" runat="server" Text="Clear data and DriverTable" style="margin-left: 157px" Height="50px" Width="239px" OnClick="HideButon_Click" /><asp:Button ID="Button3" runat="server" Text="Delete Record" style="margin-left: 157px" Height="50px" Width="136px" OnClick="DeleteButton_Click" />
        </p>
         <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1260px" Height="265px"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
             <Columns>
                 <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
             </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <hr />
        <table class="w-100">
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label11" runat="server" Text="Driver ID"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label6" runat="server" Text="Full Name"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label7" runat="server" Text="Phone"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label8" runat="server" Text="Email"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td> 
            </tr>
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label9" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                    <asp:Button ID="Button5" runat="server" Height="31px" style="margin-left: 20px" Text="Save Car" Width="90px" OnClick="SaveButton_Click" />
                </td>
            </tr>
        </table>
         <br />
        <hr />
        <br />
        <asp:Label ID="Label16" runat="server" Text="The Whole Table" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True"></asp:Label>
        <asp:GridView ID="GridView2" runat="server" Width="1260px" Height ="265px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="driverId" DataSourceID="ShowDriverTable">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="driverId" HeaderText="driverId" ReadOnly="True" SortExpression="driverId" />
                <asp:BoundField DataField="driverFullName" HeaderText="driverFullName" SortExpression="driverFullName" />
                <asp:BoundField DataField="addresses" HeaderText="addresses" SortExpression="addresses" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>

        <asp:SqlDataSource ID="ShowDriverTable" runat="server" ConnectionString="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString %>" SelectCommand="SELECT * FROM [driver] ORDER BY [driverId]"></asp:SqlDataSource>

    </div>
</asp:Content>
