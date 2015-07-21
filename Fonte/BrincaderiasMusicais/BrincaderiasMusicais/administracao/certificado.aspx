<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="certificado.aspx.cs" Inherits="BrincaderiasMusicais.administracao.certificado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CERTIFICADO</title>
 
    <script src="js/jquery-2.1.1.min.js"></script>
    <script src="js/html2canvas.js"></script>  
     <script src="js/jquery.plugin.html2canvas.js"></script>
  

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
            src: url('/css/loveyalikeasister-webfont.ttf');
            font-family: PLVR;
        }
    </style>
</head>
   
<body id="corpo" style="font-family:PLVR,Arial;margin-top:-25px;margin-left:-15px">
    
    <div runat="server" style="font-family:arial;background-size:cover;" >
        <img src="images/certificado.jpg" style=" height: 1150px; width: 1684px; z-index: -1; position:absolute;  top:30px" />
        <div style="position:absolute; top: 412px; left: 160px; font-size: 25px; width: 1338px;">
            <span id="folha1" runat="server">
            <center  margin-left: 0px;font-family:arial;" >
            <p style="font-family:arial;height: 33px" >
                A Editora Melhoramentos e a Secretaria da Educação de <span style="color:rgb(54,96,157)"> <% W(secretaria); %></span> certificam que 
                <h1 style="color:rgb(54,96,157);font-family:PLVR"> <% W(aluno); %></h1>
                concluiu o <span style="color:rgb(54,96,157)">Programa Formativo do Projeto Brincadeiras Musicais da Palavra Cantada</span>, realizado no dia  <span style="color:rgb(54,96,157)"> <% W(dia); %></span> <span style="color:rgb(54,96,157)"> <% W(mes); %></span> de <span style="color:rgb(54,96,157)"> <% W(ano); %></span>, totalizando  <span style="color:rgb(54,96,157)"> <% W(horas_distancia); %></span> horas de participação a distância
                <span id="pres" runat="server"> e <span style="color:rgb(54,96,157)"> <% W(horas_presenciais); %> </span> horas de participação presencial</span>.</p> 
                <p style="margin:0px;"><span style="color:rgb(54,96,157)"><% W(secretaria); %></span>,<span style="color:rgb(54,96,157)"> <% W(dia); %></span> de <span style="color:rgb(54,96,157)"> <% W(mes); %></span> de <span style="color:rgb(54,96,157)"> <% W(ano); %></span> </p>
            </center></span>
              <span id="folha2" runat="server"> <center  margin-left: 0px;" >
                  <h1 style="color:rgb(54,96,157);font-family:PLVR">Observações</h1>
            <p style="height: 33px" >  <% W(obs); %> </p> 
               
            </center></span>
        </div>
        <div id="brasaodiv" style="position: absolute; top: 1024px; left: 750px; height: 95px; width: 170px;"><img id="brasao" style="width:100%;height:100%" src="" alt="" runat="server" /></div>

        <div id="assinaturadiv" style="position:absolute; top: 788px; left: 910px; height: 121px; width: 332px;">
            <img id="assinatura" style="width:100%;height:100%" src="" alt="" runat="server" /></div>
    
    <div style="font-family:PLVR,Arial;position:absolute; text-align:right; top: 925px; left: 410px; height: 20px; width: 332px;color:#005699;font-size:18px"><b>Manildo Ruiz Cavalcante</b></div>
    <div style="font-family:PLVR,Arial;position:absolute; top: 925px; left: 910px; height: 20px; width: 332px;color:#005699;font-size:18px"><b><% W(diretor);%></b></div>
</div>
 
</body>
     <script>

         $('body').html2canvas({
             onrendered: function (canvas) {
                 $('html').html(canvas)
             }
         });

    </script>
</html>
