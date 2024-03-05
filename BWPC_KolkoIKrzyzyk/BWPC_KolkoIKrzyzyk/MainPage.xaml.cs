using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BWPC_KolkoIKrzyzyk
{
    public partial class MainPage : ContentPage
    {
        private bool turn = true;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Restart(object sender, EventArgs e)
        {

        }
        private void DisplayWin()
        {
            if (turn)
                DisplayAlert("Koniec gry!", "Wygrywa x!", "OK");
            else
                DisplayAlert("Koniec gry!", "Wygrywa o!", "OK");
        }
        private void ChangeTurn()
        {
            turn = !turn;
            if (turn)
                TurnLabel.Text = "Kolejka: x";
            else
                TurnLabel.Text = "Kolejka: o";

        }
    }
}
