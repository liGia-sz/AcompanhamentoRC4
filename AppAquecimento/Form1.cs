using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AppAquecimento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonCalcular_Click(object sender, EventArgs e)
        {
            CalcularResultado(
                textboxReceitas.Text,
                textboxTurno.Text,
                textboxData.Text,
                textboxDuracao.Text
            );
        }

        private void CalcularResultado(string receitas, string turno, string dataStr, string duracaoStr)
        {
            try
            {
                List<int> listaReceitas = receitas.Split(',').Select(x => int.Parse(x.Trim())).ToList();
                turno = turno.ToUpper();
                DateTime data = DateTime.ParseExact(dataStr, "dd/MM/yyyy", null);
                TimeSpan duracaoAquecimento = TimeSpan.Parse(duracaoStr);

                (TimeSpan horaPadrao, string tempoPadrao) = ObterTempoPadrao(listaReceitas);
                int diferencaMinutos = (int)(duracaoAquecimento - horaPadrao).TotalMinutes;

                string resultado = FormatacaoResultado(tempoPadrao, diferencaMinutos);
                MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (TimeSpan, string) ObterTempoPadrao(List<int> listaReceitas)
        {
            if (listaReceitas.All(r => new[] { 13, 3, 4, 16, 22 }.Contains(r)))
                return (new TimeSpan(13, 0, 0), "13:00");
            else if (listaReceitas.All(r => new[] { 12, 21 }.Contains(r)))
                return (new TimeSpan(9, 0, 0), "09:00");
            else
                throw new ArgumentException("Combinação de receitas não reconhecida.");
        }

        private string FormatacaoResultado(string tempoPadrao, int diferencaMinutos)
        {
            if (diferencaMinutos == 0)
                return $"Tempo padrão: {tempoPadrao}\nAquecimento IGUAL ao tempo padrão.";
            else if (diferencaMinutos > 0)
                return $"Tempo padrão: {tempoPadrao}\nAquecimento ULTRAPASSOU em: {diferencaMinutos / 60}h {diferencaMinutos % 60}min.";
            else
                return $"Tempo padrão: {tempoPadrao}\nAquecimento FALTOU em: {Math.Abs(diferencaMinutos) / 60}h {Math.Abs(diferencaMinutos) % 60}min.";
        }
    }
}