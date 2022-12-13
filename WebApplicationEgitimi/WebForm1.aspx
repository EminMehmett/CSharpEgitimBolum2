<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplicationEgitimi.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Burası web form ön yüzü HTML web sitelerinin ortak dili html dir.
        </div>
        <asp:Button runat="server" Text="Button" />
        <asp:Calendar runat="server"></asp:Calendar>
        <asp:CheckBox runat="server"></asp:CheckBox>
        <asp:DropDownList runat="server"></asp:DropDownList>
        <asp:FileUpload runat="server"></asp:FileUpload>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HyperLink ID="HyperLink1" runat="server">Site Bağlantı</asp:HyperLink>

    </form>

</body>

</html>
