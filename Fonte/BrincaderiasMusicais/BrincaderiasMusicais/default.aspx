﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BrincaderiasMusicais._default" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
            <div class="blog_home">
                <p class="titu">
                    <!-- if logado BLOG REGIONAL - << NOME DA REGIÃO >> else -->
                    Blog brincadeiras musicais:<em>(posts REcentes)</em></p>
                <ul class="posts_home">
                    <li><a href="#" title="Titulo da postagem">
                        <img src="images/img_blog_home.jpg" /></a>
                        <p class="titu_post_home"><a href="#">VAI O TÍTULO DO PRIMEIRO POST.</a></p>
                        <p class="desc_post_home"><a href="#">Lorem ipsum doren est signat magna est lorem ipsum doren non signat doren lorem signat magna est lorem es ipsum...</a></p>
                        <a href="#" class="btn">LEIA MAIS</a>
                    </li>
                    <li><a href="#" title="Titulo da postagem">
                        <img src="images/img_blog_home.jpg" /></a>
                        <p class="titu_post_home"><a href="#">VAI O TÍTULO DO PRIMEIRO POST.</a></p>
                        <p class="desc_post_home"><a href="#">Lorem ipsum doren est signat magna est lorem ipsum doren non signat doren lorem signat magna est lorem es ipsum...</a></p>
                        <a href="#" class="btn">LEIA MAIS</a>
                    </li>
                    <li><a href="#" title="Titulo da postagem">
                        <img src="images/img_blog_home.jpg" /></a>
                        <p class="titu_post_home"><a href="#">VAI O TÍTULO DO PRIMEIRO POST.</a></p>
                        <p class="desc_post_home"><a href="#">Lorem ipsum doren est signat magna est lorem ipsum doren non signat doren lorem signat magna est lorem es ipsum...</a></p>
                        <a href="#" class="btn">LEIA MAIS</a>
                    </li>
                </ul>
            </div>
            <!--BOX LOGIN-->
            <brincadeira:login runat="server" ID="login" />
            <!--FIM DO BOX LOGIN-->

            <!--GALERIA-->
            <div class="galeria_home">
                <div class="titu">GALERIA COLABORATIVA BRINCADEIRAS MUSICAIS:
                    <div class="ops_galeria"><b class="ativo">
                        <img src="images/icone_foto.png" alt="icone de camera fotografica" />
                        Fotos</b> <b>
                            <img src="images/icone_video.png" alt="icone de filmadora" />
                            Vídeo</b></div>
                </div>
                <ul class="fotos_home">
                    <li>
                        <a href="galeria.jpg">
                            <img src="images/thumb_galeria.jpg" alt="Imagem X" /></a>
                        <p>:: LEGANDA DA FOTO 001 ::</p>
                    </li>
                    <li>
                        <a href="galeria2.jpg">
                            <img src="images/thumb_galeria.jpg" alt="Imagem X" /></a>
                        <p>:: LEGANDA DA FOTO 002 ::</p>
                    </li>
                    <li>
                        <a href="galeria.jpg">
                            <img src="images/thumb_galeria.jpg" alt="Imagem X" /></a>
                        <p>:: LEGANDA DA FOTO 003 ::</p>
                    </li>
                    <li>
                        <a href="galeria2.jpg">
                            <img src="images/thumb_galeria.jpg" alt="Imagem X" /></a>
                        <p>:: LEGANDA DA FOTO 004 ::</p>
                    </li>
                </ul>
                <ul class="videos_home">
                    <li>
                        <a href="CaTXgmHyMSk">
                            <img src="images/thumb_galeria.jpg" alt="Vídeo X" /></a>
                        <p>:: titulo Do video 001 ::</p>
                    </li>
                    <li>
                        <a href="IkNeY5S_BKk">
                            <img src="images/thumb_galeria.jpg" alt="Vídeo X" /></a>
                        <p>:: titulo Do video 002 ::</p>
                    </li>
                    <li>
                        <a href="CaTXgmHyMSk">
                            <img src="images/thumb_galeria.jpg" alt="Vídeo X" /></a>
                        <p>:: titulo Do video 003 ::</p>
                    </li>
                    <li>
                        <a href="IkNeY5S_BKk">
                            <img src="images/thumb_galeria.jpg" alt="Vídeo X" /></a>
                        <p>:: titulo Do video 004 ::</p>
                    </li>
                </ul>
            </div>
            <!--FIM DA GALERIA-->
        </div>
    </section>
    <!--FIM DO CONTEUDO-->

    <!--RODAPÉ-->
    <brincadeira:footer runat="server" ID="footer" />
    <!--FIM DO RODAPÉ-->

    <!-- LIGHT VIEW MODAL E AFINS-->
    <div id="mask">
        <article id="fotos">
            <img src="images/galeri0202a.jpg" class="img_galeria" />
            <p>:: LEGANDA DA FOTO 001 ::</p>
            <div class="controles">
                <div class="left_galeria">
                    <img src="images/arrow_left2.png" /></div>
                <div class="quantos"><b class="atual">1</b>/<b class="total">4</b></div>
                <div class="right_galeria">
                    <img src="images/arrow_right2.png" /></div>
                <div class="fechar_galeria fechar_foto">FECHAR</div>
            </div>
        </article>

        <article id="videos">
            <iframe width="640" height="360" src="//www.youtube.com/embed/CaTXgmHyMSk" frameborder="0" allowfullscreen></iframe>
            <p>:: titulo Do video 001 ::</p>
            <div class="controles">
                <div class="left_galeria">
                    <img src="images/arrow_left2.png" /></div>
                <div class="quantos"><b class="atual">1</b>/<b class="total">4</b></div>
                <div class="right_galeria">
                    <img src="images/arrow_right2.png" /></div>
                <div class="fechar_galeria fechar_foto">FECHAR</div>
            </div>
        </article>
        <article id="modal">
            <div class="Modal">
                <p class="titu">PROJETO BRINCADEIRAS MUSICAIS DA PALAVRA CANTADA - CADASTRO DE USUÁRIO:</p>
                <p class="sub_titu">Preencha o cadastro abaixo para cadastrar o seu usuário de acesso a área restrita do projeto, lorem ipsum doren est signat lorem magna lorem ipsum doren est signat lorem magna lorem ipsum doren est signat lorem magna lorem ipsum doren est signat lorem magna non signat.</p>
                <form class="cadastro_home">
                    <label>Nome:</label><input type="text" name="nome" class="input" /><label>Email:</label><input type="text" name="email" class="input email" />
                    <select class="input">
                        <option value="">Selecione o Cargo</option>
                        <option value="1">opcao 1</option>
                        <option value="2">opcao 2</option>
                        <option value="3">opcao 3</option>
                    </select>
                    <div>
                       Categoria: <input type="checkbox" id="infantil" class="checkbox" /><label for="infantil">Ensino Infantil</label><input type="checkbox" id="fundamental" class="checkbox" /><label for="fundamental">Ensino Fundamental</label>
                    </div>
                    <label>senha:</label><input type="password" name="senha" class="input" placeholder="defina sua senha de acesso" /><label>Senha:</label><input type="password" name="senhanovamente" class="input" placeholder="Confirme a senha" />
                    <div><input type="checkbox" id="termo" class="checkbox termo" /><label for="termo" class='termo'>Marque esta opção para concordar com os termos e condições do Projeto Brincadeiras Musicais da Palavra Cantada</label><nav> <input class="btn" type="submit" value="cadastrar"> <input class="btn" type="reset" value="cancelar"></nav></div>
                </form>
            </div>
        </article>
    </div>
    <!-- FIM DO LIGHT VIEW MODAL E AFINS-->
</body>
</html>
