<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rentals.aspx.cs" Inherits="RideYouRent.Rentals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Enter New Rental" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True"></asp:Label>
    </div> 
    <hr />
    <div>
        <table style="width: 100%;">
            <tr>
                <td style="height: 50px; width: 363px">
                    <asp:Label ID="Label2" runat="server" Text="Rental ID"></asp:Label>
                </td>
                <td style="height: 50px">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 363px;height: 50px">
                    <asp:Label ID="Label8" runat="server" Text="CarNo"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="CarNo_In_CarTable" DataTextField="carNo" DataValueField="carNo">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="CarNo_In_CarTable" runat="server" ConnectionString="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString %>" SelectCommand="SELECT [carNo] FROM [car]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="width: 363px;height: 50px">
                    <asp:Label ID="Label10" runat="server" Text="Driver Name"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="Names_In_DriverTable" DataTextField="driverFullName" DataValueField="driverFullName">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Names_In_DriverTable" runat="server" ConnectionString="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString %>" SelectCommand="SELECT [driverFullName] FROM [driver]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="width: 363px;height: 50px">
                    <asp:Label ID="Label9" runat="server" Text="Inspector Name"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="Inspector_Names_In_InspectorTable" DataTextField="inspectorFullName" DataValueField="inspectorFullName">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Inspector_Names_In_InspectorTable" runat="server" ConnectionString="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString %>" SelectCommand="SELECT [inspectorFullName] FROM [inspector]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="width: 363px;height: 50px">
                    <asp:Label ID="Label3" runat="server" Text="Rental Fee"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 363px;height: 50px">
                    <asp:Label ID="Label6" runat="server" Text="Start Date"></asp:Label>
                </td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td style="width: 363px;height: 50px">
                    <asp:Label ID="Label7" runat="server" Text="End Date"></asp:Label>
                </td>
                <td>
                    <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                    <asp:Button ID="Button2" runat="server" Height="38px" OnClick="AddREntalButton_Click" style="margin-left: 38px" Text="Add Rental" Width="84px" />
                </td>
            </tr>
        </table>
        <hr />
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" Text="Show Data" Height="50px" style="margin-left: 3px" Width="115px" OnClick="ViewDataButton_Click" />
            <asp:Button ID="Button3" runat="server" Height="50px" OnClick="HideButton_Click" style="margin-left: 79px" Text="Hide Table" Width="103px" />
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
    </div>
</asp:Content>
