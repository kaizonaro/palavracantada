<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="albumfotos.aspx.cs" Inherits="BrincaderiasMusicais.albumfotos" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Galeria de Fotos</title>
    <brincadeira:script runat="server" id="script" />

    <script type="text/javascript">

        //AJAX
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

        function popularFormulario(id) {
            ajax4 = ajaxInit();
            ajax4.open("GET", "albumfotos.aspx?acao=populaFotos&AFO_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        var ss = ajax4.responseText.split("|");

                        $('#AFO_ID').attr("value", ss[0]);
                        
                        $('#AFO_TITULO').attr("value", ss[1]);
                        $('#AFO_KEY').attr("value", ss[2]);
                        editar_table2(id);
                    }
                }
            }
            ajax4.send(null);
        }

        function excluirFoto(id) {
            var r = confirm("Deseja mesmo desativar esta Galeria de Foto ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "albumfotos.aspx?acao=excluirFoto&AFO_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
                ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
                ajax2.onreadystatechange = function () {
                    if (ajax2.readyState == 4) {
                        if (ajax2.status == 200) {
                            $('#tr_' + id).hide();
                        }
                    }
                }
                ajax2.send(null);
            } else {
                return false;
            }
        }

        function restaurarFoto(id) {
            var r = confirm("Deseja deseja mesmo ativar esta Galeria de Foto ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "albumfotos.aspx?acao=restaurarFoto&AFO_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
                ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
                ajax2.onreadystatechange = function () {
                    if (ajax2.readyState == 4) {
                        if (ajax2.status == 200) {
                            $('#tr_' + id).hide();
                        }
                    }
                }
                ajax2.send(null);
            } else {
                return false;
            }
        }

        function FiltrarPesquisa() {
            ajax4 = ajaxInit();
            ajax4.open("GET", "albumfotos.aspx?acao=FiltrarPesquisa&AFO_TITULO=" + TITULO.value, true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        $("#tbCentral").html(ajax4.responseText);
                    }
                }

            }

            ajax4.send(null);
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
            	<h2><img src="images/home.png" alt="inicio"><br>Fotos</h2>
                 <!-- TABELA-->
                <div class="row-fluid">
                    <div class="span12">
                    <div class="widget red">
                        <div class="widget-title">
                            <h4>Fotos</h4>
                            <div class="btns_acoes">
                            	<div class="filtrar acoes_topo_form">
                                	<img src="images/filtro.png" alt="Filtrar"><p>Filtrar</p>
                                </div>
                                <div class="incluir acoes_topo_form">
                                	<img src="images/mais.png" alt="Incluir"><p>Incluir</p>
                                </div>                                
                                <div class="excluidos acoes_topo_form">
                                	<img src="images/lixo.png" alt="Filtrar"><p>Ítens excluidos</p>
                                </div>
                                <div class="voltar_topo_form acoes_topo_form">
                                	<img src="images/restore.png" alt="Filtrar"><p>Voltar</p>
                                </div>
                                <div class="form_table">
                                	<form  class="inc_form form" name="incluir" action="albumfotos.aspx" novalidate="novalidate" accept-charset="default" runat="server">
                                        <input type="hidden" id="acao" name="acao" value="gravar" />
                                        <input type="hidden" id="AFO_ID" name="AFO_ID" value="0" />
                                         
                                        <p>Titulo:*</p>
                                        <input type="text" name="AFO_TITULO" id="AFO_TITULO" class="input"  placeholder="Lengenda da foto"/>
                                        <p>Key:*</p>
                                        <input type="text" name="AFO_KEY" id="AFO_KEY" class="input"  placeholder="Lengenda da foto"/>
                                        
                                        <p class="p_btn">
                                    		<input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                            <asp:Button ID="Incluir" Cssclass="btn_form"  runat="server" Text="Incluir" OnClick="gravar" />
                               			</p>
                                    </form>

                                    <form class="fil_form form" novalidate accept-charset="default">
                                         
                                    	<p>Titulo:</p>
                                		<input type="text" name="TITULO" id="TITULO" class="input"  onchange="FiltrarPesquisa(FL_REDE_ID.value, FL_NOME.value, FL_EMAIL.value)" />
                                         
                                        <p class="p_btn">
                                    		<input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                            <input type="button" onclick="FiltrarPesquisa()" value="Filtrar" class="btn_form" formmethod="get" />
                               			</p>
                                    </form>
                                </div>
                            </div>
                        </div>
                        
                        <div class="widget-body">

                            <!-- LISTAGEM INICIAL -->
                                <div class="tabela_ok" id="divLista" runat="server"></div>
                            <!-- FIM LISTAGEM INICIAL -->
                            
                            <!-- LISTAGEM EXCLUÍDOS -->
                            <div class="tabela_excluidos" id="divExcluidos" runat="server"></div>   
                            <!-- FIM LISTAGEM EXCLUÍDOS -->
                        </div>
                    </div>
                    </div>
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