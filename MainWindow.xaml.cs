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


        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Importar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();

            if (openFile.ShowDialog() == true) 
            {
                string[] line = File.ReadAllLines(openFile.FileName);
                List<Municipality> municipality = new List<Municipality>();

                foreach (var linea in line) 
                {
                    var attributes = linea.Split(',');
                    municipality.Add(new Municipality(attributes[0], attributes[1], attributes[2], attributes[3], attributes[4]));
                }

                ListViewItem listView = new ListViewItem();
                list.Items.Add(municipality);
            }
        }
    }
}
