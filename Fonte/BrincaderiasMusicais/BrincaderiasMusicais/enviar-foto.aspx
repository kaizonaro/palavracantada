﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviar-foto.aspx.cs" Inherits="BrincaderiasMusicais.enviar_foto" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>
<%@ Register Src="~/inc/headerperfil.ascx" TagPrefix="brincadeira" TagName="headerperfil" %>

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
             <!-- INCLUDE -->
               <div id="meuperfil" class="interna">
                
                <brincadeira:headerperfil runat="server" ID="headerperfil" />

                <img src="/images/linha.png" class="linha" />
                <form id="up_foto" runat="server">
                    <div class="titu_setup">Adicionar Foto:</div>
                    <p class="mini_txt">Para publicar uma foto, preencha os campos abaixo e clique no botão "publicar foto”.</p>
                    <div class="left">
                        <label class="label">Legenda da foto</label>
                        <input type="text" class="input" placeholder="Breve legenda" id="FOT_LEGENDA" name="FOT_LEGENDA" />
                    </div>
                    <div class="right">
                        <asp:FileUpload ID="FOT_IMAGEM" runat="server" CssClass="esconde" />
                        <label for="FOT_IMAGEM" class="subir_foto btn_save">CARREGAR ARQUIVO DA FOTO</label>
                    </div>

                    <div class="full">
                        
                        <button class="btn_back" onclick="window.history.go(-1); return false;">Cancelar</button>
                        <asp:Button ID="PublicarFoto" class="btn_save" runat="server" Text="Publicar foto" OnClick="gravar" />
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


