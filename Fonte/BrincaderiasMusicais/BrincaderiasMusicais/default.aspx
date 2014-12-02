<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BrincaderiasMusicais._default" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <brincadeira:script runat="server" id="script" />

</head>
<body>

    <!--TOPO-->
    <brincadeira:header runat="server" id="header" />
    
    <!--FIM DO TOPO-->

    <!-- CONTEUDO-->
    <section class="all">

    </section>
    <!--FIM DO CONTEUDO-->

    <!--RODAPÉ-->
    <brincadeira:footer runat="server" id="footer" />
    <!--FIM DO RODAPÉ-->
    
</body>
</html>
