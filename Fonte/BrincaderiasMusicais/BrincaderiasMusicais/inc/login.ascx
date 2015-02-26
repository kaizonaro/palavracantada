﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="BrincaderiasMusicais.inc.login" %>
<script type="text/javascript">

    function ajaxInit() {
        var req;
        try {
            req = new ActiveXObject("Microsoft.XMLHTTP");
        } catch (e) {
            try {
                req = new ActiveXObject("Msxml2.XMLHTTP");
            } catch (ex) {
                try {
                    req = new XMLHttpRequest();
                } catch (exc) {
                    alert("Esse browser não tem recursos para uso do Ajax");
                    req = null;
                }
            }
        }
        return req;
    }

    function sair() {
        window.location = "/ajax/acoes.aspx?acao=logout"
        return false;
    }

    function pesquisablog(nome, variavel) {
        ajax4 = ajaxInit();
        ajax4.open("GET", "/administracao/ajax/acoes.aspx?acao=PesquisaBlog&" + nome.replace("login_","") + "=" + variavel, true);
        ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
        ajax4.onreadystatechange = function () {

            if (ajax4.readyState == 4) {

                if (ajax4.status == 200) {
                    resposta = ajax4.responseText.split("<!DOCTYPE html>");

                    $("#divArtigos").html(resposta[0])



                }
            }

        }
        ajax4.send(null);

    }

</script>
<aside id="sidebar">
    <div class="box_login" id="box_login" runat="server">
        <p>Faça o login para acessar a área restrita de sua região:<span id="msgErro" runat="server"></span></p>
        <form class="form_login" action="/ajax/acoes.aspx">
            <input type="hidden" id="acao" name="acao" value="FazerLogin" />
            <label>E-mail:</label><input type="text" id="email" name="email" class="input email" /><label>Senha:</label><input type="password" id="senha" name="senha" class="input" /><br />
            <div>
                <a href="javascript:void(0)" class="link esqueci_senha">esqueci minha senha</a>
                <!--<a href="javascript:void(0)" class="link">esqueci meu login</a>-->
                <input class="btn" type="submit" value="ENTRAR" />
            </div>
        </form>
        <form class="form_senha" action="">
            <input type="hidden" id="acao" name="acao" value="FazerLogin" />
            <label>email:</label><input type="text" id="email" name="email" class="input email" /><br />
            <div>
                <a href="javascript:void(0)" class="link esqueci_voltar">voltar</a>
                <!--<a href="javascript:void(0)" class="link">esqueci meu login</a>-->
                <input class="btn" type="submit" value="ENVIAR" />
            </div>
        </form>
    </div>
    <div class="banner_sidebar" id="banner_sidebar" runat="server">
        <a href="http://palavracantada.com.br" title="Conmheça o site oficial do palalavra cantada" target="_blank">
            <img src="/images/banner_lateral.png" alt="Conmheça o site oficial do palalavra cantada" /></a>
    </div>

    <div class="box_login esconde" style="margin-top: 10px;" id="divBlog" runat="server">
        <p>BUSCAR NO BLOG BRINCADEIRAS MUSICAIS:</p>
        <form class="form_pesquisa" action="javascript:void(0);">
            <input type="text" name="pesquisar" class="input" id="POS_TEXTO" /><input type="button" class="btn" value="OK" onclick='pesquisablog(POS_TEXTO.id, POS_TEXTO.value)' />
            <div>
                <p>ARQUIVO DO BLOG:</p>
                <select name="data" runat="server" id="POS_DH_CRIACAO" onchange="pesquisablog(this.id, this.value)">
                    <option value="" selected>Selecione o mês / ano</option>
                </select>
            </div>
            <div>
                <p>CATEGORIAIS DO BLOG:</p>
                <select name="blog" runat="server" id="PCA_ID" onchange="pesquisablog(this.id, this.value)">
                    <option value="" selected>Selecione a categoria</option>
                </select>
            </div>
        </form>
        <form class="form_senha" action="">
            <input type="hidden" id="acao" name="acao" value="FazerLogin" />
            <label>email:</label><input type="text" id="email" name="email" class="input email" /><br />
            <div>
                <a href="javascript:void(0)" class="link esqueci_voltar">voltar</a>
                <!--<a href="javascript:void(0)" class="link">esqueci meu login</a>-->
                <input class="btn" type="submit" value="ENVIAR" />
            </div>
        </form>
    </div>
    <div class="box_logado esconde" id="box_logado" runat="server"></div>
</aside>
