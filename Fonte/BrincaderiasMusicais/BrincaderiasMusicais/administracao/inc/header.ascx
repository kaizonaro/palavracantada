<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="BrincaderiasMusicais.administracao.inc.menu" %>
<header class="all">
    <div class="all_center">
        <div id="logo">
            <h1 class="logo">
                <img src="images/logo2.png" alt="Logo">
            </h1>
        </div>
        <div class="info_user">
            <div class="icon_user">
                <img src="images/user_ok.png" alt="Opções">
                <p id="usuario" runat="server"></p>
            </div>
            <nav class="user_menu">
                <ul>
                    <!--<li><a href="javascript:void(0)">Alterar senha</a></li>
                    <li><a href="javascript:void(0)">Dados Pessoais</a></li>-->
                    <li><a href="logout.aspx">Sair</a></li>
                </ul>
            </nav>
        </div>
        <!--MENU-->
        <nav id="menu">
            <ul>
                <!--conheça-->
                <li><a href="javascript:void(0)"><img src="images/home.png" alt="Conheça"><p>Conheça</p></a>
                    <ul class="submenu">
                        <li><a href="sobre.aspx">Sobre</a></li>
                        <li><a href="quem-somos.aspx">Quem somos</a></li>
                        <li><a href="redes.aspx">Redes</a></li>
                        <li><a href="palavra-cantada.aspx">Palavra Cantada</a></li>
                        <li><a href="Equipe.aspx">Equipe</a></li>
                    </ul>
                </li>
                <!--explore-->
                <li><a href="javascript:void(0)"><img src="images/home.png" alt="Explore"><p>Explore</p></a>
                    <ul class="submenu">
                        <li><a href="artigos.aspx">Artigos</a></li>
                        <li><a href="albumfotos.aspx">Fotos</a></li>
                        <li><a href="playlist.aspx">Vídeos</a></li>
                    </ul>
                </li>
                <li><a href="blog.aspx"><img src="images/home.png" alt="Blog"><p>Blog</p></a></li>
                <li><a href="usuarios.aspx"><img src="images/home.png" alt="Usuários"><p>Usuários</p></a></li>
                <li><a href="banners.aspx"><img src="images/home.png" alt="home"><p>Banners</p></a></li>
                <li><a href="javascript:void(0)"><img src="images/home.png" alt="Galeria"><p>Galeria</p></a><ul class="submenu"><li><a href="videos.aspx">Vídeos</a></li><li><a href="fotos.aspx">Fotos</a></li></ul></li>
                <li><a href="contato.aspx"><img src="images/home.png" alt="Contato"><p>Contato</p></a></li>
                <li><a href="sobre.aspx"><img src="images/home.png" alt="Sobre"><p>Sobre</p></a></li>
            </ul>
        </nav>
            <!--FIM DO MENU-->
    </div>
</header>