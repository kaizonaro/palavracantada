<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviar-post.aspx.cs" Inherits="BrincaderiasMusicais.enviar_post" %>

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
            <div id="meuperfil" class="interna">
               
                <brincadeira:headerperfil runat="server" ID="headerperfil" />

                <img src="/images/linha.png" class="linha" />
                <form id="up_foto" runat="server">
                    <input type="hidden" id="POS_ID" value="0"/>
                    <div class="titu_setup">ADICIONAR Post:</div>
                    <p class="mini_txt">Para publicar uma foto, preencha os campos abaixo e clique no botão "publicar post".</p>
                    <div class="full">
                        <label class="label">Título do post:</label>
                        <input type="text" class="input" placeholder="Escreva aqui o título do seu post" id="POS_TITULO" name="POS_TITULO" runat="server" />

                        <label class="label" for="POS_IMAGEM">Imagem do post:</label>
                        <asp:FileUpload ID="POS_IMAGEM" runat="server" CssClass="obg esconde" />
                        
                        <label for="subir_foto" class="subir_foto btn_save">CARREGAR ARQUIVO DA FOTO</label>
                        <select name="PCA_ID" runat="server" id="PCA_ID" data-validation="required" class="input obg" >
                            <option value="">Selecione a categoria</option>
                        </select>
                        
                        <label class="label">Texto do post:</label>
                        <textarea class="input" rows="15" placeholder="Escreva aqui o texto de seu post" name="POS_TEXTO" id="POS_TEXTO" runat="server"></textarea>
                    </div>
                    <div class="full up_post_btn">

                        <asp:Button ID="pub" runat="server" Text="PUBLICAR POST" OnClick="gravar" class="btn_save" />
                        <button class="btn_back" onclick="window.history.go(-1); return false;">Cancelar</button>
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



