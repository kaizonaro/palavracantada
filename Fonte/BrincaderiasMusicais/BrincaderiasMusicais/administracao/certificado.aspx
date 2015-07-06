<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="certificado.aspx.cs" Inherits="BrincaderiasMusicais.administracao.certificado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #brasao {
            height: 78px;
            width: 77px;
        }

        #assinatura {
            height: 40px;
            width: 40px;
        }
        
        

        @font-face {
            src: url('http://projetopalavracantada.net/css/loveyalikeasister-webfont.ttf');
            font-family: PLVR;
        }
    </style>
</head>
   
<body style="font-family:PLVR;">
    
    <div style="font-family:arial;background-size:cover; background-image: url('http://localhost:5131/administracao/images/certificado.jpg'); height: 1150px; width: 1684px;">

        <div style="position:absolute; top: 412px; left: 201px; font-size: 25px; width: 1338px;">
            <center  margin-left: 0px;font-family:arial;">
            <p style="font-family:arial;height: 33px" >
                A Editora Melhoramentos e a Secretaria da Educação de <span style="color:rgb(54,96,157)"> <% W(secretaria); %></span> certificam que 
                <h1 style="color:rgb(54,96,157);font-family:PLVR"> <% W(aluno); %></h1>
                concluiu o <span style="color:rgb(54,96,157)">Programa Formativo do Projeto Brincadeiras Musicais da Palavra Cantada</span>, realizado no dia  <span style="color:rgb(54,96,157)"> <% W(dia); %></span> <span style="color:rgb(54,96,157)"> <% W(mes); %></span> de <span style="color:rgb(54,96,157)"> <% W(ano); %></span>, totalizando  <span style="color:rgb(54,96,157)"> <% W(horas_distancia); %></span> horas de participação a distância
                <span id="pres" runat="server"> e <span style="color:rgb(54,96,157)"> <% W(horas_presenciais); %> </span> horas de participação presencial</span>.</p> 
                <p style="margin:0px;"><span style="color:rgb(54,96,157)"><% W(secretaria); %></span>,<span style="color:rgb(54,96,157)"> <% W(dia); %></span> de <span style="color:rgb(54,96,157)"> <% W(mes); %></span> de <span style="color:rgb(54,96,157)"> <% W(ano); %></span> </p>
            </center>
        </div>
        <div id="brasaodiv" style="position: absolute; top: 1024px; left: 767px; height: 95px; width: 170px;"><img id="brasao" style="width:100%;height:100%" src="" alt="" runat="server" /></div>

        <div id="assinaturadiv" style="position:absolute; top: 788px; left: 936px; height: 121px; width: 332px;">
            <img id="assinatura" style="width:100%;height:100%" src="" alt="" runat="server" /></div>
    
    <div style="position:absolute; text-align:right; top: 925px; left: 435px; height: 20px; width: 332px;color:#005699;font-size:18px"><b>Manildo Ruiz Cavalcante</b></div>
    <div style="position:absolute; top: 925px; left: 936px; height: 20px; width: 332px;color:#005699;font-size:18px"><b><% W(diretor);%></b></div>
</div>
    <%--folha2--%>
     <div id="folha2" runat="server" style="background-size:cover; background-image: url('http://localhost:5131/administracao/images/certificado.jpg'); height: 1150px; width: 1684px;">

        <div style="font-family:arial;position:absolute; top: 1528px; left: 201px; font-size: 25px; width: 1338px;">
            <center  margin-left: 0px;">
                  <h1 style="color:rgb(54,96,157);font-family:PLVR">Observações</h1>
            <p style="height: 33px" >  <% W(obs); %>              </p> 
               
            </center>
        </div>
        <div id="brasaodiv2" style="position: absolute; top: 2165px; left: 767px; height: 95px; width: 170px;"><img id="brasao2" style="width:100%;height:100%" src="" alt="" runat="server" /></div>

        <div id="assinaturadiv2" style="position:absolute; top: 1937px; left: 936px; height: 121px; width: 332px;">
            <img id="assinatura2" style="width:100%;height:100%" src="" alt="" runat="server" /></div>
    
    <div style="position:absolute; text-align:right; top: 2077px; left: 435px; height: 20px; width: 332px;color:#005699;font-size:18px"><b>Manildo Ruiz Cavalcante</b></div>
    <div style="position:absolute; top: 2076px; left: 936px; height: 20px; width: 332px;color:#005699;font-size:18px"><b><% W(diretor);%></b></div>
</div>

</body>
</html>
