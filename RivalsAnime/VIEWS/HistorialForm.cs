using MySql.Data.MySqlClient;
using RivalsAnime.Controller;
using RivalsAnime.Database;
using RivalsAnime.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace RivalsAnime.VIEWS
{
    public partial class HistorialForm : BaseForm
    {

        HistorialController controller =
             new HistorialController();

        public HistorialForm()
        {
            InitializeComponent();

            dgvHistorial.BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvHistorial.BorderStyle = BorderStyle.None;

            dgvHistorial.EnableHeadersVisualStyles = false;

            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(45, 45, 45);

            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            dgvHistorial.ColumnHeadersDefaultCellStyle.Font =
                new Font("Consolas", 11, FontStyle.Bold);

            dgvHistorial.DefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(30, 30, 30);

            dgvHistorial.DefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            dgvHistorial.DefaultCellStyle.Font =
                new Font("Consolas", 11, FontStyle.Bold);

            dgvHistorial.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(70, 70, 70);

            dgvHistorial.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.White;

            dgvHistorial.GridColor =
                System.Drawing.Color.FromArgb(60, 60, 60);

            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        
        private void HistorialForm_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }
        private void CargarHistorial()
        {
            try
            {
                var lista = controller.ObtenerHistorial();

                dgvHistorial.AutoGenerateColumns = true;
                dgvHistorial.DataSource = lista;

                // 🔥 OCULTAR DESPUÉS DEL BIND
                if (dgvHistorial.Columns["IdHistorial"] != null)
                    dgvHistorial.Columns["IdHistorial"].Visible = false;

                if (dgvHistorial.Columns["IdPersonaje"] != null)
                    dgvHistorial.Columns["IdPersonaje"].Visible = false;

                // 🔥 TÍTULOS
                if (dgvHistorial.Columns["Personaje"] != null)
                    dgvHistorial.Columns["Personaje"].HeaderText = "Personaje";

                if (dgvHistorial.Columns["Victorias"] != null)
                    dgvHistorial.Columns["Victorias"].HeaderText = "Victorias";

                if (dgvHistorial.Columns["Derrotas"] != null)
                    dgvHistorial.Columns["Derrotas"].HeaderText = "Derrotas";

                if (dgvHistorial.Columns["WinRate"] != null)
                {
                    dgvHistorial.Columns["WinRate"].HeaderText = "Win Rate %";
                    dgvHistorial.Columns["WinRate"].DefaultCellStyle.Format = "0.00'%'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
            UserForm user = new UserForm();
            user.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await ExportarPDFConIA();
        }
        private async Task ExportarPDFConIA()
        {
            try
            {
                List<HistorialDTO> lista =
                    controller.ObtenerHistorial();

                // GENERAR TEXTO PARA IA
                StringBuilder historialTexto = new StringBuilder();

                foreach (var item in lista)
                {
                    historialTexto.AppendLine(
                        $"{item.Personaje}: " +
                        $"{item.Victorias} victorias, " +
                        $"{item.Derrotas} derrotas, " +
                        $"WinRate {item.WinRate}%");
                }

                // LLAMAR IA
                string analisisIA =
                    await ObtenerAnalisisIA(historialTexto.ToString());

                // GUARDAR PDF
                string ruta =
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.Desktop),
                        "HistorialAnime.pdf");

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(30);

                        page.Header()
                            .Text("Historial de Personajes")
                            .FontSize(22)
                            .Bold();

                        page.Content().Column(col =>
                        {
                            col.Item().Text("Resumen IA")
                                .FontSize(18)
                                .Bold();

                            col.Item().Text(analisisIA);

                            col.Item().PaddingTop(20);

                            foreach (var item in lista)
                            {
                                col.Item().Text(
                                    $"{item.Personaje} | " +
                                    $"Victorias: {item.Victorias} | " +
                                    $"Derrotas: {item.Derrotas} | " +
                                    $"WR: {item.WinRate}%");
                            }
                        });

                        page.Footer()
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Generado automáticamente");
                            });
                    });
                })
                .GeneratePdf(ruta);

                MessageBox.Show(
                    "PDF generado correctamente",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task<string> ObtenerAnalisisIA(string historial)
        {
            string apiKey = "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";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(
                    "Authorization",
                    $"Bearer {apiKey}");

                var body = new
                {
                    model = "llama3-13b",
                    messages = new[]
                    {
                new
                {
                    role = "system",
                    content = "Eres un analista de videojuegos anime."
                },
                new
                {
                    role = "user",
                    content =
                    $"Analiza este historial:\n\n{historial}"
                }
            },
                    max_tokens = 200
                };

                string json =
                    JsonSerializer.Serialize(body);

                var content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json");

                HttpResponseMessage response =
                    await client.PostAsync(
                        "https://api.groq.com/openai/v1/chat/completions",
                        content);

                string responseString =
                    await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(responseString);
                    return "Error IA";
                }

                using JsonDocument doc =
                    JsonDocument.Parse(responseString);

                return doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();
            }

        }

    }
}
