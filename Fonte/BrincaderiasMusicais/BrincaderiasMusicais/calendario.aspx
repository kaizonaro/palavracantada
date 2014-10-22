<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calendario.aspx.cs" Inherits="BrincaderiasMusicais.calendario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>

    <form id="form1" runat="server">
        <div>
            <asp:Calendar ID="Calendario" runat="server" OnDayRender="Calendario_DayRender"
                OnSelectionChanged="Calendario_SelectionChanged"
                OnVisibleMonthChanged="Calendario_VisibleMonthChanged"></asp:Calendar>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
