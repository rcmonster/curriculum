using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private List<Vaga> vagas = new List<Vaga>();

        public Form1()
        {
            InitializeComponent();
            CarregarVagas();
        }

        private void btnCarregarPDF_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                openFileDialog.Title = "Select a PDF File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string pdfPath = openFileDialog.FileName;
                        var dados = ExtractDataFromPdf(pdfPath);
                        txtResultado.Text = "Habilidades: " + dados["Habilidades"] + Environment.NewLine +
                                            "Formação: " + dados["Formação"];

                        var habilidades = dados["Habilidades"];
                        var formacao = dados["Formação"];
                        var vagasRecomendadas = RecomendacaoVagas(habilidades, formacao);

                        txtVagasRecomendadas.Text = string.Join(Environment.NewLine + Environment.NewLine, vagasRecomendadas);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while processing the PDF file: " + ex.Message);
                    }
                }
            }
        }

        private Dictionary<string, string> ExtractDataFromPdf(string pdfPath)
        {
            var data = new Dictionary<string, string>();

            using (PdfReader reader = new PdfReader(pdfPath))
            using (PdfDocument pdfDoc = new PdfDocument(reader))
            {
                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    var page = pdfDoc.GetPage(i);
                    var strategy = new SimpleTextExtractionStrategy();
                    var text = PdfTextExtractor.GetTextFromPage(page, strategy);

                    if (text.Contains("Habilidades:"))
                    {
                        var habilidades = text.Substring(text.IndexOf("Habilidades:") + "Habilidades:".Length).Split('\n').FirstOrDefault()?.Trim();
                        data["Habilidades"] = habilidades ?? "Não encontrado";
                    }

                    if (text.Contains("Formação:"))
                    {
                        var formacao = text.Substring(text.IndexOf("Formação:") + "Formação:".Length).Split('\n').FirstOrDefault()?.Trim();
                        data["Formação"] = formacao ?? "Não encontrado";
                    }
                }
            }

            return data;
        }

        private List<string> RecomendacaoVagas(string habilidades, string formacao)
        {
            var recomendacoes = vagas
                .Where(vaga => vaga.Habilidades.Contains(habilidades) && vaga.Formacao.Contains(formacao))
                .Select(vaga => vaga.ToString())
                .ToList();

            return recomendacoes;
        }

        private void CarregarVagas()
        {
            vagas.Add(new Vaga { Titulo = "Desenvolvedor Junior", Habilidades = "C#, JavaScript", Formacao = "Ciência da Computação" });
            vagas.Add(new Vaga { Titulo = "Analista de Sistemas", Habilidades = "PHP, SQL", Formacao = "Engenharia de Software" });
            vagas.Add(new Vaga { Titulo = "Programador Frontend", Habilidades = "React.js, Vue.js", Formacao = "Design de Software" });
        }
    }

    public class Vaga
    {
        public string Titulo { get; set; }
        public string Habilidades { get; set; }
        public string Formacao { get; set; }

        public override string ToString()
        {
            return $"Título: {Titulo}" + Environment.NewLine +
                   $"Habilidades: {Habilidades}" + Environment.NewLine +
                   $"Formação: {Formacao}";
        }
    }
}
