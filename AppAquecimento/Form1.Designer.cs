namespace AppAquecimento
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox textboxReceitas;
        private TextBox textboxTurno;
        private TextBox textboxData;
        private TextBox textboxDuracao;
        private TextBox textboxRotacao;
        private TextBox textboxVazaoN2;
        private TextBox textboxVazaoH2;

        private ComboBox comboModoOperacao;
        private Button buttonCalcular;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textboxReceitas = new TextBox();
            this.textboxTurno = new TextBox();
            this.textboxData = new TextBox();
            this.textboxDuracao = new TextBox();
            this.textboxRotacao = new TextBox();
            this.textboxVazaoN2 = new TextBox();
            this.textboxVazaoH2 = new TextBox();
            this.comboModoOperacao = new ComboBox();
            this.buttonCalcular = new Button();

            this.Text = "Aquecimento";
            this.Size = new Size(450, 650);

            var labelReceitas = new Label() { Text = "Receitas (ex: 13, 3, 4):", Location = new Point(10, 20), Width = 200 };
            textboxReceitas.Location = new Point(10, 45);
            textboxReceitas.Width = 300;

            var labelTurno = new Label() { Text = "Turno (ex: MANHÃ):", Location = new Point(10, 80), Width = 200 };
            textboxTurno.Location = new Point(10, 105);
            textboxTurno.Width = 300;

            var labelData = new Label() { Text = "Data (dd/mm/aaaa):", Location = new Point(10, 140), Width = 200 };
            textboxData.Location = new Point(10, 165);
            textboxData.Width = 300;

            var labelDuracao = new Label() { Text = "Duração (HH:mm):", Location = new Point(10, 200), Width = 200 };
            textboxDuracao.Location = new Point(10, 225);
            textboxDuracao.Width = 300;

            // Modo de Operação
            var labelModoOperacao = new Label() { Text = "Modo de Operação:", Location = new Point(10, 270), Width = 200 };
            comboModoOperacao.Location = new Point(10, 295);
            comboModoOperacao.Width = 300;
            comboModoOperacao.Items.AddRange(new string[] { "Manual", "Automático" });
            comboModoOperacao.SelectedIndex = 0;

            // Rotação
            var labelRotacao = new Label() { Text = "Rotação (RPM):", Location = new Point(10, 330), Width = 200 };
            textboxRotacao.Location = new Point(10, 355);
            textboxRotacao.Width = 300;

            // Vazão de N2
            var labelVazaoN2 = new Label() { Text = "Vazão de N2 (Nm³/h):", Location = new Point(10, 390), Width = 200 };
            textboxVazaoN2.Location = new Point(10, 415);
            textboxVazaoN2.Width = 300;

            // Vazão de H2
            var labelVazaoH2 = new Label() { Text = "Vazão de H2 (Nm³/h):", Location = new Point(10, 450), Width = 200 };
            textboxVazaoH2.Location = new Point(10, 475);
            textboxVazaoH2.Width = 300;

            // Botão Calcular
            buttonCalcular.Text = "Calcular";
            buttonCalcular.Location = new Point(10, 520);

            // Adiciona ao Form
            this.Controls.Add(labelReceitas);
            this.Controls.Add(textboxReceitas);
            this.Controls.Add(labelTurno);
            this.Controls.Add(textboxTurno);
            this.Controls.Add(labelData);
            this.Controls.Add(textboxData);
            this.Controls.Add(labelDuracao);
            this.Controls.Add(textboxDuracao);
            this.Controls.Add(labelModoOperacao);
            this.Controls.Add(comboModoOperacao);
            this.Controls.Add(labelRotacao);
            this.Controls.Add(textboxRotacao);
            this.Controls.Add(labelVazaoN2);
            this.Controls.Add(textboxVazaoN2);
            this.Controls.Add(labelVazaoH2);
            this.Controls.Add(textboxVazaoH2);
            this.Controls.Add(buttonCalcular);
        }
    }
}
