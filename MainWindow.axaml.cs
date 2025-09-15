using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Linq;

namespace CalculadoraAvalonia
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calcular_Click(object? sender, RoutedEventArgs e){
            try{
                var notasStr = NotasInput.Text;
                var cargasStr = CargasInput.Text;

                var notas = (notasStr ?? string.Empty).Split(',').Select(s => double.Parse(s.Trim())).ToArray();
                var cargas = (cargasStr ?? string.Empty).Split(',').Select(s => double.Parse(s.Trim())).ToArray();

                if (notas.Length != cargas.Length){
                    ResultadoText.Text = "Número de notas e cargas devem ser iguais :P";
                    return;
                }

                double somaPonderada = 0; double somaCarga = 0;

                for (int i = 0; i < notas.Length; i++){
                    somaPonderada += notas[i] * cargas[i];
                    somaCarga += cargas[i];
                }

                double cre = somaPonderada / somaCarga;

                ResultadoText.Text = $"Coeficiente de Rendimento: {cre:F2} !!!";
            }
            catch (Exception)
            {
                ResultadoText.Text = "Erro: Insira valores válidos ><";
            }
        }
    }
}
