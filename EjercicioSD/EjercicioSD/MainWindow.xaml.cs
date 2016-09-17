using System;
using System.Diagnostics;
using System.Windows;
using EjercicioSD.Clases;


namespace EjercicioSD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double[,] matrizDeValores = { { 0, 0 }, { 0, 0 } };
        public MainWindow()
        {
            InitializeComponent();
        }

        #region eventos de textbox
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.textBoxX1.Focus();
            
        }

        private void textBoxX1_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxX1.Text = "";
        }

        private void textBoxX1_LostFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxX1.Text = (this.textBoxX1.Text.Trim() != "") ? this.textBoxX1.Text : "0";
        }

        private void textBoxY1_LostFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxY1.Text = (this.textBoxY1.Text.Trim() != "") ? this.textBoxY1.Text : "0";
        }

        private void textBoxY1_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxY1.Text = "";
        }

        private void textBoxX2_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxX2.Text = "";
        }

        private void textBoxX2_LostFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxX2.Text = (this.textBoxX2.Text.Trim() != "") ? this.textBoxX2.Text : "0";
        }

        private void textBoxY2_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxY2.Text = "";
        }

        private void textBoxY2_LostFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxY2.Text = (this.textBoxY2.Text.Trim() != "") ? this.textBoxY2.Text : "0";
        }

        #endregion

        #region clicks
        private void buttonYa_Click(object sender, RoutedEventArgs e)
        {
            this.textBoxX1.Text = this.textBoxX1.Text.Replace(",", ".");
            this.textBoxY1.Text = this.textBoxY1.Text.Replace(",", ".");
            this.textBoxX2.Text = this.textBoxX2.Text.Replace(",", ".");
            this.textBoxY2.Text = this.textBoxY2.Text.Replace(",", ".");
            try
            {
               
                //llenado de la matríz de puntos
                double[,] matrizDePuntos = {
                                        { Convert.ToDouble(this.textBoxX1.Text), Convert.ToDouble(this.textBoxY1.Text) },
                                        { Convert.ToDouble(this.textBoxX2.Text), Convert.ToDouble(this.textBoxY2.Text) }
                                       };


                matrizDeValores = matrizDePuntos;
                //instancia del sistema
                CSistema sistemaLineal = new CSistema(matrizDePuntos);
                
                //verificación de la existencia de mas puntos críticos
                if (sistemaLineal.SoloHayUnPunto())
                {
                    this.labelRes.Content = "El punto crítico es \n" + 
                                            sistemaLineal.EvaluarTipo() + " " + 
                                            sistemaLineal.EvaluarEstabilidad() + 
                                            "\n\nTeniendo que:" + 
                                            sistemaLineal.MostrarRaicesYDatos();
                }
                else
                {
                    this.labelRes.Content = "Existe mas de un punto crítico";
                }

            }
            catch
            {
                this.labelRes.Content = "Algo no anda bien, verifica los datos";
            }
            

        }


        #endregion

        private void buttonGraph_Click(object sender, RoutedEventArgs e)
        {

            if (this.textBoxX1.Text.Trim() == string.Empty || this.textBoxX2.Text.Trim() == string.Empty || this.textBoxY1.Text.Trim() == string.Empty || this.textBoxY2.Text.Trim() == string.Empty)
            {
                return;
            }

            try
            {
                double[,] matrizDePuntos = {
                                        { Convert.ToDouble(this.textBoxX1.Text), Convert.ToDouble(this.textBoxY1.Text) },
                                        { Convert.ToDouble(this.textBoxX2.Text), Convert.ToDouble(this.textBoxY2.Text) }
                                       };


                matrizDeValores = matrizDePuntos;
                EjercicioSD.XAMLWindows.WGraph grafica = new XAMLWindows.WGraph(matrizDeValores);
                grafica.ShowDialog();
            }
            catch
            {
                this.labelRes.Content = "Algo no anda bien, verifica los datos";
            }
        }

       
    }
}
