﻿using System;
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

namespace Layouts
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*string texto = "Hola " + txtNombre.Text;
            lblBienvenida.Content = texto;*/

            MessageBoxResult result = MessageBox.Show("Hola mundo!!", 
                            "Mi primera app", 
                            MessageBoxButton.YesNoCancel,
                            MessageBoxImage.Information,
                            MessageBoxResult.No);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    //this.Hide();
                    Bloc win = new Bloc();
                    win.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    lblBienvenida.Content = "Has pulsado NO";
                    break;
                case MessageBoxResult.Cancel:
                    lblBienvenida.Content = "Has pulsado CANCEL";
                    break;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
