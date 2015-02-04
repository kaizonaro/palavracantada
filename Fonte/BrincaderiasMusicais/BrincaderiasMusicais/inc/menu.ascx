<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="BrincaderiasMusicais.inc.menu" %>
<nav id="menu" class="all">
    <div class="all_center">
        <ul class="menu">
            <li class="conheca"><a href="/sobre-o-projeto" title="Conheça" id="conheca" runat="server">Conheça</a>
                <div class="sub_menu">
                    <img src="/images/sub_1.png" class="sub_arrow" />
                    <ul>
                        <li><a href="/sobre-o-projeto">Sobre o projeto</a></li>
                        <li><a href="/quem-somos">Quem Somos</a></li>
                        <li><a href="/redes-participantes">Redes Participantes</a></li>
                        <li><a href="/palavra-cantada">Palavra Cantada</a></li>
                        <li><a href="javascript:void(0);">Equipe</a></li> 
                    </ul>
                </div>
            </li>
            <li class="explore"><a href="javascript:void(0);" title="Explore" id="explore" runat="server">Explore</a>
                <div class="sub_menu">
                    <img src="/images/sub_2.png" class="sub_arrow" />
                    <ul>
                        <li><a href="/artigos">Artigos</a></li>
                        <li><a href="/fotos">Fotos</a></li>
                        <li><a href="/videos">Vídeos</a></li>
                    </ul>
                </div>
            </li>
            <li class="blog"><a href="/blog" title="Blog" id="blog" runat="server">Blog</a></li>
            <li class="contato"><a href="/contato" title="Contato" id="contato" runat="server">Contato</a></li>
        </ul>
        <ul class="sociais">
            <li>
                <div class="fb-like" data-href="https://www.facebook.com/brincamusicais" data-layout="button_count" data-action="like" data-show-faces="false" data-share="false"></div>
            </li>
            <li><a href="https://twitter.com/brincamusicais" class="twitter-follow-button" data-show-count="false" data-lang="pt" data-show-screen-name="true" data-dnt="true">Seguir @brincamusicais</a>
                <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
            </li>
            <li>
                <div class="g-plusone" data-annotation="none" data-href="https://plus.google.com/101886201744248377514/posts"></div>
            </li>
        </ul>
    </div>
</nav>
