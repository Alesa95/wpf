using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Ejemplo_Listas
{
    public class Consoles : ObservableCollection<string>
    {
        public Consoles()
        {
            Add("PS4");
            Add("PS5");
            Add("SWITCH");
            Add("XBOX");
        }
    }
}
