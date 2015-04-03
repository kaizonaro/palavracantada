<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editar-biografia.aspx.cs" Inherits="BrincaderiasMusicais.editar_biografia" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>
<%@ Register Src="~/inc/headerperfil.ascx" TagPrefix="brincadeira" TagName="headerperfil" %>
<%@ Register Src="~/inc/menuperfil.ascx" TagPrefix="brincadeira" TagName="menuperfil" %>
<%@ Register Src="~/inc/blogPessoal.ascx" TagPrefix="brincadeira" TagName="blogPessoal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


    <title>Palavra Cantada - Redes</title>
    <!--FACEBOOK-->
    <meta property="og:title" content="Projeto Brincadeiras Musicais da Palavra Cantada - Artigos" />
    <meta property="og:image" content="http://projetopalavracantada.net/images/logo-fb.png" />
    <meta property="og:description" content="Página de Artigos" />
    <meta property="og:url" content="http://projetopalavracantada.net/artigos" />

    <brincadeira:script runat="server" ID="script" />
    <script type="text/javascript">
        function contarCaracteres(box, valor, campospan) {
            var conta = valor - box.length;
            document.getElementById(campospan).innerHTML = "Você ainda pode digitar " + conta + " caracteres";
            if (box.length >= valor) {
                document.getElementById(campospan).innerHTML = "Opss.. você não pode mais digitar..";
                document.getElementById("campo").value = document.getElementById("campo").value.substr(0, valor);
            }
        }
    </script>

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

            <!--CONTEUDO INTERNO (ARTIGOS)-->
            <div id="meuperfil" class="interna">
                <brincadeira:headerperfil runat="server" ID="headerperfil" />
                <img src="/images/linha.png" class="linha" />
                
                <brincadeira:menuperfil runat="server" ID="menuperfil" />
                
                <div class="medalhas_perfil">
                    <p class="sub_perfil">Editar Mini-biografia</p>
                    <p class="txt">
                        Crie ou edite a sua mini-biografia (até 250 caracteres) no campo abaixo e clique no botão salvar.
                    </p>
                    <form id="biografia" class="form" action="editar-biografia.aspx">
                        <input type="hidden" id="acao" name="acao" value="editar" />
                        <textarea class="input" maxlength="250" runat="server" id="txtTextarea" name="txtTextarea" onkeyup="contarCaracteres(this.value,250,'sprestante')"></textarea>
                        <span style="font-size: 8px; float: right; width: 100%; height: 20px;" id="sprestante"></span>

                        <button class="btn_back" onClick="window.history.go(-1); return false;"><< voltar</button> 
                        <input type="submit" class="btn_save" value="salvar alterações" />
                    </form>
                </div>
                
                <img src="/images/linha.png" class="linha" />
               
                 <!-- BLOG-->
                <brincadeira:blogPessoal runat="server" ID="blogPessoal" />

            </div>
            <!--FIM DO CONTEUDO INTERNO (ARTIGOS)-->

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


