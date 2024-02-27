<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="RideYouRent.Cars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Label ID="Label1" runat="server" Text="Enter New Car" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True"></asp:Label>
    </div> 
    <hr />
    <div>
        <table style="width: 100%;" aria-disabled="True">
                        <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label18" runat="server" Text="CarId"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px">
                    <asp:TextBox ID="CarIdTextBox1" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label2" runat="server" Text="CarNo"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px">
                    <asp:TextBox ID="CarNoTextBox1" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label3" runat="server" Text="BodyType"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:DropDownList ID="BodyTypeDropDownList1" runat="server" DataSourceID="BodyTypeNames_In_BodyTable" DataTextField="bodyType_Name" DataValueField="bodyType_Name">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="BodyTypeNames_In_BodyTable" runat="server" ConnectionString="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString %>" ProviderName="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString.ProviderName %>" SelectCommand="SELECT [bodyType_Name] FROM [carBodyType] ORDER BY [bodyType_Name]"></asp:SqlDataSource>
                </td>
               
            </tr>
            <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label4" runat="server" Text="Make"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:DropDownList ID="MakeDropDownList1" runat="server" DataSourceID="CarMakeNames" DataTextField="make_Name" DataValueField="make_Name">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="CarMakeNames" runat="server" ConnectionString="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString %>" SelectCommand="SELECT [make_Name] FROM [carMake]"></asp:SqlDataSource>
                </td>
               
            </tr>
             <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label5" runat="server" Text="Model"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:DropDownList ID="ModelDropDownList1" runat="server" DataSourceID="carModelNames" DataTextField="model_Name" DataValueField="model_Name">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="carModelNames" runat="server" ConnectionString="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString %>" SelectCommand="SELECT [model_Name] FROM [carModel]"></asp:SqlDataSource>
                 </td>
               
            </tr>
            <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label6" runat="server" Text="Kilometers Travelled"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:TextBox ID="KilometersTavelledTextBox1" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label7" runat="server" Text="Kilometers Serviced"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:TextBox ID="kilometersServicedTextBox1" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label8" runat="server" Text="Availability"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:DropDownList ID="availabilityDropDownList1" runat="server">
                        <asp:ListItem Value="no">no</asp:ListItem>
                        <asp:ListItem>yes</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="Values_For_Availability_From_CarTable" runat="server" ConnectionString="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString %>" SelectCommand="SELECT DISTINCT [availabilitys] FROM [car]"></asp:SqlDataSource>
                    <asp:Label ID="Label19" runat="server" Font-Size="Large"></asp:Label>
                    <asp:Button ID="AddCarButton" runat="server" Height="50px" OnClick="AddCarButton_Click" style="margin-left: 200px" Text="Add Car" Width="110px" />
                </td>
                
            </tr>
        </table> 
        <hr />
        <p>
            <asp:Button ID="ViewButton" runat="server" Text="Show Updated Car Table" Width="208px" style="margin-left: 95px" Height="50px" OnClick="ViewButton_Click" /><asp:Button ID="ClearButton" runat="server" Text="Clear Data And Table" style="margin-left: 157px" Height="50px" Width="208px" OnClick="ClearButton_Click" /><asp:Button ID="DeleteButton" runat="server" Text="Delete Record" style="margin-left: 157px" Height="50px" Width="136px" OnClick="DeleteButton_Click" />
        </p>

        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1260px" Height="265px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
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

        <table style="width: 100%;" aria-disabled="True">
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label17" runat="server" Text="CarId"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px">
                    <asp:TextBox ID="CarIdTextBox2" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td style="width: 363px; height: 50px">
                    <asp:Label ID="Label9" runat="server" Text="CarNo"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px">
                    <asp:TextBox ID="CarNoTextBox2" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label10" runat="server" Text="BodyType"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:DropDownList ID="BodyTypeDropDownList2" runat="server" DataSourceID="BodyTypeNames_In_BodyTable" DataTextField="bodyType_Name" DataValueField="bodyType_Name">
                    </asp:DropDownList>
                </td>
               
            </tr>
            <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label11" runat="server" Text="Make"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:DropDownList ID="MakeDropDownList2" runat="server" DataSourceID="CarMakeNames" DataTextField="make_Name" DataValueField="make_Name">
                    </asp:DropDownList>
                </td>
               
            </tr>
             <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label12" runat="server" Text="Model"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:DropDownList ID="ModelDropDownList2" runat="server" DataSourceID="carModelNames" DataTextField="model_Name" DataValueField="model_Name">
                    </asp:DropDownList>
                 </td>
               
            </tr>
            <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label13" runat="server" Text="Kilometers Travelled"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:TextBox ID="kilometersTravelledTextBox2" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label14" runat="server" Text="Kilometers Serviced"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:TextBox ID="kilometerServicedTextBox2" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td style="width: 363px; height: 50px;">
                    <asp:Label ID="Label15" runat="server" Text="Availability"></asp:Label>
                </td>
                <td style="width: 567px; height: 50px;">
                    <asp:DropDownList ID="availabilityDropDownList2" runat="server">
                        <asp:ListItem>yes</asp:ListItem>
                        <asp:ListItem>no</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Font-Bold="True" Height="37px" OnClick="SaveCarButton_Click" style="margin-left: 78px" Text="Save Car" Width="121px" />
                </td>
            </tr>
        </table> 
        <br />
        <hr />
        <br />
        <asp:Label ID="Label16" runat="server" Text="The Whole Table" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True"></asp:Label>
        <asp:GridView ID="GridView2" runat="server" Width="1260px" Height ="265px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="carId" DataSourceID="Car_Table_Data">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="carId" HeaderText="carId" ReadOnly="True" SortExpression="carId" />
                <asp:BoundField DataField="carNo" HeaderText="carNo" SortExpression="carNo" />
                <asp:BoundField DataField="make_Name" HeaderText="make_Name" SortExpression="make_Name" />
                <asp:BoundField DataField="model_Name" HeaderText="model_Name" SortExpression="model_Name" />
                <asp:BoundField DataField="bodyType_Name" HeaderText="bodyType_Name" SortExpression="bodyType_Name" />
                <asp:BoundField DataField="kilometersTravelled" HeaderText="kilometersTravelled" SortExpression="kilometersTravelled" />
                <asp:BoundField DataField="kilometersServiced" HeaderText="kilometersServiced" SortExpression="kilometersServiced" />
                <asp:BoundField DataField="availabilitys" HeaderText="availabilitys" SortExpression="availabilitys" />
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
        <asp:SqlDataSource ID="Car_Table_Data" runat="server" ConnectionString="<%$ ConnectionStrings:db-vc-cldv6211-st10066882ConnectionString %>" SelectCommand="SELECT car.carId, car.carNo, carMake.make_Name, carModel.model_Name, carBodyType.bodyType_Name, car.kilometersTravelled, car.kilometersServiced, car.availabilitys FROM car INNER JOIN carBodyType ON car.bodyType_Id = carBodyType.bodyType_Id INNER JOIN carMake ON car.make_Id = carMake.make_Id INNER JOIN carModel ON car.model_Id = carModel.model_Id ORDER BY car.carId"></asp:SqlDataSource>
    </div>



</asp:Content>
