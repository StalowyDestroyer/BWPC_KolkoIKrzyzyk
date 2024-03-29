﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
            CreateBoard();
        }

        private void CreateBoard()
        {
            MainGrid.Children.Clear();
            MainGrid.RowSpacing = 0;
            MainGrid.ColumnSpacing = 0;

            for(int i = 0; i < 3; i++)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
                for(int j = 0; j < 3; j++)
                {
                    MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength (0, GridUnitType.Auto) });
                    Grid grid = new Grid()
                    {
                        RowSpacing = 0,
                        ColumnSpacing = 0,
                        Margin = new Thickness(3),
                    };
                    Grid.SetRow(grid, i);
                    Grid.SetColumn(grid, j);
                    MainGrid.Children.Add(grid);
                    for(int k = 0; k < 3; k++)
                    {
                        grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
                        for(int l = 0; l < 3; l++)
                        {
                            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
                            Button button = new Button()
                            {
                                WidthRequest = 38,
                                HeightRequest = 38,
                                Margin = new Thickness(1),
                                ClassId = "enabled",
                                BorderColor = Color.White,
                                BackgroundColor = Color.Gray,
                            };
                            Grid.SetRow (button, k);
                            Grid.SetColumn (button, l);
                            button.Clicked += Move;
                            grid.Children.Add(button);
                        }
                    }
                }
            }
        }

        private void Move(object sender, EventArgs e)
        {
            Button clickedField = sender as Button;

            if(clickedField.ClassId == "enabled")
            {
                if(turn)
                {
                    clickedField.Text = "x";
                    clickedField.BackgroundColor = Color.DarkSlateBlue;
                }
                else
                {
                    clickedField.Text = "o";
                    clickedField.BackgroundColor = Color.DarkSlateGray;
                }

                DisableAll();

                Grid parent = clickedField.Parent as Grid;
                parent.BackgroundColor = Color.Transparent;

                if (CheckForWin(parent))
                    return;

                int gridToEnable = parent.Children.IndexOf(clickedField);
                EnableGrid(gridToEnable);

                ChangeTurn();
            }
        }

        private void EnableGrid(int gridToEnable)
        {
            ((Grid)MainGrid.Children[gridToEnable]).BackgroundColor = Color.Gold;
            foreach(Button button in ((Grid)MainGrid.Children[gridToEnable]).Children)
            {
                if(string.IsNullOrEmpty(button.Text))
                    button.ClassId = "enabled";
            }
        }

        private void Restart(object sender, EventArgs e)
        {
            turn = true;
            TurnLabel.Text = "Kolejka: x";
            foreach(Grid grid in MainGrid.Children)
            {
                foreach(Button button in grid.Children)
                {
                    button.ClassId = "enabled";
                    button.Text = "";
                    button.BackgroundColor = Color.Gray;
                }
            }
        }

        private bool CheckForWin(Grid grid)
        {
            bool win = false;

            List<Button> buttons = new List<Button>();
            foreach (Button button in grid.Children)
                buttons.Add(button);

            for(int i = 0; i < 3; i++)
            {
                if (buttons[i].Text == buttons[i + 3].Text && buttons[i + 3].Text == buttons[i + 6].Text && !string.IsNullOrEmpty(buttons[i].Text))
                {
                    buttons[i].BackgroundColor = Color.Gold;
                    buttons[i+3].BackgroundColor = Color.Gold;
                    buttons[i+6].BackgroundColor = Color.Gold;

                    DisplayWin();
                    win=true;
                }
                if (buttons[i*3].Text == buttons[i *3+1].Text && buttons[i *3+1].Text == buttons[i *3+2].Text && !string.IsNullOrEmpty(buttons[i*3].Text))
                {
                    buttons[i*3].BackgroundColor = Color.Gold;
                    buttons[i*3+1].BackgroundColor = Color.Gold;
                    buttons[i*3+2].BackgroundColor = Color.Gold;

                    DisplayWin();
                    win = true;

                }
            }
            if (buttons[0].Text == buttons[4].Text && buttons[4].Text == buttons[8].Text && !string.IsNullOrEmpty(buttons[4].Text))
            {
                buttons[0].BackgroundColor = Color.Gold;
                buttons[4].BackgroundColor = Color.Gold;
                buttons[8].BackgroundColor = Color.Gold;

                DisplayWin();
                win = true;

            }
            if (buttons[2].Text == buttons[4].Text && buttons[4].Text == buttons[6].Text && !string.IsNullOrEmpty(buttons[4].Text))
            {
                buttons[2].BackgroundColor = Color.Gold;
                buttons[4].BackgroundColor = Color.Gold;
                buttons[6].BackgroundColor = Color.Gold;

                DisplayWin();
                win = true;

            }
            return win;
        }
        private void DisableAll()
        {
            foreach (Grid grid in MainGrid.Children)
                foreach (Button button in grid.Children)
                    button.ClassId = "disabled";
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
