<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="BrincaderiasMusicais.perfil" %>

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
                    <img id="foto" runat="server" />
                </div>
                <div class="nome_perfil" id="nomeusuario" runat="server">
                    Ana Maria Silva dos Santos
                </div>
                <div class="regiao_perfil" id="regiao" runat="server">
                    << nome da região do usuário >>
                </div>
                <div class="txt txt_perfil" id="biografia" runat="server">
                    Biografia do usuário com até 250 caracteres lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse blandit neque vel aliquam aliquet. Suspendisse hendrerit varius nisi, id sagittis neque ullamcorper et proin pulvinar blandit est libero.
                </div>
                <br />
                <div class="links_box">
                    <div class="img_links">
                        <a id="linkfotos" runat="server"   title="Minhas fotos">
                            <img src="/images/fotos_perfil2.png" alt="Minhas Fotos" /></a>
                    </div>
                    <div class="img_links">
                        <a id="linkvideos" runat="server"   title="Minhas fotos">
                            <img src="/images/videos_perfil2.png" alt="Minhas Fotos" /></a>
                    </div>
                    <div class="img_links">
                        <a id="linkblog" runat="server"   title="Minhas fotos">
                            <img src="/images/blog_perfil2.png" alt="Minhas Fotos" /></a>
                    </div>
                </div>
                <img src="/images/linha.png" class="linha" />
                <div class="menu_perfil">
                    <p class="sub_perfil_outro">Foto & vídeo (recentes)</p>
                    <div class="img_lateral_perfil">
                        <img runat="server" id="foto_outro" />
                        <img runat="server" id="video_outro" />
                    </div>
                </div>
                <div class="medalhas_perfil">
                    <p class="sub_perfil_outro">RECOMPENSAS CONQUISTADAS:</p>
                    <ul class="medalhas">
                        <!--<li class="ativo">-->
                        <li class="ativo">
                            <img src="/images/medalha_ok.png" /><p>Iniciante</p>
                        </li>
                        <li id="liDedicado" runat="server">
                            <img src="/images/medalha.png" id="imgDedicado" runat="server" /><p>Dedicado</p>
                        </li>
                        <li id="liBlogueiro" runat="server">
                            <img src="/images/medalha.png" id="imgBlogueiro" runat="server" /><p>Blogueiro</p>
                        </li>
                        <li id="liFotografo" runat="server">
                            <img src="/images/medalha.png" id="imgFotografo" runat="server" /><p>Fotografo</p>
                        </li>
                        <li id="liProdutor" runat="server">
                            <img src="/images/medalha.png" id="imgProdutor" runat="server" /><p>Produtor</p>
                        </li>
                        <li>
                            <img src="/images/medalha.png" /><p>Experiente</p>
                        </li>
                    </ul>
                </div>
                <img src="/images/linha.png" class="linha" />
                <p class="titu_blog_perfil">
                    <img src="/images/titu_blog_home.png">Blog <span id="nomeusuario1" runat="server"></span><em>(Posts Recentes)</em>
                </p>
                <ul class="posts_home" runat="server" id="posts">
                    <li>
                        <p class="titu_post_home"><a href="post/post-aberto-3">Post aberto 3</a></p>
                        <p class="desc_post_home"><a href="post/post-aberto-3">Mussum ipsum cacilds, vidis litro abertis. Consetis adipiscings elitis. Pra lá , depois divoltis porris,...</a></p>
                        <a href="post/post-aberto-3" class="btn">LEIA MAIS</a> </li>
                    <li>
                        <p class="titu_post_home"><a href="post/post-aberto-2">Post aberto 2</a></p>
                        <p class="desc_post_home"><a href="post/post-aberto-2">Mussum ipsum cacilds, vidis litro abertis. Consetis adipiscings elitis. Pra lá , depois divoltis porris,...</a></p>
                        <a href="post/post-aberto-2" class="btn">LEIA MAIS</a> </li>
                    <li>
                        <p class="titu_post_home"><a href="post/post-aberto-">Post aberto </a></p>
                        <p class="desc_post_home"><a href="post/post-aberto-">Mussum ipsum cacilds, vidis litro abertis. Consetis adipiscings elitis. Pra lá , depois divoltis porris,...</a></p>
                        <a href="post/post-aberto-" class="btn">LEIA MAIS</a> </li>
                </ul>
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


