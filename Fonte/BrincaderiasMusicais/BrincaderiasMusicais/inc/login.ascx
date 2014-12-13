<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="BrincaderiasMusicais.inc.login" %>
<aside id="sidebar">
    <div class="box_login">
        <p>Faça o login para acessar a área restrita de sua região:</p>
        <form class="form_login" action="ajax/acoes.aspx">
            <input type="hidden" id="acao" name="acao" value="FazerLogin" />
            <label>Login:</label><input type="text" id="email" name="email" class="input email" /><label>Senha:</label><input type="password" id="senha" name="senha" class="input email" /><br />
            <div>
                <a href="javascript:void(0)" class="link">esqueci minha senha</a> <a href="javascript:void(0)" class="link">esqueci meu login</a>
                <input class="btn" type="submit" value="ENTRAR" />
            </div>
        </form>
    </div>
    <div class="banner_sidebar">
        <a href="http://palavracantada.com.br" title="Conmheça o site oficial do palalavra cantada" target="_blank"><img src="images/banner_lateral.png" alt="Conmheça o site oficial do palalavra cantada" /></a>
    </div>
    <div class="box_logado esconde">
        <p>Olá <strong>Fernando Santos</strong>, seja bem vindo a área restrita da rede de ensino <strong>escola de musica de itaquera</strong>.</p>
        <input type="button" class="btn" value="SAIR" />
        <p class="titu_logado">Selecione no menu abaixo qual sessão deseja visitar:</p>
        <ul class="opcao_logado">
            <li class="conheca"><a href="#" title="Meu perfil">Meu perfil</a></li>
            <li class="conheca"><a href="#" title="Meu perfil">agenda</a></li>
            <li class="conheca"><a href="#" title="Meu perfil">faq</a></li>
            <li class="conheca pequeno"><a href="#" title="Meu perfil">galeria colaborativa</a></li>
            <li class="conheca medio"><a href="#" title="Meu perfil">blog regional</a></li>
            <li class="conheca"><a href="#" title="Meu perfil">fórum</a></li>
            <li class="conheca grande"><a href="#" title="Meu perfil">criações documentadas</a></li>
        </ul>
        <div class="notificacoes_logado">
            <p>Notificações recentes:</p>
            <img src="images/arrow_left.png" class="left_logado" />
            <img src="images/arrow_right.png" class="right_logado" />
            <ul class="notificacao">
                <li>Parabéns! Você ganhou uma recompensa por publicar   três vídeos na galeria colaborativa de sua rede de ensino.</li>
                <li>te tes te te te dih fdhfusi udhfsiudh fish .</li>
                <li>Parabéns! Você ganhou uma recompensa por publicar   três vídeos na galeria colaborativa de sua rede de ensino.</li>
                 <li>te tes te te te dih fdhfusi udhfsiudh fish .</li>
                <li>Parabéns! Você ganhou uma recompensa por publicar   três vídeos na galeria colaborativa de sua rede de ensino.</li>
            </ul>
        </div>
    </div>
</aside>
