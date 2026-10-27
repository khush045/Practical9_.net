
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Practical_9.aspx.cs" Inherits="Practical_9.Practical_9" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Placement Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">

        <h1 align="center">Placement Dashboard</h1>

        <h2>Placement Summary</h2>

        <asp:GridView ID="gvSummary" runat="server"
            AutoGenerateColumns="true" BorderWidth="1"
            CellPadding="8" />

        <br />

        <h2>Student Records</h2>

        <asp:GridView ID="gvStudents" runat="server"
            AutoGenerateColumns="true" BorderWidth="1"
            CellPadding="8" />

    </form>
</body>
</html>
