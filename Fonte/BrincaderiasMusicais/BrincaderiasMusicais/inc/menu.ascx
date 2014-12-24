<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="BrincaderiasMusicais.inc.menu" %>
<nav id="menu" class="all">
    <div class="all_center">
        <ul class="menu">
            <li class="conheca"><a href="/sobre-o-projeto" title="Coneça" id="conheca" runat="server">Conheça</a></li>
            <li class="explore"><a href="javascript:void(0);" title="Explore" id="explore" runat="server">Explore</a></li>
            <li class="blog"><a href="javascript:void(0)" title="Blog" id="blog" runat="server">Blog</a></li>
            <li class="contato"><a href="javascript:void(0)" title="Contato" id="contato" runat="server">Contato</a></li>
        </ul>
        <ul class="sociais">
            <li><div class="fb-like" data-href="https://www.facebook.com/palavracantada?fref=ts" data-layout="button_count" data-action="like" data-show-faces="false" data-share="false"></div></li>
            <li><a href="https://twitter.com/palavra_cantada" class="twitter-follow-button" data-show-count="false" data-lang="pt" data-show-screen-name="true" data-dnt="true">Seguir @palavra_cantada</a>
<script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script></li>
            <li><div class="g-plusone" data-annotation="none" data-href="https://plus.google.com/+palavracantada/posts"></div></li>
        </ul>
    </div>
</nav>
