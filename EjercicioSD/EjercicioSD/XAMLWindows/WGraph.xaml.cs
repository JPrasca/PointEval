using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EjercicioSD.XAMLWindows
{
    /// <summary>
    /// Lógica de interacción para WGraph.xaml
    /// </summary>
    public partial class WGraph : Window
    {
        public WGraph(double[,] valores)
        {
            InitializeComponent();
            String url = "http://127.0.0.1/PHP_Binding_0_1/samples/queryRequest.php?x1=" 
                       + valores[0, 0].ToString() + "&y1=" 
                       + valores[0, 1].ToString()+ "&x2=" 
                       + valores[1, 0].ToString() + "&y2=" 
                       + valores[1, 1].ToString();
            //MessageBox.Show(url);
            this.visualizer.Navigate(url);
        }
    }
}
