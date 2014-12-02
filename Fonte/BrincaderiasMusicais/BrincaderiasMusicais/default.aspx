<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BrincaderiasMusicais._default" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <brincadeira:script runat="server" id="script" />

    <<<<<<< .mine
    <!--FONTS-->

    <!-- SEO -->
    <link rel="icon" type="image/png" href="images/favicon.png" />
    <meta name="description" content=" ">
    <meta name="keywords" content=" ">
    <meta property="og:title" content=" ">
    <meta property="og:image" content=" ">
    <meta property="og:description" content=" ">

    <!--G.A-->

    <!--CSS-->
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/responsive.css" rel="stylesheet" type="text/css">

    <!--RESPONSIVO
<meta name="viewport" content="width=device-width, initial-scale=1">-->

    <!-- Para nao alterar css de telefones-->
    <meta name="format-detection" content="telephone=no">
    <meta name="SKYPE_TOOLBAR" content="SKYPE_TOOLBAR_PARSER_COMPATIBLE" />
</head>
<body>

    <!--TOPO-->
    <brincadeira:header runat="server" id="header" />
    <!--FIM DO TOPO-->


    <!-- CONTEUDO-->
    <section class="all">
        <div class="all_center">

            <!--MENU-->
            <nav id="menu">

            </nav>
            <!--FIM DO MENU-->

            <!--BOX LOGIN-->
            <aside>

            </aside>
            <!--FIM DO BOX LOGIN-->
        </div>
    </section>
    <!--FIM DO CONTEUDO-->

    <!--RODAPÉ-->
    <brincadeira:footer runat="server" id="footer" />
    <!--FIM DO RODAPÉ-->

</body>
</html>
