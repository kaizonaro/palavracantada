<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="BrincaderiasMusicais.administracao.inc.menu" %>
<header class="all">
    <div class="all_center">
        <div id="logo">
            <h1 class="logo">
                <img src="images/logo.png" alt="Logo">
            </h1>
        </div>
        <div class="info_user">
            <div class="icon_user">
                <img src="images/user_ok.png" alt="Opções">
                <p id="usuario" runat="server"></p>
            </div>
            <nav class="user_menu">
                <ul>
                    <li><a href="javascript:void(0)">Alterar senha</a></li>
                    <li><a href="javascript:void(0)">Dados Pessoais</a></li>
                    <li><a href="javascript:void(0)">Sair</a></li>
                </ul>
            </nav>
        </div>
        <!--MENU-->
        <nav id="menu">
            <ul>
                <li><a href="#"><img src="images/home.png" alt="home"><p>xxxxx</p></a></li>
                <li><a href="#"><img src="images/home.png" alt="home"><p>xxxxx</p></a></li>
                <li><a href="#"><img src="images/home.png" alt="home"><p>xxxxx</p></a></li>
                <li><a href="#"><img src="images/home.png" alt="home"><p>xxxxx</p></a></li>
                <li><a href="#"><img src="images/home.png" alt="home"><p>xxxxx</p></a></li>
            </ul>
        </nav>
            <!--FIM DO MENU-->
    </div>
</header>