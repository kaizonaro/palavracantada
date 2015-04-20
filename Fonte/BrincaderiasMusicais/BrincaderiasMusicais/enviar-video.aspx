<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviar-video.aspx.cs" Inherits="BrincaderiasMusicais.enviar_video" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>
<%@ Register Src="~/inc/headerperfil.ascx" TagPrefix="brincadeira" TagName="headerperfil" %>

<!DOCTYPE html>
enviar video
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


    <title>Palavra Cantada - Redes</title>
    <!--FACEBOOK-->
    <meta property="og:title" content="Projeto Brincadeiras Musicais da Palavra Cantada - Artigos" />
    <meta property="og:image" content="http://projetopalavracantada.net/images/logo-fb.png" />
    <meta property="og:description" content="Página de Artigos" />
    <meta property="og:url" content="http://projetopalavracantada.net/artigos" />

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

            <!--CONTEUDO INTERNO (ARTIGOS)-->
            <div id="meuperfil" class="interna">
                
                <brincadeira:headerperfil runat="server" ID="headerperfil" />

                <img src="/images/linha.png" class="linha" />
                <form id="up_foto" runat="server" action="enviar-video.aspx">
                    <div class="titu_setup">ADICIONAR VÍDEO:</div>
                    <p class="mini_txt">Para publicar um video, preencha os campos abaixo e clique no botão "publicar vídeo”.</p>
                    <div class="full">
                        <label class="label">Título do vídeo:</label>
                        <input type="text" class="input" placeholder="Escreva aqui o título do seu vídeo" name="VID_TITULO" />
                        <label class="label">Breve descritivo do vídeo:</label>
                        <textarea class="input" rows="6" placeholder="Escreva aqui um breve descritivo do seu vídeo" name="VID_DESCRICAO"></textarea>
                        <label class="label">Link (YouTube) do vídeo:</label>
                        <input type="text" class="input" name="VID_LINK" placeholder="Cole aqui o link de seu vídeo. Exemplo: http://youtu.be/e5ADrw5YpHU " />
                    </div>
                    <div class="full">
                        <button class="btn_back" onclick="window.history.go(-1); return false;">Cancelar</button>
                         <asp:Button ID="publicar_video" runat="server" Text="Publicar Video" class="btn_save" OnClick="gravarVideo" />
                    </div>
                </form>
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



