<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="3" width ="600">
            <tr>
                <td>Less 10Mb</td>
                <td>10Mb-50Mb</td>
                <td>More 100Mb</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Sma" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Ave" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Bii" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="Curr" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Label ID="Dirs" runat="server" Text=""></asp:Label>

        <br />
        <br />

    </div>
    </form>
</body>
</html>
