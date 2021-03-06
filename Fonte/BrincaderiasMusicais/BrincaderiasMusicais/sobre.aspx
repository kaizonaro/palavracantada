﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sobre.aspx.cs" Inherits="BrincaderiasMusicais.sobre" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
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

            <!--CONTEUDO INTERNO (SOBRE)-->
            <div id="sobre" class="interna">
                <div class="titu" id="titu" runat="server">
                    
                </div>
                <div id="breadcrumb" runat="server">
                    
                </div>
                <div class="banner_sobre">
                    <img src="/images/sobre.jpg" class="img_destaque" />
                    <img src="/images/sobre-2.jpg" class="img_destaque" />
                </div>
                
                <!--TEXTO-->
                <div class="txt" id="central" runat="server"></div>

            </div>
            <!--FIM DO CONTEUDO INTERNO (SOBRE)-->

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

    <!-- LIGHT VIEW MODAL E AFINS-->
    <div id="mask">
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
            <p>:: titulo Do video 001 ::</p>
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
                        Categoria:
                        <input type="checkbox" id="infantil" class="checkbox" /><label for="infantil">Ensino Infantil</label><input type="checkbox" id="fundamental" class="checkbox" /><label for="fundamental">Ensino Fundamental</label>
                    </div>
                    <label>senha:</label><input type="password" name="senha" class="input" placeholder="defina sua senha de acesso" /><label>Senha:</label><input type="password" name="senhanovamente" class="input" placeholder="Confirme a senha" />
                    <div>
                        <input type="checkbox" id="termo" class="checkbox termo" /><label for="termo" class='termo'>Marque esta opção para concordar com os <a href="termos/termos.html" target="_blank">termos e condições</a> do Projeto Brincadeiras Musicais da Palavra Cantada</label><nav>
                            <input class="btn" type="submit" value="cadastrar">
                            <input class="btn" type="reset" value="cancelar">
                        </nav>
                    </div>
                </form>
            </div>
        </article>
    </div>
    <!-- FIM DO LIGHT VIEW MODAL E AFINS-->
</body>
</html>
