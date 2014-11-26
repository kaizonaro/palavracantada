<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BrincaderiasMusicais._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <!--INICIO LOGIN-->
    <div id="divLogin">
        <h2>Login Área Restrita</h2>
        <form id="frmLogin" runat="server" action="default.aspx">
            <input type="hidden" name="acao" id="acao" value="FazerLogin" />
            <input type="text" id="Email" name="Email" />
            <input type="password" id="Senha" name="Senha" />
            <input type="submit" value="Enviar"/>
        </form>
    </div>
    <!--FIM LOGIN-->

    <!-- INICIO POST BLOG-->
    <div id="divBlog" runat="server">
        <h2>Blog</h2>
    </div>
    <!-- FIM POST BLOG-->

    <!-- INICIO VIDEOS-->
    <div id="divVideos" runat="server">
        <h2>Galeria de Fotos e Videos</h2>
    </div>
    <!-- FIM POST VIDEOS-->
    
</body>
</html>
