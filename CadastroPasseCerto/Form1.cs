using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;//ESTENSAO 1 (TEXT)
using iTextSharp.text.pdf;//ESTENSAO 2 (PDF)
using AForge.Video.DirectShow;

namespace CadastroPasseCerto
{
    public partial class Form1 : Form
    {

        const String EMPTY = "";
        const String TAB = "    ";
        const String NEW_LINE = "\n";
        const String BAR = "/";
        const String YES = "Sim";
        const String NO = "Não";

        public static byte[] fotoAluno { get; internal set; }

        public Form1()
        {
            InitializeComponent();
            SetInitialStatesToComplements();
        }

        private void SetInitialStatesToComplements()
        {
            nao1.Checked = true;
            nao2.Checked = true;
            nao3.Checked = true;
            nao4.Checked = true;
            nao5.Checked = true;
            nao6.Checked = true;
            nao7.Checked = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sim1_CheckedChanged(object sender, EventArgs e)
        {
            if (sim1.CheckState == CheckState.Checked)
            {
                nao1.Checked = false;
                qual1.Enabled = true;
                qual1.Focus();
            }
            else
            {
                nao1.Checked = true;
            }
        }

        private void nao1_CheckedChanged(object sender, EventArgs e)
        {
            if (nao1.CheckState == CheckState.Checked)
            {
                sim1.Checked = false;
                qual1.Enabled = false;
                qual1.Text = "";
            }
        }

        private void sim2_CheckedChanged(object sender, EventArgs e)
        {
            if (sim2.CheckState == CheckState.Checked)
            {
                nao2.Checked = false;
                qual2.Enabled = true;
                qual2.Focus();
            }
            else
            {
                nao2.Checked = true;
            }
        }

        private void nao2_CheckedChanged(object sender, EventArgs e)
        {
            if (nao2.CheckState == CheckState.Checked)
            {
                sim2.Checked = false;
                qual2.Enabled = false;
                qual2.Text = "";
            }
        }

        private void sim3_CheckedChanged(object sender, EventArgs e)
        {
            if (sim3.CheckState == CheckState.Checked)
            {
                nao3.Checked = false;
                qual3.Enabled = true;
                qual3.Focus();
            }
            else
            {
                nao3.Checked = true;
            }
        }

        private void nao3_CheckedChanged(object sender, EventArgs e)
        {
            if (nao3.CheckState == CheckState.Checked)
            {
                sim3.Checked = false;
                qual3.Enabled = false;
                qual3.Text = "";
            }
        }

        private void sim4_CheckedChanged(object sender, EventArgs e)
        {
            if (sim4.CheckState == CheckState.Checked)
            {
                nao4.Checked = false;
                qual4.Enabled = true;
                qual4.Focus();
            }
            else
            {
                nao4.Checked = true;
            }
        }

        private void nao4_CheckedChanged(object sender, EventArgs e)
        {
            if (nao4.CheckState == CheckState.Checked)
            {
                sim4.Checked = false;
                qual4.Enabled = false;
                qual4.Text = "";
            }
        }

        private void sim5_CheckedChanged(object sender, EventArgs e)
        {
            if (sim5.CheckState == CheckState.Checked)
            {
                nao5.Checked = false;
                qual5.Enabled = true;
                qual5.Focus();
            }
            else
            {
                nao5.Checked = true;
            }
        }

        private void nao5_CheckedChanged(object sender, EventArgs e)
        {
            if (nao5.CheckState == CheckState.Checked)
            {
                sim5.Checked = false;
                qual5.Enabled = false;
                qual5.Text = "";
            }
        }

        private void sim6_CheckedChanged(object sender, EventArgs e)
        {
            if (sim6.CheckState == CheckState.Checked)
            {
                nao6.Checked = false;
                qual6.Enabled = true;
                qual6.Focus();
            }
            else
            {
                nao6.Checked = true;
            }
        }

        private void nao6_CheckedChanged(object sender, EventArgs e)
        {
            if (nao6.CheckState == CheckState.Checked)
            {
                sim6.Checked = false;
                qual6.Enabled = false;
                qual6.Text = "";
            }
        }

        private void sim7_CheckedChanged(object sender, EventArgs e)
        {
            if (sim7.CheckState == CheckState.Checked)
            {
                nao7.Checked = false;
                qual7.Enabled = true;
                qual7.Focus();
            }
            else
            {
                nao7.Checked = true;
            }
        }

        private void nao7_CheckedChanged(object sender, EventArgs e)
        {
            if (nao7.CheckState == CheckState.Checked)
            {
                sim7.Checked = false;
                qual7.Enabled = false;
                qual7.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Document document = new Document(PageSize.A4);
            document.SetMargins(40, 40, 40, 80);//estibulando o espaçamento das margens que queremos
            document.AddCreationDate();//adicionando as configuracoes

            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                + "\\"
                + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "_").Replace(":", ".")
                + "_"
                + nomeAluno.Text.Replace(" ", "_")
                + ".pdf";

            PdfWriter writer = PdfWriter.GetInstance(document, new System.IO.FileStream(caminho, System.IO.FileMode.Create));

            document.Open();

            //criando uma string vazia

           

            //criando a variavel para paragrafo
            Paragraph titulo = new Paragraph("Ficha de inscrição" + NEW_LINE, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14));
            Paragraph cabecalho = new Paragraph("Projeto Social Passe Certo" + NEW_LINE + NEW_LINE, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 16));
            Paragraph aluno = new Paragraph(getDadosAluno(), new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12));
            Paragraph alunoTitulo = new Paragraph("Dados do Aluno", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14));
            Paragraph responsavel = new Paragraph(getDadosResponsavel(), new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12));
            Paragraph responsavelTitulo = new Paragraph("Dados do Responsável", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14));
            Paragraph informacoesComplementares = new Paragraph(getInformacoesComplementares(), new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12));
            Paragraph informacoesComplementaresTitulo = new Paragraph("Informações Complementares", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14));
            Paragraph autorizacaoTitulo = new Paragraph("Autorização" + NEW_LINE + NEW_LINE, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14));
            Paragraph autorizacao = new Paragraph(getAutorizacao(), new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12));
            Paragraph foto = new Paragraph(EMPTY);
            PdfPTable table = new PdfPTable(2);
            PdfPCell cellAluno = new PdfPCell();
            PdfPCell cellfoto = new PdfPCell();


            if (fotoAluno != null)
            {
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(fotoAluno);
                jpg.ScaleToFit(140f, 120f);
                //Give space before image
                jpg.SpacingBefore = 10f;
                //Give some space after the image
                jpg.SpacingAfter = 1f;
                jpg.Alignment = Element.ALIGN_RIGHT;
                cellfoto.AddElement(jpg);
            }
            

            


            //etipulando o alinhamneto
            titulo.Alignment = Element.ALIGN_CENTER;
            cabecalho.Alignment = Element.ALIGN_CENTER;
            aluno.Alignment = Element.ALIGN_JUSTIFIED;
            alunoTitulo.Alignment = Element.ALIGN_JUSTIFIED;
            responsavel.Alignment = Element.ALIGN_JUSTIFIED;
            responsavelTitulo.Alignment = Element.ALIGN_JUSTIFIED;
            informacoesComplementares.Alignment = Element.ALIGN_JUSTIFIED;
            informacoesComplementaresTitulo.Alignment = Element.ALIGN_JUSTIFIED;
            autorizacaoTitulo.Alignment = Element.ALIGN_CENTER;
            autorizacao.Alignment = Element.ALIGN_LEFT;
            //Alinhamento Justificado
            //acidionado paragrafo ao documento
            document.Add(titulo);
            document.Add(cabecalho);
            //document.Add(jpg);
            document.Add(alunoTitulo);
            //document.Add(aluno);

            

            cellAluno.AddElement(aluno);
            
            cellAluno.HorizontalAlignment = Element.ALIGN_LEFT;
            cellAluno.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cellfoto.Border = iTextSharp.text.Rectangle.NO_BORDER;


            table.AddCell(cellAluno);
            table.AddCell(cellfoto);

            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.SetTotalWidth(new float[] { 374, 140 });
            table.LockedWidth = true;

            document.Add(table);

            document.Add(responsavelTitulo);
            document.Add(responsavel);
            document.Add(informacoesComplementaresTitulo);
            document.Add(informacoesComplementares);
            document.Add(autorizacaoTitulo);
            document.Add(autorizacao);
            //fechando documento para que seja salva as alteraçoes.
            document.Close();

            MessageBox.Show("Ficha salva " + (fotoAluno != null ? "com foto do aluno." : "sem foto do aluno.") + NEW_LINE + "Confira em: " + caminho);
            clearForm();
        }



        private void clearForm()
        {
            nomeAluno.Text = EMPTY;
            enderecoAluno.Text = EMPTY;
            bairroAluno.Text = EMPTY;
            cidadeAluno.Text = EMPTY;
            nascimentoAluno.Text = EMPTY;
            cepAluno.Text = EMPTY;
            cpfAluno.Text = EMPTY;
            rgAluno.Text = EMPTY;
            nomeResponsavel.Text = EMPTY;
            cpfResponsavel.Text = EMPTY;
            rgResponsavel.Text = EMPTY;
            telefone1.Text = EMPTY;
            telefone2.Text = EMPTY;
            SetInitialStatesToComplements();
            nomeAluno.Focus();
        }

        private String getDadosAluno()
        {
            StringBuilder dadosAluno = new StringBuilder();

            dadosAluno.Append("Nome: ");
            dadosAluno.Append(nomeAluno.Text);
            dadosAluno.Append(NEW_LINE);
            dadosAluno.Append("Endereço: ");
            dadosAluno.Append(enderecoAluno.Text);
            dadosAluno.Append(NEW_LINE);
            dadosAluno.Append("Bairro: ");
            dadosAluno.Append(bairroAluno.Text);
            dadosAluno.Append(NEW_LINE);
            dadosAluno.Append("Cidade: ");
            dadosAluno.Append(cidadeAluno.Text);
            dadosAluno.Append(NEW_LINE);
            dadosAluno.Append("CEP: ");
            dadosAluno.Append(cepAluno.Text);
            dadosAluno.Append(NEW_LINE);
            dadosAluno.Append("Data de Nascimento: ");
            dadosAluno.Append(nascimentoAluno.Text);
            dadosAluno.Append(NEW_LINE);
            dadosAluno.Append("CPF: "); 
            dadosAluno.Append(cpfAluno.Text);
            dadosAluno.Append(NEW_LINE);
            dadosAluno.Append("RG: "); 
            dadosAluno.Append(rgAluno.Text);
            dadosAluno.Append(NEW_LINE);
            dadosAluno.Append(NEW_LINE);

            return dadosAluno.ToString();
        }

        private String getDadosResponsavel()
        {
            StringBuilder dadosResponsavel = new StringBuilder();

            dadosResponsavel.Append("Nome: ");
            dadosResponsavel.Append(nomeResponsavel.Text);
            dadosResponsavel.Append(NEW_LINE);
            dadosResponsavel.Append("CPF: " + cpfResponsavel.Text + TAB + "RG: " + rgResponsavel.Text);
            dadosResponsavel.Append(NEW_LINE);
            dadosResponsavel.Append("Contato 1: " + telefone1.Text + TAB + "Contato 2: " + telefone2.Text);
            dadosResponsavel.Append(NEW_LINE);
            dadosResponsavel.Append(NEW_LINE);

            return dadosResponsavel.ToString();
        }

        private String getInformacoesComplementares()
        {
            StringBuilder informacoesComplementares = new StringBuilder();

            informacoesComplementares.Append("1 - TEVE ALGUMA DOENÇA NA INFÂNCIA? ");
            informacoesComplementares.Append(sim1.Checked ? YES : NO);
            informacoesComplementares.Append(TAB);
            informacoesComplementares.Append(sim1.Checked ? qual1.Text : EMPTY);
            informacoesComplementares.Append(NEW_LINE);
            informacoesComplementares.Append("2 - TEM ALGUM PROBLEMA DE SAÚDE? ");
            informacoesComplementares.Append(sim2.Checked ? YES : NO);
            informacoesComplementares.Append(TAB);
            informacoesComplementares.Append(sim2.Checked ? qual2.Text : EMPTY);
            informacoesComplementares.Append(NEW_LINE);
            informacoesComplementares.Append("3 - TOMA ALGUM TIPO DE MEDICAMENTO? ");
            informacoesComplementares.Append(sim3.Checked ? YES : NO);
            informacoesComplementares.Append(TAB);
            informacoesComplementares.Append(sim3.Checked ? qual3.Text : EMPTY);
            informacoesComplementares.Append(NEW_LINE);
            informacoesComplementares.Append("4 - É ALÉRGICO A ALGUM MEDICAMENTO? ");
            informacoesComplementares.Append(sim4.Checked ? YES : NO);
            informacoesComplementares.Append(TAB);
            informacoesComplementares.Append(sim4.Checked ? qual4.Text : EMPTY);
            informacoesComplementares.Append(NEW_LINE);
            informacoesComplementares.Append("5 - ESTÁ EM TRATAMENTO MÉDICO? ");
            informacoesComplementares.Append(sim5.Checked ? YES : NO);
            informacoesComplementares.Append(TAB);
            informacoesComplementares.Append(sim5.Checked ? qual5.Text : EMPTY);
            informacoesComplementares.Append(NEW_LINE);
            informacoesComplementares.Append("6 - SOFRE EPILEPSIA? ");
            informacoesComplementares.Append(sim6.Checked ? YES : NO);
            informacoesComplementares.Append(TAB);
            informacoesComplementares.Append(sim6.Checked ? qual6.Text : EMPTY);
            informacoesComplementares.Append(NEW_LINE);
            informacoesComplementares.Append("7 - JÁ FRATUROU ALGUMA PARTE DO CORPO? ");
            informacoesComplementares.Append(sim7.Checked ? YES : NO);
            informacoesComplementares.Append(TAB);
            informacoesComplementares.Append(sim7.Checked ? qual7.Text : EMPTY);
            informacoesComplementares.Append(NEW_LINE);
            informacoesComplementares.Append(NEW_LINE);

            return informacoesComplementares.ToString();
        }

        private String getAutorizacao()
        {
            StringBuilder textoAutorizacao = new StringBuilder();

            textoAutorizacao.Append("Autorizo o aluno ___________________________________________________");
            textoAutorizacao.Append(NEW_LINE);
            textoAutorizacao.Append("a frequentar o projeto social realizado no ginásio de esportes em Várzea Paulista, ");
            textoAutorizacao.Append("na Vila Popular, no período das 08h00min até 14h00min, todos os sábados (exceto feriados). ");
            textoAutorizacao.Append("Utilização de fotos e filmagens realizadas e adquiridas no período do projeto para eventuais exposições.");
            textoAutorizacao.Append(NEW_LINE);
            textoAutorizacao.Append("Assinatura do responsável:___________________________________________");
            textoAutorizacao.Append(NEW_LINE);
            textoAutorizacao.Append(NEW_LINE);
            textoAutorizacao.Append("Várzea Paulista, ___ de _____________________________ de _______");



            return textoAutorizacao.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var videoSources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoSources != null && videoSources.Count > 0)
            {
                new Form2().Show();
            }
            else
            {
                MessageBox.Show("Nenhuma Web Cam foi encontrada.");
            }
            
        }

        private void nomeAluno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void nascimentoAluno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar.ToString() != BAR)
            {
                e.Handled = true;
            }
        }

        private void cepAluno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar.ToString() != "." && e.KeyChar.ToString() != "-")
            {
                e.Handled = true;
            }
        }

        private void cpfAluno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar.ToString() != "." && e.KeyChar.ToString() != "-")
            {
                e.Handled = true;
            }
        }

        private void rgAluno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar.ToString() != "." && e.KeyChar.ToString() != "-")
            {
                e.Handled = true;
            }
        }

        private void cpfResponsavel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar.ToString() != "." && e.KeyChar.ToString() != "-")
            {
                e.Handled = true;
            }
        }

        private void rgResponsavel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar.ToString() != "." && e.KeyChar.ToString() != "-")
            {
                e.Handled = true;
            }
        }

        private void telefone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void telefone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void nomeResponsavel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearForm();
        }

    } 
    }

