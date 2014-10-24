using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Etnia.classe
{
    public partial class utils : System.Web.UI.Page
    {
        private Int32 iexc, x;
        private int TotalTextos, TotalImagens, TotalLinks;
        private Byte[] Byte10 = { 10 };
        private Byte[] Byte13 = { 13 };
        private Byte[] Travessao = { 196 };
        private OleDbDataReader rsIdioma;
        private bd objBD;
        private String[] Textos, Imagens, Links;
        private string TipoImagem;
        public String[] TextosExibe, ImagensExibe, LinksTextoExibe, LinksImagemExibe;
        private string[] splitPalavras;
        private char[] splitter = { ' ' };
        private WebRequest RSS;
        private WebResponse RSS_Retorno;
        private Stream RSS_Stream;
        private XmlDocument XML;
        private XmlNodeList XML_Itens;
        private XmlNode rsResultado;
        private string TituloRSS = "";
        private string LinkRSS = "", DataRSS = "";
        private int i, TotalItens;


        public bool Feedbacker(Exception erro)
        {

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            //Define o Campo From e ReplyTo do e-mail.
            objEmail.From = new System.Net.Mail.MailAddress("FEEDBACKER" + "<contato@agenciaetnia.com.br>");
            objEmail.To.Add("fernando@agenciaetnia.com.br, zonaro@outlook.com");

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.High;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //Define título do e-mail.
            objEmail.Subject = "FEEDBACKER " + erro.Source;

            //Define o corpo do e-mail.
            objEmail.Body = "Erro de execução no site: " + System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location) +  "<BR><BR> " + erro.Source +"<BR>" + erro.Message;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");


            // Anexa o arquivo a mensagemn
            // objEmail.Attachments.Add(new Attachment("", System.Net.Mime.MediaTypeNames.Application.Octet));

            //Cria objeto com os dados do SMTP
            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

            //Alocamos o endereço do host para enviar os e-mails, localhost(recomendado) 
            objSmtp.Host = "smtp.agenciaetnia.com.br";
            objSmtp.Port = 587;
            objSmtp.EnableSsl = false;
            objSmtp.Credentials = new System.Net.NetworkCredential("contato@agenciaetnia.com.br", "Etnia123");
            try
            {
                objSmtp.Send(objEmail);
                return true;
            }
            catch { 
                return false; 
            }
            finally
            {
                //excluímos o objeto de e-mail da memória
                objEmail.Dispose();
            }

        }

        public string Diretorio(string nomediretorio)
        {
            nomediretorio = "/" + nomediretorio.Replace("/", "").Replace("\\", "");
            if (Directory.Exists(Server.MapPath(nomediretorio)) == false) { Directory.CreateDirectory(Server.MapPath(nomediretorio)); }
            return Server.MapPath(nomediretorio);
        }

        public string SimpleSplitter(string value, int Info_number)  //Qubra Requests de valores multiplos (ID, NOME, EMAIL) - separados por "|"
        {
            string[] newvalue = value.Split(Convert.ToChar("|"));
            return newvalue[Info_number];
        }

        public string CortarString(bool ellipsis, int length, string text)
        {
            // Valida caracteres
            if (text.Length < length || length == 0) return text;

            // Verifica espaços
            String trimmed = text.Substring(0, ellipsis ? length - 1 : length);

            Int32 i = trimmed.LastIndexOf(' ');
            if (i != -1)
                trimmed = trimmed.Substring(0, i);

            // Retorna texto
            return ellipsis ? string.Concat(trimmed, "...") : trimmed;
        }

        public bool isNumeric(string Valor)
        {
            try
            {
                Convert.ToInt32(Valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string VerificaString(string Valor)
        {
            if (Valor.Length == 0)
            {
                return "&nbsp;";
            }
            else
            {
                return Valor;
            }
        }

        public string SemanaExtenso(int Semana)
        {
            switch (Semana)
            {
                case 1:
                    return "Domingo";
                case 2:
                    return "Segunda-Feira";
                case 3:
                    return "Terça-Feira";
                case 4:
                    return "Quarta-Feira";
                case 5:
                    return "Quinta-Feira";
                case 6:
                    return "Sexta-Feira";
                case 7:
                    return "Sábado";
                default:
                    return "";
            }
        }

        public string MesExtenso(int Mes)
        {
            switch (Mes)
            {
                case 1:
                    return "Janeiro";
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
                case 12:
                    return "Dezembro";
                default:
                    return "";
            }
        }

        public string RetiraCaracteres(string Palavra)
        {
            if (Palavra.Length > 0)
            {
                Palavra = Palavra.Replace("“", "&quot;").Replace("”", "&quot;").Replace("-", "-").Replace(Environment.NewLine, "").Replace("\n", "").Replace("<br />", "");
                Palavra = Palavra.Replace(Encoding.ASCII.GetString(Travessao), "-");
                char[] arr = Palavra.ToCharArray();
                Palavra = "";
                for (x = 0; x < arr.Length; x++)
                {
                    if (Convert.ToInt32(arr[x]) == 8211)
                    {
                        Palavra += "-";
                    }
                    else
                    {
                        Palavra += arr[x];
                    }
                }
            }
            return Regex.Replace(Palavra, @"<(.|\n)*?>", string.Empty);
            //return Palavra;
        }

        public string RetiraCaracteresComHTML(string Palavra)
        {
            if (Palavra.Length > 0)
            {
                Palavra = Palavra.Replace("“", "&quot;").Replace("”", "&quot;").Replace("-", "-").Replace(Environment.NewLine, "").Replace("\n", "");
                Palavra = Palavra.Replace(Encoding.ASCII.GetString(Travessao), "-");
                char[] arr = Palavra.ToCharArray();
                Palavra = "";
                for (x = 0; x < arr.Length; x++)
                {
                    if (Convert.ToInt32(arr[x]) == 8211)
                    {
                        Palavra += "-";
                    }
                    else
                    {
                        Palavra += arr[x];
                    }
                }
            }
            return Palavra;
        }

        public string FormataLink(string URL)
        {
            if (URL.Length > 0)
            {
                if (URL.IndexOf("http://") < 0)
                {
                    URL = "http://" + URL;
                }
            }
            return URL;
        }

        public string TrataUTF8(string Palavra)
        {
            return Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-1").GetBytes(Palavra));
        }

        public string GerarURLAmigavel(string texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString().ToLower().Replace(" ", "-");
        }

        public string RemoverAcentos(string texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString().ToLower();
        }

        public String TrataSQLInjection(String Texto)
        {
            try
            {
                if (Texto.Length > 0)
                {
                    String[] exc = { "select", "drop", ";", "--", "insert", "delete", "xp_", "'", "truncate", "\"" };
                    for (iexc = 0; iexc < exc.Length; iexc++)
                    {
                        Texto = Texto.Replace(exc[iexc], "");
                    }
                }
                else
                {
                    Texto = "";
                }
                return Texto;
            }
            catch
            {
                return "";
            }
        }

        public string removeAspas(string palavra)
        {
            palavra = palavra.Replace("'", "");
            palavra = palavra.Replace("\"", "");
            if (palavra.Length <= 0)
            {
                palavra = "0";
            }
            return palavra;
        }

        public string RetornaEstado(string estado)
        {
            string EstadoRetorno = "";
            if (estado.Equals("AC"))
            {
                EstadoRetorno = "Acre";
            }
            if (estado.Equals("AL"))
            {
                EstadoRetorno = "Alagoas";
            }

            if (estado.Equals("AP"))
            {
                EstadoRetorno = "Amapá";
            }

            if (estado.Equals("AM"))
            {
                EstadoRetorno = "Amazonas";
            }

            if (estado.Equals("BA"))
            {
                EstadoRetorno = "Bahia";
            }

            if (estado.Equals("CE"))
            {
                EstadoRetorno = "Ceará";
            }

            if (estado.Equals("DF"))
            {
                EstadoRetorno = "Distrito Federal";
            }

            if (estado.Equals("ES"))
            {
                EstadoRetorno = "Espírito Santo";
            }

            if (estado.Equals("GO"))
            {
                EstadoRetorno = "Goiás";
            }

            if (estado.Equals("MA"))
            {
                EstadoRetorno = "Maranhão";
            }
            if (estado.Equals("MT"))
            {
                EstadoRetorno = "Mato Grosso";
            }

            if (estado.Equals("MS"))
            {
                EstadoRetorno = "Mato Grosso do Sul";
            }

            if (estado.Equals("MG"))
            {
                EstadoRetorno = "Minas Gerais";
            }

            if (estado.Equals("PA"))
            {
                EstadoRetorno = "Pará";
            }

            if (estado.Equals("PB"))
            {
                EstadoRetorno = "Paraíba";
            }

            if (estado.Equals("PR"))
            {
                EstadoRetorno = "Paraná";
            }
            if (estado.Equals("PE"))
            {
                EstadoRetorno = "Pernambuco";
            }

            if (estado.Equals("PI"))
            {
                EstadoRetorno = "Piauí";
            }

            if (estado.Equals("RR"))
            {
                EstadoRetorno = "Roraima";
            }

            if (estado.Equals("RO"))
            {
                EstadoRetorno = "Rondônia";
            }

            if (estado.Equals("RJ"))
            {
                EstadoRetorno = "Rio de Janeiro";
            }

            if (estado.Equals("RN"))
            {
                EstadoRetorno = "Rio Grande do Norte";
            }

            if (estado.Equals("RS"))
            {
                EstadoRetorno = "Rio Grande do Sul";
            }

            if (estado.Equals("SC"))
            {
                EstadoRetorno = "Santa Catarina";
            }
            if (estado.Equals("SP"))
            {
                EstadoRetorno = "São Paulo";
            }
            if (estado.Equals("SE"))
            {
                EstadoRetorno = "Sergipe";
            }
            if (estado.Equals("TO"))
            {
                EstadoRetorno = "Tocantins";
            }

            return EstadoRetorno;

        }

        public String RemoveHTML(string texto)
        {
            return Regex.Replace(texto, "<[^>]*>", "");
        }

        public string getMD5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }



    }
}