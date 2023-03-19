using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
//using PdfDocument = PdfDocument;
//using PdfPage = PdfPage;

namespace WPF_Ejemplo_Listas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public ObservableCollection<string> GamesList { get; set; }

        public MainWindow()
        {
            /*this.DataContext = this;
            GamesList = new ObservableCollection<string>();
            GamesList.Add("Horizon Forbidden West");
            GamesList.Add("Elden Ring");*/
            InitializeComponent();
        }

        //private ObservableCollection<string> lstGames = new ObservableCollection<string>();

        private void AddGame(object sender, RoutedEventArgs e)
        {
            Videogame.Console_type console = 
                (Videogame.Console_type) Enum.Parse(typeof(Videogame.Console_type), cmbConsole.Text);
            Videogame v1 = new Videogame(txtGame.Text, 
                                        Convert.ToDouble(txtPrice.Text), 
                                        console);

            if (!string.IsNullOrWhiteSpace(txtGame.Text) && !lstGames.Items.Contains(txtGame.Text))
            {
                lstGames.Items.Add(v1);
                txtGame.Clear();
            } 
        }

        private void DeleteGame(object sender, RoutedEventArgs e)
        {
            lstGames.Items.RemoveAt(lstGames.Items.IndexOf(lstGames.SelectedItem));
        }

        private void ShowGame(object sender, SelectionChangedEventArgs e)
        {
            lblShowGame.Content = "You selected " + lstGames.SelectedValue;
            txtModifyGame.Text = ((Videogame)lstGames.SelectedItem).Name;
        }

        private void ModifyGame(object sender, RoutedEventArgs e)
        {
            if (lstGames.SelectedItem != null)
            {
                ((Videogame)lstGames.Items[lstGames.SelectedIndex]).Name = txtModifyGame.Text;
                lstGames.Items.Refresh();
            }
        }

        private void generar_pdf(object sender, RoutedEventArgs e)
        {
            string[] lines =
            {
                "First line", "Second line", "Third line"
            };

            /*string[] content = new string[lstGames.Items.Count];
            List<string> list = new List<string>(); 
            for (int i = 0; i < lstGames.Items.Count; i++)
            {
                content[i] = lstGames.Items[i].ToString()!;
                list.Add(lstGames.Items[i].ToString());
            }*/

            string date = DateTime.Now.ToString();
            date = date.Replace("/", "");
            date = date.Replace(" ", "");
            date = date.Replace(":", "");
            string report = date + ".csv";
            string file_name = @"C:\Users\aleja\Documents\Report" + report;

            txtGame.Text = file_name;

            using (StreamWriter writetext = new StreamWriter(file_name))
            {
                writetext.WriteLine("== Listado de videojuegos ===");
                writetext.WriteLine();
                writetext.WriteLine("Fecha: " + DateTime.Now);
                writetext.WriteLine();
                for (int i = 0; i < lstGames.Items.Count; i++)
                {
                    writetext.WriteLine(i + " - " + lstGames.Items[i].ToString());
                }
            }
            //File.WriteAllText(@"C:\Users\aleja\Documents", lines);
        }
    }
}
