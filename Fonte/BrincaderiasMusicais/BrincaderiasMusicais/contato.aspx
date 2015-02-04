<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contato.aspx.cs" Inherits="BrincaderiasMusicais.contato" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <brincadeira:script runat="server" ID="script" />

</head>
<body>

    <!--TOPO-->
    <brincadeira:header runat="server" ID="header" />
    <!--FIM DO TOPO-->

    <!--MENU-->
    <brincadeira:menu runat="server" ID="menu" />
    <!--FIM DO MENU-->

    <!-- CONTEUDO-->
    <section class="all">
        <div class="all_center">

            <!--CONTEUDO INTERNO (SOBRE)-->
            <div id="sobre" class="interna">
                <div class="titu">
                    Contato
                </div>

                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong>Contato</strong>
                </div>   

                <div class="txt">
                    Entre em contato com a equipe do Projeto Brincadeiras Musicais da Palavra Cantada, preencha o formulário abaixo e clique no botão “enviar”. Retornaremos o seu contato o mais breve que possível. Obrigado!
                </div>
                <form id="contato" class="form" method="post">
                    <label>Nome:</label><input type="text" name="nome" class="input" /><label>E-mail:</label><input type="text" name="email" class="input email" /><br />
                    <label for="mensagem" class="label_msg">Mensagem:</label><br />
                    <textarea id="mensagem" class="input" rows="4"></textarea>
                    <input type="submit" class="btn" value="enviar" />
                </form>
                <div class="txt map_txt">
                    <strong>EDITORA MELHORAMENTOS</strong><br />
                    Rua Tito, 479 - Vila Romana - CEP: 05051-000 - São Paulo (SP)<br />
                    Email: <a href="mailto:vendasinstitucionais@melhoramentos.com.br">vendasinstitucionais@melhoramentos.com.br</a>
                </div>
                <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d914.5315826573732!2d-46.69661738650702!3d-23.52795826945511!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cef876e6191def%3A0x9cc6e5e968e4667d!2sR.+Tito%2C+479+-+Vila+Romana%2C+S%C3%A3o+Paulo+-+SP!5e0!3m2!1spt-BR!2sbr!4v1422928148583" width="481" height="200" frameborder="0" style="border:0"></iframe>

            </div>
            <!--FIM DO CONTEUDO INTERNO (SOBRE)-->

            <!--BOX LOGIN-->
            <brincadeira:login runat="server" ID="login" />

            <!--BLOG-->
            <brincadeira:blog runat="server" ID="blog" />

        </div>
    </section>
    <!--FIM DO CONTEUDO-->

    <!--RODAPÉ-->
    <brincadeira:footer runat="server" ID="footer" />
    <!--FIM DO RODAPÉ-->

</body>
</html>

