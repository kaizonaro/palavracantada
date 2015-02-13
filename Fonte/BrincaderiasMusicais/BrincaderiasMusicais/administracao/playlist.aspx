<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="playlist.aspx.cs" Inherits="BrincaderiasMusicais.playlist" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Videos</title>
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
            ajax4.open("GET", "playlist.aspx?acao=populaPlaylist&PLI_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        var ss = ajax4.responseText.split("|");

                        $('#PLI_ID').attr("value", ss[0]);
                        
                        $('#PLI_TITULO').attr("value", ss[1]);
                        $('#PLI_URL').attr("value", ss[2]);
                        editar_table2(id);
                    }
                }
            }
            ajax4.send(null);
        }

        function excluirFoto(id) {
            var r = confirm("Deseja mesmo desativar esta Playlist ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "playlist.aspx?acao=excluirPlaylist&PLI_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
            var r = confirm("Deseja deseja mesmo ativar esta Playlist ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "playlist.aspx?acao=restaurarPlaylist&PLI_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
            ajax4.open("GET", "playlist.aspx?acao=FiltrarPesquisa&PLI_TITULO=" + TITULO.value, true);
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
            	<h2><img src="images/home.png" alt="inicio"><br>Videos</h2>
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
                                	<form  class="inc_form form" name="incluir" action="playlist.aspx" novalidate="novalidate" accept-charset="default" runat="server">
                                        <input type="hidden" id="acao" name="acao" value="gravar" />
                                        <input type="hidden" id="PLI_ID" name="PLI_ID" value="0" />
                                         
                                        <p>Titulo:*</p>
                                        <input type="text" name="PLI_TITULO" id="PLI_TITULO" class="input"  placeholder="Digite o Titulo do Video"/>
                                        <p>URL:*</p>
                                        <input type="text" name="PLI_URL" id="PLI_URL" class="input"  placeholder="Digite a URL do Video"/>
                                        
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