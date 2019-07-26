<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Deatils.aspx.cs" Inherits="Deatils" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding:30px; margin:20px;" >
          &nbsp<asp:Panel ID="Panel1" runat="server" BackColor="White" BorderColor="#6600CC" BorderStyle="Groove" ForeColor="Black" Height="287px" Width="502px">
                &nbsp;&nbsp; Details Page
                <br />
                <br />
                <div style="color:blue">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    -
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    -
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    -
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </div>
                <br />
                &nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Text="eng" Value="1" ></asp:ListItem>
                    <asp:ListItem Text="math" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
                <br />
                <br />
                <br />
                &nbsp  &nbsp &nbsp &nbsp &nbsp &nbsp
                <asp:Label ID="Label5" style="color:blue" runat="server" Text=""></asp:Label>
            </asp:Panel>
&nbsp;&nbsp;</div>
    </form>
</body>
</html>
