﻿using System;
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

        private void CreateBoard()
        {
            MainGrid.Children.Clear();
            MainGrid.RowSpacing = 0;
            MainGrid.ColumnSpacing = 0;
            turn = true;
            TurnLabel.Text = "Kolejka: x";

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
                            };
                            button.Clicked += Move;
                            grid.Children.Add(button);
                        }
                    }
                }
            }
        }



        private void Restart(object sender, EventArgs e)
        {

        }
    }
}
