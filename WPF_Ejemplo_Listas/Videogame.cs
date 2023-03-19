using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace WPF_Ejemplo_Listas
{
    internal class Videogame : IComparable<Videogame>, INotifyPropertyChanged
    {
        public enum Console_type { PS4, PS5, SWITCH, XBOX };

        public string Name { get; set; }
        public double Price { get; set; }
        public Console_type Console { get; set; }

        public Videogame(string name, double price, Console_type console)
        {
            this.Name = name;
            this.Price = price; 
            this.Console = console;
        }

        public Videogame()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void onPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }

        /*public override string ToString()
        {
            return "Name => " + Name + "\nPrice => " + Price + "\nConsole => " + Console;
        }*/

        public override string ToString()
        {
            return "Name => " + Name + " | Price => " + Price + " | Console => " + Console;
        }

        public int CompareTo([AllowNull] Videogame other)
        {
            if (other == null)
                return 1;
            else
                return this.Name.CompareTo(other.Name);
        }
        /*
        public int SortByNameAscending(string name1, string name2)
        {
            return name1.CompareTo(name2);
        }
        */
        /*public bool Equals([AllowNull] Videogame other)
        {
            if (other == null) return false;
            return (this.Name.Equals(other.Name));
        }*/
        
        public int CompareByPrice (int price1, int price2)
        {
            return price1.CompareTo(price2);
        }
        
    }
}
