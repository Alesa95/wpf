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
using System.Windows.Shapes;

namespace Layouts
{
    /// <summary>
    /// Lógica de interacción para Bloc.xaml
    /// </summary>
    public partial class Bloc : Window
    {
        public Bloc()
        {
            InitializeComponent();
        }

        private String filePath;

        private void abrirArchivo(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            openFileDialog.InitialDirectory = @"C:\Escritorio";

            if (openFileDialog.ShowDialog() == true)
            {
                textEditor.Text = File.ReadAllText(openFileDialog.FileName);
                filePath = openFileDialog.FileName;
                String fileName = Path.GetFileName(filePath);
                this.Title = fileName;
            }
            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                textEditor.Text = File.ReadAllText(openFileDialog.FileName);
                //textEditor.Text = filePath;
            } else
            {
                textEditor.Text = "abre algún fichero...";
            }*/
        }

        private void cerrarArchivo(object sender, RoutedEventArgs e)
        {
            textEditor.Text = null;
        }

        private void guardarArchivoComo(object sender, RoutedEventArgs e)
        {
            //saveFileDialog.InitialDirectory = @"C:\Escritorio";
            //saveFileDialog.Filter = "Text file (*.txt)|*.txt";

            createDirectory();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = Path.GetFileName(filePath);
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, textEditor.Text);

        }

        private void guardarArchivo(object sender, RoutedEventArgs e)
        {
            if (filePath == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                    File.WriteAllText(saveFileDialog.FileName, textEditor.Text);
            }
            else
            {
                //File.WriteAllText(filePath, String.Empty);
                File.WriteAllText(filePath, textEditor.Text);
            }

        }

        private void encriptar(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Entramos en el método DESENCRIPTAR");
            if (!string.IsNullOrWhiteSpace(textEditor.Text))
            {
                string text = textEditor.Text;
                text = text.Replace("a", "日");
                text = text.Replace("e", "月");
                text = text.Replace("i", "火");
                text = text.Replace("o", "水");
                text = text.Replace("u", "木");
                textEditor.Text = text;

                //if (filePath != null) File.WriteAllText(filePath, textEditor.Text);
            }
        }

        private void desencriptar(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textEditor.Text))
            {
                string text = textEditor.Text;
                text = text.Replace("日", "a");
                text = text.Replace("月", "e");
                text = text.Replace("火", "i");
                text = text.Replace("水", "o");
                text = text.Replace("木", "u");
                textEditor.Text = text;

                //if (filePath != null) File.WriteAllText(filePath, textEditor.Text);
            }
        }

        private void convertirMayus(object sender, RoutedEventArgs e)
        {
            textEditor.SelectedText = textEditor.SelectedText.ToUpper();
        }

        private void convertirNegrita(object sender, RoutedEventArgs e)
        {
            textEditorPlus.Selection.Text = @"{\rtf1\ansi \b" + textEditorPlus.Selection.Text + " \b0.}";
        }

        private void createDirectory()
        {
            string path = @"C:\Users\aleja\Documents\MisArchivos";

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                else
                {
                    Directory.CreateDirectory(path);
                }
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }
    }
}
