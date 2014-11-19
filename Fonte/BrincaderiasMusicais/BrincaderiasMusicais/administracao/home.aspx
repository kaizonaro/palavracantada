<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="BrincaderiasMusicais.administracao.home" %>

<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Seja Bem vindo</title>

    <brincadeira:script runat="server" id="script" />

</head>

<body>
 	<!--HEADER-->
    <brincadeira:header runat="server" id="header" />
    <!--FIM DO HEADER-->
    
    <!--CONTEUDO GERAL-->
    <section class="all">
    	<div class="all_center">
        	<section id="conteudo">
        		<h2><img src="images/home.png" alt="inicio"><br>Painel</h2>
                
                <div class="left">
                	<p class="titu_box">Estatísticas Gerais</p>
                    <div class="box_dash">
                    	<ul class="dash_ul" id="ulGeral" runat="server">
                        	
                        </ul>
                    </div>
                </div>
                
                <div class="right">
                	<p class="titu_box">Estatísticas do Administrador</p>
                    <div class="box_dash">
                    	<ul class="dash_ul" id="ulAdmin" runat="server">
                        	
                        </ul>
                    </div>
                </div>
            
            </section>
        </div>
    </section>
    <!--FIM DO CONTEUDO GERAL-->
    <footer class='footer'>
    </footer>
</body>
</html>
