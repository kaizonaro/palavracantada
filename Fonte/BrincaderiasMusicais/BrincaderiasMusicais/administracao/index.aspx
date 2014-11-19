<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BrincaderiasMusicais.administracao.index" %>

<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Login</title>

    <brincadeira:script runat="server" id="script" />

</head>

<body>
	<div class="all login">
    	<div id="antes" class="all_center">
        	<section class="adm_index_left">
            	<img src="images/logo.png" alt="Palavra Cantada">
            </section>	
            <section class="adm_index_right">
            	<form id="login_adm" method="post" action="index.aspx">
                    <input type="hidden" id="acao" name="acao" value="fazerLogin" />
                	
                    <p class="titu_form">Administração Brincadeiras Musicas</p>
                	<div class="ln_form"><b>E-mail:</b><input type="text" name="login" id="login" class="input_adm login_adm" placeholder="Login"><span></span></div>
                    <div class="ln_form"><b>Senha:</b><input type="password" name="senha" id="senha" class="input_adm senha_adm" placeholder="Senha"><span></span></div>
                    <div class="ln_form esqueci"><a href="#" title="esquci minha senha">esqueci minha senha</a></div>
                    <div class="ln_form"><input type="submit" name="Logar" value="Logar" class="btn_logar"></div>
                </form>
                <form id="esqueci_senha" method="post" action=" ">
                	<p class="titu_form">Esqueci Minha senha</p>
                	<div class="ln_form"><b>E-mail:</b><input type="text" name="Email" class="input_adm login_adm" placeholder="E-mail"><span></span></div>
                    <!--<div class="ln_form"><b> Rede: </b><select name="rede_esqueci_senha" class="input_adm rede_adm">
                    									<option value="" selected>Selecione uma Instituição</option>
                                                        <option value="exemplo">Exemplo</option>
                                                        <option value="exemplo">Exemplo</option>
                                                        <option value="exemplo">Exemplo</option>
                                                        <option value="exemplo">Exemplo</option>
                    								 </select><span></span></div>-->
                    <div class="ln_form esqueci"><a href="#" title="esquci minha senha">login</a></div>
                    <div class="ln_form"><input type="submit" name="Logar" value="Enviar" class="btn_logar"></div>
                </form>
            </section>	
        </div>
    </div>
</body>
</html>
