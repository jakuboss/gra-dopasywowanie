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
        
        //Użyjemy tego losowego objektu by wybrać losowe ikony dla kwadratów
        Random random = new Random();

       
        //Poniższe znaki oznaczają dostępne obiekty  naszej gry w czcionce Webdings
        //każdny znak występuje podwójnie 
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k","Q","Q",
            "b", "b", "v", "v", "w", "w", "z", "z","I","I",
            "P", "P", "Z", "Z", "l", "l", "h", "h","y","y"
        };

        
        
       ///Przypisujemy każdą ikone z listy ikon do losowego kwadratu
        private void PrzypisanieIkondoKwadratow()
        {
            
            //TableLayouPanel ma 30 etykiet
            //oraz lista ikon ma 30 ikon
            //więc ikona jest przypisana losowo z listy
            //i dodana do każdej etykiety
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    // iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            PrzypisanieIkondoKwadratow();
        }
    }
}
