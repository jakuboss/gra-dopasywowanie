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
                    //poniższe polecenie 'zakrywa' ikony na tablicy
                    iconLabel.ForeColor = iconLabel.BackColor;
                }
            }


        }

        

    public Form1()
        {
            InitializeComponent();
            PrzypisanieIkondoKwadratow();
        }
        //Umożliwia odkrywanie kwadratów na zakrytej tablicy
        private void label_click(object sender, EventArgs e)
        {
            
            //Czasomierz działa tylko w typadku 
            //dwóch niepasujących do siebie ikon
            //wyświetla je przez pewien czas 
            //ignorując każde inne kliknięcie 
            //w czasie działania czasomierza
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            

            if (clickedLabel != null)
            {

                //Jeśli kliknięta etykieta jest czarna, to oznacza,
                //że ów ikona była już odkryta wcześniej
                //zignoruj klikniecie

                if (clickedLabel.ForeColor == Color.Black)
                    return;

                
                //Jeśli first Clicked jest null, to jest to pierwsza ikona z pary,
                //która gracz kliknął, więc ustalamy etykietę firstClicked,
                //która gracz kliknął, zmieniamy kolor na czarny i zwracamy  
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                
                //Po pierwszym kliknięciu czasomierz nie działa
                //i firstClicked nie jest null
                //więc musi być to ta sama ikona, która gracz kliknął
                //Wstawia tam czarny kolor
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                 
                //Jeśl gracz kliknął dwie identyczne ikony, 
                //zachowaj je jako czarne i zrestartuj firstClicked i secondClicked
                //gracz może teraz kliknąć inną ikonę

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                //Jeśli gracz kliknął w ten sposób to oznacza, że
                //kliknął 2 różne ikony , więc czasomierz zaczyna działać

                timer1.Start();

            }
        }

       //dodajemy etykiety odwołania

        Label firstClicked = null;

       
        Label secondClicked = null;

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Zatrzymaj czasomierz
            timer1.Stop();

            // Schowaj ikony 
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Zrestartuj firstClicked i secondClicked 
            // wiec następnym razem kiedy etykieta zostanie 
            // kliknięta, program będzie wiedział, że to pierwsze kliknięcie
            firstClicked = null;
            secondClicked = null;
        }
    }
}
