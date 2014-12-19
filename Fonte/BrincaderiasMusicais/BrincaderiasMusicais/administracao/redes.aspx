<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="redes.aspx.cs" Inherits="BrincaderiasMusicais.administracao.redes" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
    <title>:: Administração - Redes</title>
    <brincadeira:script runat="server" id="script" />

    <script type="text/javascript">
        function popularFormulario(id) {
            //    alert(id);
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
            	<h2><img src="images/home.png" alt="inicio"><br>Redes</h2>
                 <!-- TABELA-->
                <div class="row-fluid">
                    <div class="span12">
                    <div class="widget red">
                        <div class="widget-title">
                            <h4>Redes</h4>
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
                                	<form class="inc_form form" name="incluir" action="redes.aspx">
                                        <input type="hidden" value="gravarRede" id="acao" name="acao" />
                                        <input type="hidden" value="0" id="RED_ID" name="RED_ID" />
                                    	<p>Nome da Rede</p>
                                		<input type="text" name="RED_TITULO" class="input error"  id="RED_TITULO"/>
                                                                                <p>Cidade</p>
                                		<input type="text" name="RED_CIDADE" class="input error"  id="RED_CIDADE"/>
                                        <p>UF</p>
                                		<input type="text" name="RED_UF" class="input error"  id="RED_UF"/>
                                        <p>Quantidade de Usuarios</p>
                                        <input type="number" class="input sonumero obg"  placeholder="exemplo" id="USU_MASSA" name="USU_MASSA"/>
                                        <p>
                                    		<input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                            <input type="submit" value="Filtrar" class="btn_form" formmethod="get" />
                               			</p>
                                    </form>
                                </div>
                            </div>
                        </div>
                        
                        <div class="widget-body">

                            <!-- LISTAGEM INICIAL -->
                                <div class="tabela_ok" id="divLista" runat="server"></div>
                            <!-- FIM LISTAGEM INICIAL -->
                                <!--<table class="table" id="tabela" cellspacing="0">
                                    <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Nome</th>
                                        <th>Email</th>
                                        <th>Telefone</th>
                                        <th>ultima compra</th>
                                        <th width="100px">Ações</th>
                                    </tr>
                                    </thead>
                                    <tbody>
                                    <tr id="tr_1" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">User 1</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(1)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_2"  class="">
                                        <td>2</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(2)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_3" class="">
                                        <td>2</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(3)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_4" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(4)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_5" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(5)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr  id="tr_6" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(6)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_7" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(7)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_8" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(8)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_9" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(9)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_10" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(10)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_11" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(11)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_12" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(12)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_13" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(13)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_14" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(14)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_15" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(15)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_16" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(16)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_17" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(17)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    <tr id="tr_18" class="">
                                        <td>1</td>
                                        <td><a href="javascript:void(0)" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><ul class="icons_table"><li><a href="javascript:void(0)" class="img_edit"><img src="images/editar.png"  onClick="editar_table(18)"></a></li><li><a href="javascript:void(0)" class="img_del"><img src="images/lixo.png"></a></li></ul></td>
                                    </tr>
                                    
                                    </tbody>
                                </table> -->
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
