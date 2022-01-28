using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace Database_Dane
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Municipality> municipalityList = new List<Municipality>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Importar_Click(object sender, RoutedEventArgs e)
        {

            list.Items.Clear();
            OpenFileDialog openFile = new OpenFileDialog();

           if (openFile.ShowDialog() == true) 
            {
                string[] line = File.ReadAllLines(openFile.FileName);

                for (int i = 0; i <= line.Length-6; i++)
                {
                    var attributes = line[i].Split(',');
                    municipalityList.Add(new Municipality(attributes[0], attributes[1], attributes[2], attributes[3], attributes[4]));
                }

                municipalityList.RemoveAt(0);
                list.ItemsSource = municipalityList;
            }
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
