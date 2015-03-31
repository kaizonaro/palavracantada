<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headerperfil.ascx.cs" Inherits="BrincaderiasMusicais.inc.headerperfil" %>

<div class="img_perfil" id="img_perfil" runat="server"></div>

<div class="nome_perfil" id="nome_perfil" runat="server"></div>

<div class="regiao_perfil" id="regiao_perfil" runat="server"></div>

<div class="txt txt_perfil" id="txt_perfil" runat="server"></div>
<br />

<div class="links_box">
    <div class="img_links" id="fotos" runat="server">
        <a href="minhas-fotos" title="Minhas fotos">
            <img src="/images/fotos_perfil.png" alt="Minhas Fotos" /></a>
    </div>
    <div class="img_links" id="videos" runat="server">
        <a href="meus-videos" title="Meus Videos">
            <img src="/images/videos_perfil.png" alt="Meus Videos" /></a>
    </div>

    <div class="img_links" id="blog" runat="server">
        <a href="javascript:void(0)" title="Meu Blog">
            <img src="/images/blog_perfil.png" alt="Meu Blog" />
        </a>
    </div>

</div>