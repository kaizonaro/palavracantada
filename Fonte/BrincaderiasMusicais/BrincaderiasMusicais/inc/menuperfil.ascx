<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menuperfil.ascx.cs" Inherits="BrincaderiasMusicais.inc.menuperfil" %>
<div class="menu_perfil">
    <p class="sub_perfil">Ajustes de seu perfil</p>
    <span class="primeiro" id="editarfoto" runat="server"><a href="editar-foto-perfil">Editar foto de perfil</a></span>
    <span class="segundo" id="editarbiografia" runat="server"><a href="editar-biografia">Editar mini-biografia</a></span>
    <span class="terceiro" id="configuracoes" runat="server"><a href="editar-configuracoes">configurações</a></span>

    <p class="sub_perfil">Adicionar Conteúdo</p>
    <span class="quarto"><a href="/enviar-post">Adicionar Post</a></span>
    <span class="quinto"><a href="/enviar-foto">Adicionar Foto</a></span>
    <span class="sexto"><a href="/enviar-video">Adicionar Video</a></span>
</div>