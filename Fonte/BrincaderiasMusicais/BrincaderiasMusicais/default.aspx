<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BrincaderiasMusicais._default" %>

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

    <script type="text/javascript">
        function validarSenha() {
            senha1 = document.frmCadastro.USU_SENHA.value
            senha2 = document.frmCadastro.USU_SENHA2.value

            if (senha1.length > 5 && senha1.length < 13) {
                if (senha1 == senha2) {
                    $("#frmCadastro").attr("action", "ajax/acoes.aspx");
                    $("#frmCadastro").submit();
                } else {
                    alert("A senha e o confirmar senha estão diferentes");
                    return false;
                }
            } else {
                alert("A senha deve ter no minimo 6 caracteres e no maximo 12");
                return false;
            }
        }
    </script>

</head>
<body id="body" runat="server">

    <!--TOPO-->
    <brincadeira:header runat="server" ID="header" />
    <!--FIM DO TOPO-->

    <!--MENU-->
    <brincadeira:menu runat="server" ID="menu" />
    <!--FIM DO MENU-->

    <!-- CONTEUDO-->
    <section class="all">
        <div class="all_center">

            <!--BLOG-->
            <div class="blog_home">

                <p class="titu" runat="server" id="pBlog"></p>
                <ul class="posts_home" id="ulPost" runat="server"></ul>
            </div>

            <!--BOX LOGIN-->
            <brincadeira:login runat="server" ID="login" />

            <!--GALERIA-->
            <div class="galeria_home">

                <div class="titu">
                    GALERIA COLABORATIVA BRINCADEIRAS MUSICAIS:
                    <div class="ops_galeria">
                        <b class="ativo">
                            <img src="/images/icone_foto.png" alt="icone de camera fotografica" />
                            Fotos</b> <b>
                                <img src="/images/icone_video.png" alt="icone de filmadora" />
                                Vídeos</b>
                    </div>
                </div>
                <div class="mascara">
                    <!-- FOTOS -->
                    <ul class="fotos_home carrousel" id="ulFotos" runat="server"></ul>
                    <div class="left_video"><img src="images/arrow_left2.png" /></div>
                    <div class="right_video"><img src="images/arrow_right2.png" /></div>
                </div>
                <div class="mascara">
                    <!-- VIDEOS -->
                    <ul class="videos_home carrousel" id="ulVideos" runat="server"></ul>
                    <div class="left_video"><img src="images/arrow_left2.png" /></div>
                    <div class="right_video"><img src="images/arrow_right2.png" /></div>
                </div>
            </div>
            <!--FIM DA GALERIA-->
        </div>
    </section>
    <!--FIM DO CONTEUDO-->

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
        <article id="modal" runat="server">
            <div class="Modal">
                <p class="titu">PROJETO BRINCADEIRAS MUSICAIS DA PALAVRA CANTADA - CADASTRO DE USUÁRIO:</p>
                <p class="sub_titu">Preencha o cadastro abaixo para cadastrar o seu usuário de acesso a área restrita do projeto.</p>
                <form id="frmCadastro" name="frmCadastro" class="cadastro_home" action="javascript:void(0);">
                    <div class="full">
                        <input type="hidden" name="acao" id="acao" value="completarCadastro" />
                        <input type="hidden" name="TOK_TOKEN" id="TOK_TOKEN" value="" runat="server" />
                        <label>Nome*:
                            <br />
                        </label>
                        <input type="text" name="USU_NOME" id="USU_NOME" class="input inp_grande" /><br />
                        <label>Email*:<br />
                        </label>
                        <input type="text" name="USU_EMAIL" id="USU_EMAIL" class="input email inp_grande" />
                    </div>
                    <div class="left">
                        <strong>Cargo: </strong>
                        <br />
                        <select id="CAR_ID" name="CAR_ID" class="input obg" data-validation="required" runat="server">
                            <option value="">Selecione o Cargo</option>
                        </select>
                    </div>

                    <div class="right">
                        <strong>Categoria: </strong>
                        <br />
                        <input type="checkbox" id="fundamental" name="CAT_ID" class="checkbox" value="2" /><label for="fundamental">Ensino Fundamental</label>
                        <input type="checkbox" id="infantil" name="CAT_ID" class="checkbox" value="1" /><label for="infantil">Ensino Infantil</label>
                    </div>
                    <div class="full">
                        <label>senha:</label><input type="password" name="USU_SENHA" id="USU_SENHA" class="input" placeholder="defina sua senha de acesso" />
                        <input type="password" name="USU_SENHA2" id="USU_SENHA2" class="input" placeholder="digite aqui novamente a senha definida" />
                    </div>
                    <div>
                        <input type="checkbox" id="termo" class="checkbox termo" /><label for="termo" class='termo'>Marque esta opção para concordar com os termos e condições do Projeto Brincadeiras Musicais da Palavra Cantada</label>
                        <nav>
                            <input class="btn" type="button" value="cadastrar">
                            <!-- <input class="btn" type="reset" value="cancelar">-->
                        </nav>
                    </div>
                </form>
            </div>
        </article>
    </div>
    <!-- FIM DO LIGHT VIEW MODAL E AFINS-->
</body>
</html>
