<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackgroundProcess.aspx.cs" Inherits="TheModernBibliotheca.Debug.DebugBackgroundProcess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button Text="Test Background Process" runat="server" ID="bgprocess" OnClick="bgprocess_Click"/>
        </div>
    </form>
</body>
</html>
