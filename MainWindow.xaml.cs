using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace kalkulator
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

        private void nowyClick(object sender, RoutedEventArgs e)
        {
            wynik.Text = null;
            a.Text = null;
            b.Text = null;

        }

        private void zapiszClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog oknoZapisu = new SaveFileDialog();
            oknoZapisu.Filter = "PlainText | *.txt";
            oknoZapisu.Title = "Zapisz jako";
            File.Exists(oknoZapisu.FileName);
            string path = oknoZapisu.FileName;
           

            if (File.Exists(oknoZapisu.FileName))
            {
                
                


                int.TryParse(a.Text, out int x); int.TryParse(b.Text, out int z);
                int NWW = (x * z) / nwdz(x, z);

                string doZapisu = "wyniki otrzymane z liczby " + a.Text + " i " + b.Text + " NWD= " + nwdz(x, z).ToString() + " NWW= " + NWW.ToString();
                File.AppendAllTextAsync(oknoZapisu.FileName, doZapisu);
            }


            else
            {

                if (oknoZapisu.ShowDialog() == true)
                {
                    int.TryParse(a.Text, out int x); int.TryParse(b.Text, out int z);
                    int NWW = (x * z) / nwdz(x, z);

                    string doZapisu = "wyniki otrzymane z liczby " + a.Text + " i " + b.Text + " NWD= " + nwdz(x, z).ToString() + " NWW= " + NWW.ToString();


                    File.WriteAllText(oknoZapisu.FileName, doZapisu);

                }
            }
        }

        private void ObliczClick(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(a.Text, out int x) && int.TryParse(b.Text, out int z) && x >= 0 && z >= 0)
            {
                int dzielnik = nwdz(x, z);
                int NWW = (x * z) / nwdz(x, z);
                wynik.Text = dzielnik.ToString() + " " + NWW.ToString();

            }


        }

        private void ZielonyNiebieskiClick(object sender, RoutedEventArgs e)
        {
            if (kolor.IsChecked)
            {
                Background = Brushes.Green;
            }
            else
            {
                Background = Brushes.Blue;
            }

        }

        private void MalyDuzyClick(object sender, RoutedEventArgs e)
        {
            if (font.IsChecked)
            {
                FontSize = 24;
            }
            else
            {
                FontSize = 12;
            }
            

        }

        private void ProgramClick(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Program stworzony przez 0000000    wersja programy 1.0", "O programie", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void InstrukcjaClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NWD-Najwiekszy wspolny dzielnik   NWW-Najmniejsza wspolna wielokrotnosc","NWD i NWW",MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void NWDclick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(a.Text, out int x) && int.TryParse(b.Text, out int z) && x >= 0 && z >= 0)
            {
                int dzielnik = nwdz(x, z);
                wynik.Text = dzielnik.ToString();

            }
        }

        private void NWWclick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(a.Text, out int x) && int.TryParse(b.Text, out int z) && x >= 0 && z >= 0)
            {
                if (x == 0 && z == 0)
                {

                }
                else
                {
                    int NWW = (x * z) / nwdz(x, z);
                    wynik.Text = NWW.ToString();
                }
                }
        }
        private int nwdz(int x, int y)
        {
            while (y != 0)
            {
                int reszta = x % y;
                x = y;
                y = reszta;
            }

            return x;
        }

      
    }

}
