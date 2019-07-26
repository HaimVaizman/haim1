<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Login Page
            <br />
            <br />
            &nbsp  &nbsp &nbsp ID:<asp:TextBox ID="IDText1" runat="server" Width="173px"></asp:TextBox>
            &nbsp  &nbsp  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="IDText1" ErrorMessage="Must contain numbers" ValidationExpression="[1-9]{1,30}"></asp:RegularExpressionValidator>
            <br />
            <br />
            Name:<asp:TextBox ID="NameText1" runat="server" Width="171px"></asp:TextBox>
<%--           &nbsp   &nbsp <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="NameText1" ErrorMessage="Must contain letters" ValidationExpression="[a-zA-Z]"></asp:RegularExpressionValidator>--%>
           &nbsp   &nbsp  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Must contain letters" ControlToValidate="NameText1" ValidationExpression="[a-zA-Z]{1,100}"></asp:RegularExpressionValidator>
            <br />
            <br />
            &nbsp  &nbsp &nbsp   &nbsp &nbsp 
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Width="129px" />


                   <br />  &nbsp  &nbsp &nbsp &nbsp &nbsp <asp:Label ID="ErrLabel" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
