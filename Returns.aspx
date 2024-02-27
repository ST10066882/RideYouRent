<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Returns.aspx.cs" Inherits="RideYouRent.Returns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Enter New Return" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True"></asp:Label>
    </div> 
    <hr />
    <table style="width: 100%;">
        <tr>
            <td style="height: 50px;width: 173px">
                <asp:Label ID="Label2" runat="server" Text="Return ID"></asp:Label>
            </td>
            <td style="height: 50px;width: 363px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 50px;width: 173px">
                <asp:Label ID="Label8" runat="server" Text="Rental ID"></asp:Label>
            </td>
            <td style="height: 50px;width: 363px">
                <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="rentalIds" DataTextField="rentalId" DataValueField="rentalId">
                </asp:DropDownList>
                <asp:SqlDataSource ID="rentalIds" runat="server" ConnectionString="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString %>" SelectCommand="SELECT [rentalId] FROM [rental]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="height: 50px;width: 173px">
                <asp:Label ID="Label4" runat="server" Text="Inspector ID"></asp:Label>
            </td>
            <td style="height: 50px;width: 363px">
                <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="InspectorfullNames_From_Inspector" DataTextField="inspectorFullName" DataValueField="inspectorFullName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="InspectorfullNames_From_Inspector" runat="server" ConnectionString="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString %>" SelectCommand="SELECT [inspectorFullName] FROM [inspector]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="height: 50px;width: 173px">
                <asp:Label ID="Label5" runat="server" Text="Return Date"></asp:Label>
            </td>
            <td style="height: 50px;width: 363px">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td style="height: 50px;width: 173px">
                <asp:Label ID="Label6" runat="server" Text="Elapsed Days"></asp:Label>
            </td>
            <td style="height: 50px;width: 363px">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Height="35px" style="margin-left: 54px" Text="Add Return " Width="108px" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
    <hr />
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" Text="Show Data" Height="50px" style="margin-left: 3px" Width="115px" OnClick="ViewData_Click" />
            <asp:Button ID="Button3" runat="server" Height="50px" OnClick="HideButton_Click" style="margin-left: 56px" Text="Hide Table" Width="108px" />
        </p>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1260px" Height="265px">
            <AlternatingRowStyle BackColor="White" />
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
</asp:Content>
