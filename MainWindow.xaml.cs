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
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections;

namespace Database_Dane
{
    public partial class MainWindow : Window
    {
        List<Municipality> municipalityList = new List<Municipality>();
        Hashtable departamentsCount = new Hashtable();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Importar_Click(object sender, RoutedEventArgs e)
        {

            list.Items.Clear();
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == true)
            {
                string[] line = File.ReadAllLines(openFile.FileName);

                for (int i = 0; i <= line.Length - 6; i++)
                {
                    var attributes = line[i].Split(',');
                    municipalityList.Add(new Municipality(attributes[0], attributes[1], attributes[2], attributes[3], attributes[4]));
                }

                municipalityList.RemoveAt(0);
                list.ItemsSource = municipalityList;
                MessageBox.Show("La base de datos ha sido importada");

                Func<ChartPoint, string> PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

                DataContext = this;
                Municipality_Count();
                Municipios_Loaded();
            }
        }

        private void Municipality_Count()
        {
            foreach (Municipality municipality in municipalityList)
            {
                if (!departamentsCount.ContainsKey(municipality.Departament_Name))
                {
                    departamentsCount.Add(municipality.Departament_Name, 1);
                }
                else if(municipality.Municipality_Type.Equals("Municipio"))
                {
                    string depart = municipality.Departament_Name;
                    int count = Int32.Parse(departamentsCount[municipality.Departament_Name] + "");
                    departamentsCount.Remove(depart);
                    departamentsCount.Add(depart, ++count);
                }
            }
        }

        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            Boolean stop = true;
            newPanel.Items.Clear();

            for (int i = 0; i < municipalityList.Count && stop; i++)
            {
                if (municipalityList[i].Municipality_Code.Equals(txtCode.Text))
                {
                    newPanel.Items.Add(municipalityList[i]);
                    stop = false;
                }
            }
            if (stop)
            {
                MessageBox.Show("El código del Municipio no se encuentra en la base de datos");
                txtCode.Clear();
            }
        }

        private void Municipios_Loaded()
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0}", chartPoint.Y);

            SeriesCollection piechartData = new SeriesCollection { };

            ICollection keys = departamentsCount.Keys;

            int cont = 0;
            int others = 0;

            foreach (Object depart in keys)
            {
                if (cont < 11)
                {
                    piechartData.Add(
                        new PieSeries
                        {
                            Title = depart + "",
                            Values = new ChartValues<double> { Int32.Parse(departamentsCount[depart] + "") },
                            DataLabels = true,
                            LabelPoint = labelPoint,
                        }
                    );
                    cont++;
                }
                else
                {
                    others += Int32.Parse(departamentsCount[depart] + "");
                }
            }

            piechartData.Add(
                new PieSeries
                {
                    Title = "Otros",
                    Values = new ChartValues<double> { others },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.DeepPink
                }
            );

            Municipios.Series = piechartData;
            Municipios.LegendLocation = LegendLocation.Right;
        }
    }
}