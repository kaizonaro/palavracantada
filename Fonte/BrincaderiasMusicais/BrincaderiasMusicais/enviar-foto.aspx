<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviar-foto.aspx.cs" Inherits="BrincaderiasMusicais.enviar_foto" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>

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
                <div class="img_perfil">
                    <img src="/images/img_perfil.jpg" />
                </div>
                <div class="nome_perfil">
                    Ana Maria Silva dos Santos
                </div>
                <div class="regiao_perfil">
                    << nome da região do usuário >>
                </div>
                <div class="txt txt_perfil">
                    Biografia do usuário com até 250 caracteres lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse blandit neque vel aliquam aliquet. Suspendisse hendrerit varius nisi, id sagittis neque ullamcorper et proin pulvinar blandit est libero.
                </div>
                <br />
                <div class="links_box">
                    <div class="img_links">
                        <a href="#" title="Minhas fotos">
                            <img src="/images/fotos_perfil.png" alt="Minhas Fotos" /></a>
                    </div>
                    <div class="img_links">
                        <a href="#" title="Minhas fotos">
                            <img src="/images/videos_perfil.png" alt="Minhas Fotos" /></a>
                    </div>
                    <div class="img_links">
                        <a href="#" title="Minhas fotos">
                            <img src="/images/blog_perfil.png" alt="Minhas Fotos" /></a>
                    </div>
                </div>
                <img src="/images/linha.png" class="linha" />
                <form id="up_foto">
                    <div class="titu_setup">Adicionar Foto:</div>
                    <p class="mini_txt">Para publicar uma foto, preencha os campos abaixo e clique no botão "publicar foto”.</p>
                    <div class="left">
                        <label class="label">Legenda da foto</label>
                        <input type="text" class="input" placeholder="Breve legenda" />
                    </div>
                    <div class="right">
                        <input type="file" id="subir_foto" class="esconde" />
                        <label for="subir_foto" class="subir_foto btn_save">CARREGAR ARQUIVO DA FOTO</label>
                    </div>
                    <div class="full">
                        <button class="btn_back" onclick="window.history.go(-1); return false;">Cancelar</button>
                        <input type="submit" class="btn_save" value="PUBLICAR foto"></input>
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


