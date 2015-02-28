<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="BrincaderiasMusicais.inc.login" %>
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

    function pesquisablog() {

        $("#pesquisabt").click()

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
        <form class="form_pesquisa" action="blog.aspx">
            <input type="text" name="POS_TEXTO" class="input" id="POS_TEXTO" /><input type="submit" id="pesquisabt" class="btn" value="OK" />
            <div>
                <p>ARQUIVO DO BLOG:</p>
                <select name="POS_DH_CRIACAO" runat="server" id="POS_DH_CRIACAO" onchange="pesquisablog()">
                    <option value="" selected>Selecione o mês / ano</option>
                </select>
            </div>
            <div>
                <p>CATEGORIAIS DO BLOG:</p>
                <select name="PCA_ID" runat="server" id="PCA_ID" onchange="pesquisablog()">
                    <option value="" selected>Selecione a categoria</option>
                </select>
            </div>
            <input type="hidden" id="nomecampo" /><input type="hidden" id="valorcampo" />
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
<script>
    $("#login_POS_DH_CRIACAO").attr("name", "POS_DH_CRIACAO")
    $("#login_PCA_ID").attr("name", "PCA_ID")
    POS_TEXTO.value = getURLParameter('POS_TEXTO');
    var cria = getURLParameter('POS_DH_CRIACAO');
    var ids = getURLParameter('PCA_ID');

    $("#login_POS_DH_CRIACAO option[value='" + cria + "']").attr("selected", "selected");
    $("#login_PCA_ID option[value='" + ids + "']").attr("selected", "selected");
</script>
