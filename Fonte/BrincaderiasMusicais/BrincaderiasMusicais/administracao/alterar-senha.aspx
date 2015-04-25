<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alterar-senha.aspx.cs" Inherits="BrincaderiasMusicais.administracao.alterar_senha" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Alterar Senha</title>
    <brincadeira:script runat="server" id="script" />
    <script src="tinymce/tinymce.min.js"></script>

    <script type="text/javascript">
        function validarSenha() {
            senha1 = document.frmSenhas.senha1.value
            senha2 = document.frmSenhas.senha2.value
            if (senha1.length > 5 && senha1.length < 13) {
                if (senha1 == senha2) {
                    $("#frmBriefing").attr("action", "alterar-senha.aspx");
                    $("#frmBriefing").submit();
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

<body>
    <!--HEADER-->
    <brincadeira:header runat="server" id="header" />
    <!--FIM DO HEADER-->

    <!--CONTEUDO GERAL-->
    <section class="all">
        <div class="all_center">
            <section id="conteudo">
                <h2>
                    <img src="images/home.png" alt="inicio"><br>
                    Alterar Senha</h2>
                <!-- TABELA-->
                <div class="content">
                    <form class="" name="frmSenhas" id="frmBriefing" action="javascript:void(0);" method="post" novalidate accept-charset="default">
                        <input type="hidden" id="acao" name="acao" value="AlterarSenha" />

                        <p>Senha nova:</p>
                        <input type="password" name="senha1" id="senha1" size="20" class="obg input" data-validation="required" />

                        <p>Confirmar Senha:</p>
                        <input type="password" name="senha2" size="20" class="obg input" data-validation="required" />
                        <br>
                        <br>
                        <input type="button" class="btn_form" value="Alterar" onclick="validarSenha()">
                    </form>

                </div>
            </section>
        </div>

        <!--FIM DA TABELA-->
    </section>
    <!--FIM DO CONTEUDO GERAL-->
    <footer class='footer'>
    </footer>
</body>
</html>
