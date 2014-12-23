<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="BrincaderiasMusicais.inc.login" %>
<aside id="sidebar">
    <div class="box_login" id="box_login" runat="server">
        <p>Faça o login para acessar a área restrita de sua região:</p>
        <form class="form_login" action="ajax/acoes.aspx">
            <input type="hidden" id="acao" name="acao" value="FazerLogin" />
            <label>E-mail:</label><input type="text" id="email" name="email" class="input email" /><label>Senha:</label><input type="password" id="senha" name="senha" class="input" /><br />
            <div>
                <a href="javascript:void(0)" class="link esqueci_senha">esqueci minha senha</a> <!--<a href="javascript:void(0)" class="link">esqueci meu login</a>-->
                <input class="btn" type="submit" value="ENTRAR" />
            </div>
        </form>
        <form class="form_senha" action="">
            <input type="hidden" id="acao" name="acao" value="FazerLogin" />
            <label>email:</label><input type="text" id="email" name="email" class="input email" /><br />
            <div>
                <a href="javascript:void(0)" class="link esqueci_voltar">voltar</a> <!--<a href="javascript:void(0)" class="link">esqueci meu login</a>-->
                <input class="btn" type="submit" value="ENVIAR" />
            </div>
        </form>
    </div>
    <div class="banner_sidebar" id="banner_sidebar" runat="server">
        <a href="http://palavracantada.com.br" title="Conmheça o site oficial do palalavra cantada" target="_blank"><img src="/images/banner_lateral.png" alt="Conmheça o site oficial do palalavra cantada" /></a>
    </div>
    <div class="box_logado esconde" id="box_logado" runat="server"></div>
</aside>
