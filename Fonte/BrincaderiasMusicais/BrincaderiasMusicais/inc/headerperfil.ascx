<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headerperfil.ascx.cs" Inherits="BrincaderiasMusicais.inc.headerperfil" %>

                <div class="img_perfil" id="img_perfil" runat="server">
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
    <div class="img_links" id="fotos" runat="server">
        <a href="/minhas-fotos" title="Minhas fotos" id="linkfotos" runat="server"  >
            <img src="/images/fotos_perfil.png" alt="Minhas Fotos" /></a>
    </div>
    <div class="img_links" id="videos" runat="server">
        <a href="/meus-videos" title="Meus Videos" id="linkvideos" runat="server" >
            <img src="/images/videos_perfil.png" alt="Meus Videos" /></a>
    </div>

    <div class="img_links" id="blog" runat="server">
        <a href="/meu-blog" title="Meu Blog" id="linkblog" runat="server">
            <img src="/images/blog_perfil.png" alt="Meu Blog" />
        </a>
    </div>

</div>