<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gerar-certificado.aspx.cs" Inherits="BrincaderiasMusicais.administracao.gerar_certificado" ValidateRequest="false" Debug="true" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Gerar Certificado</title>
    <brincadeira:script runat="server" ID="script" />
    <script src="js/html2canvas.js"></script>
    <script src="tinymce/tinymce.min.js"></script>
    <script src="js/jquery.plugin.html2canvas.js"></script>
    <script type="text/javascript">

        tinymce.init({
            height: 500,
            resize: false,
            language: "pt_BR",
            selector: "textarea",
            menubar: false
        });

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
            ajax4.open("GET", "quem-somos.aspx?acao=editar&SOB_ID=2&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        var resposta = ajax4.responseText.split("<!doctype html>");
                        var ss = resposta[0].split("|");

                        $('#SOB_ID').attr("value", ss[0]);
                        $('#SOB_TITULO').attr("value", ss[1]);
                        tinyMCE.get("SOB_TEXTO_INICIAL").setContent(ss[2]);
                        tinyMCE.get("SOB_TEXTO_FINAL").setContent(ss[3]);

                        editar_table2(id);
                    }
                }
            }
            ajax4.send(null);
        }

        function filtrarede(RED_ID) {

            window.location = "gerar-certificado.aspx?RED_ID=" + RED_ID
        }

        function SalvaObservacao(texto, id) {
            $.ajax({
                type: 'GET',
                url: "gerar-certificado.aspx",
                async: true,
                data: "acao=SalvaObservacao&USU_ID=" + id + "&USU_CERTIFICADO_OBSERVACOES=" + texto.value,
                success: function (data) {
                    //sucesso, conteudo em data
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    //deu erro
                },
                beforeSend: function () {
                    //comecou
                },
                complete: function () {
                    //completo
                }
            });
        }

        function LiberarCertificado(USU_ID, total, horasdistancia,presencial) {
            var go = true
            if (total < horasdistancia) {
                go = confirm('Este usuário não cumpriu a quantidade minima de horas para receber certificado. Deseja liberar o certificado mesmo assim?')
            }
            console.debug(go)
            if (go) {
                $.ajax({
                    type: 'GET',
                    url: "gerar-certificado.aspx",
                    async: true,
                    data: "acao=SalvarData&USU_ID=" + USU_ID + "&USU_DATA_CERTIFICADO=" + $("#data_certificado").val() + "&USU_HORAS_PRESENCIAIS=" +$("#presencial_"+USU_ID).val()+ "&USU_HORAS_DISTANCIA=" +$("#presencial_"+USU_ID).val(),
                    success: function (data) {
                        //sucesso, conteudo em data
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        //deu erro
                    },
                    beforeSend: function () {
                        //comecou
                    },
                    complete: function () {
                        //completo
                    }
                });
              
            }
        }

    </script>
</head>

<body>
    <!--HEADER-->
    <brincadeira:header runat="server" ID="header" />
    <!--FIM DO HEADER-->

    <!--CONTEUDO GERAL-->
    <section class="all">
        <div class="all_center">
            <section id="conteudo">
                <h2>
                    <img src="images/home.png" alt="inicio"><br>
                    Gerar Certificado</h2>
                <!-- TABELA-->
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget red">
                            <div class="widget-title">
                                <h4>Gerar Certificados</h4>
                                <div class="btns_acoes">
                                    <div class="filtrar acoes_topo_form">
                                        <img src="images/filtro.png" alt="Filtrar">
                                        <select id="RED_ID" class="input" runat="server" onchange="filtrarede(this.value)">
                                            <option value="NULL">Selecione a Rede...</option>
                                        </select>
                                        <input type="text" name="data_certificado" id="data_certificado" style="margin-left: 10px; width: 300px" class="input data" placeholder="Data de Conclusão do Curso" />
                                    </div>

                                    <div class="form_table">

                                        <!-- FORMULÁRIO DE INCLUSÃO -->
                                        <form id="Form1" class="inc_form form" name="incluir" action="quem-somos.aspx" novalidate="novalidate" accept-charset="default" runat="server">
                                            <input type="hidden" id="acao" name="acao" value="gravar" />
                                            <input type="hidden" id="SOB_ID" name="SOB_ID" value="2" />

                                            <table>
                                                <tr>
                                                    <td style="width: 50%">Quantidade de Horas Presenciais</td>
                                                    <td style="width: 50%">Quantidade de horas a Distância</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <input type="text" name="SOB_TITULO" id="presencial" class="input obg" placeholder="Título" style="width: 100%" /></td>
                                                    <td>
                                                        <input type="text" name="SOB_TITULO" id="distancia" class="input obg" placeholder="Título" style="width: 100%" /></td>
                                                </tr>

                                                <tr>
                                                </tr>
                                            </table>





                                            <p class="p_btn">
                                                <input type="reset" value="Limpar" class="btn_form" formmethod="get" />

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
        <iframe id="hiddenframe" src=""></iframe>
        <!--FIM DA TABELA-->
    </section>
    <!--FIM DO CONTEUDO GERAL-->
    <footer class='footer'>
    </footer>
</body>
</html>
