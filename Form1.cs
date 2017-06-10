using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gra_dopasywowanie
{
    public partial class Form1 : Form
    {
        
        //Użyjemy tego losowego objektu by wybrać losowe ikony dla kwadracików
        Random random = new Random();

       
        //Poniższe znaki oznaczają dostępne obiekty  naszej gry w czcionce Webdings
        //każdny znak występuje podwójnie 
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k","Q","Q",
            "b", "b", "v", "v", "w", "w", "z", "z","I","I"
        };
        public Form1()
        {
            InitializeComponent();
        }
    }
}
