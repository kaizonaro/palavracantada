<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="galeria-geral.aspx.cs" Inherits="BrincaderiasMusicais.galeria_geral" %>

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
    <meta property="og:title" content="Projeto Brincadeiras Musicais da Palavra Cantada - Galeria Colaborativa" />
    <meta property="og:image" content="http://projetopalavracantada.net/images/logo-fb.png" />
    <meta property="og:description" content="Galeria Colaborativa" />
    <meta property="og:url" content="http://projetopalavracantada.net/galeria-colaborativa" />

    <brincadeira:script runat="server" ID="script" />


    <script>
        function showform(idform, iddiv) {
            $("#" + idform).fadeToggle();
            $("#" + iddiv).fadeToggle();
        }
    </script>

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
            <div id="sobre" class="interna">
                <div class="titu">
                    Galeria Colaborativa
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong>Galeria Colaborativa</strong>
                </div>



                <!-- INCLUDE -->
                <p class="titu_agenda">Galeria Colaborativa de Fotos</p>
                <span id="fotodiv" runat="server">
                    <p class="sub_galeria_geral">
                        Fotografias enviadas pelos membros da rede de ensino de <strong id="nomerede1" runat="server"></strong>
                        (use as setas para navegar nas fotos e clique na foto para ampliá-la).
                    </p>
                    <div class="galeria_geral">

                        <div class="mascara">
                            <!-- FOTOS -->
                            <ul id="ulFotos" class="fotos_home carrousel" rel="0" runat="server">
                            </ul>
                            <div class="left_video">
                                <img src="/images/arrow_left2.png">
                            </div>
                            <div class="right_video">
                                <img src="/images/arrow_right2.png">
                            </div>
                        </div>

                    </div>

                    <div class="upload_geral" runat="server">
                        <p>Participe da Galeria Colaborativa de Fotos!</p>
                        <a onclick="showform('up_foto','fotodiv')">
                            <img src="images/foto_icon.png" alt="Icone Camera" />
                            CLIQUE PARA ENVIAR A SUA FOTO</a>
                    </div>
                </span>
                <form id="up_foto" runat="server" style="display: none" action="galeria-geral.aspx">
                    <div class="titu_setup">Adicionar Foto:</div>
                    <p class="mini_txt">Para publicar uma foto, preencha os campos abaixo e clique no botão "publicar foto".</p>
                    <div class="left">
                        <label class="label">Legenda da foto</label>
                        <input type="text" class="input" placeholder="Breve legenda" id="COF_LEGENDA" name="COF_LEGENDA" />
                    </div>
                    <div class="right">
                        <asp:FileUpload ID="COF_IMAGEM" runat="server" CssClass="esconde" />
                        <label for="COF_IMAGEM" class="subir_foto btn_save">CARREGAR ARQUIVO DA FOTO</label>
                    </div>

                    <div class="full">

                        <button class="btn_back" onclick="showform('up_foto','fotodiv')">Cancelar</button>
                        <asp:Button ID="PublicarFoto" class="btn_save" runat="server" Text="Publicar foto" OnClick="gravar" />
                    </div>
                </form>
               
                <img src="/images/linha.png" class="linha" />
                <p class="titu_agenda" id="pVideos">Galeria Colaborativa de Vídeos</p>
                <span id="videodiv" runat="server">
                    <p class="sub_galeria_geral">
                        Vídeos enviados pelos membros da rede de ensino de  <strong id="nomerede2" runat="server"></strong>
                        (use as setas para navegar nos vídeos e clique na imagem para assistir o vídeo).
                    </p>

                    <div class="galeria_geral">
                        <div class="mascara">
                            <!-- VIDEOS -->
                            <ul id="ulVideos" class="videos_home carrousel" rel="0" style="display: block;" runat="server">
                            </ul>
                            <div class="left_video">
                                <img src="/images/arrow_left2.png">
                            </div>
                            <div class="right_video">
                                <img src="/images/arrow_right2.png">
                            </div>
                        </div>
                    </div>


                    <div class="upload_geral" runat="server">
                        <p>Participe da Galeria Colaborativa de Vídeos!</p>
                        <a onclick="showform('up_video','videodiv')">
                            <img src="images/icone_video.png" alt="Icone Camera" />
                            CLIQUE PARA ENVIAR O SEU VÍDEO</a>
                    </div>
                </span>
                <form id="up_video" style="display: none" action="galeria-geral.aspx">
                    <input type="hidden" name="acao" value="gravavideo" />
                    <div class="titu_setup">ADICIONAR VÍDEO:</div>
                    <p class="mini_txt">Para publicar um vídeo, preencha os campos abaixo e clique no botão "publicar vídeo".</p>
                    <div class="full">
                        <label class="label">Título do vídeo:</label>
                        <input type="text" class="input" placeholder="Escreva aqui o título do seu vídeo" name="COV_TITULO" />
                        <label class="label">Breve descritivo do vídeo:</label>
                        <textarea class="input" rows="6" placeholder="Escreva aqui um breve descritivo do seu vídeo" name="COV_DESCRICAO"></textarea>
                        <label class="label">Link (YouTube) do vídeo:</label>
                        <input type="text" class="input" name="COV_LINK" placeholder="Cole aqui o link de seu vídeo. Exemplo: http://youtu.be/e5ADrw5YpHU " />
                    </div>
                    <div class="full">
                         <button class="btn_back" onclick="showform('up_video','videodiv')">Cancelar</button>
                        
                        <input type="submit" id="publicar_video" value="Publicar Vídeo" class="btn_save" />
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
    <!--RODAPÉ-->
    <brincadeira:footer runat="server" ID="footer" />
    <!--FIM DO RODAPÉ-->

    <!-- LIGHT VIEW MODAL E AFINS-->
    <div id="mask" runat="server">
        <article id="fotos">
            <img src="/images/galeri0202a.jpg" class="img_galeria" />
            <p>:: LEGANDA DA FOTO 001 ::</p>
            <div class="controles">
                <div class="left_galeria">
                    <img src="/images/arrow_left2.png" />
                </div>
                <div class="quantos"><b class="atual">1</b>/<b class="total">4</b></div>
                <div class="right_galeria">
                    <img src="/images/arrow_right2.png" />
                </div>
                <div class="fechar_galeria fechar_foto">FECHAR</div>
            </div>
        </article>

        <article id="videos">
            <iframe width="640" height="360" src="//www.youtube.com/embed/CaTXgmHyMSk" frameborder="0" allowfullscreen></iframe>
            <p>:: titulo Do vídeo 001 ::</p><br />
            <span></span><br />
            <div class="controles">
                <div class="left_galeria">
                    <img src="/images/arrow_left2.png" />
                </div>
                <div class="quantos"><b class="atual">1</b>/<b class="total">4</b></div>
                <div class="right_galeria">
                    <img src="/images/arrow_right2.png" />
                </div>
                <div class="fechar_galeria fechar_foto">FECHAR</div>
            </div>
        </article>
    </div>
    <script>
        var url = location.href;
        if (url.indexOf("sucesso=2") != -1) {
            $('html, body').animate({
                scrollTop: $("#pVideos").offset().top
            }, 2000);
        }
</script>


    <!-- FIM DO LIGHT VIEW MODAL E AFINS-->
</body>
</html>
