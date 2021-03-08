using System;
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
using System.Windows.Shapes;
using MidwayBattle.Models;

namespace MidwayBattle.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;
        public PlayerSetupView(Player player)
        {
            _player = player;
            InitializeComponent();
            SetUpWindow();
        }

        private void SetUpWindow()
        {
            List<string> countries = Enum.GetNames(typeof(Player.HomeCountry)).ToList();
            List<string> titles = Enum.GetNames(typeof(Player.PositionTitle)).ToList();
            TitleComboBox.ItemsSource = titles;
            CountryComboBox.ItemsSource = countries;

            ErrorMessageTextBlock.Visibility = Visibility.Hidden;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if(IsValidInput(out errorMessage))
            {
                Enum.TryParse(TitleComboBox.SelectionBoxItem.ToString(), out Player.PositionTitle title);
                Enum.TryParse(CountryComboBox.SelectionBoxItem.ToString(), out Player.HomeCountry country);

                //Set player properties
                _player.Title = title;
                _player.Country = country;

                Visibility = Visibility.Hidden;
            }
            else
            {
                //Display error message
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }

        }

        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";
            if(NameTextBox.Text == "")
            {
                errorMessage += "Player Name is required.\n";
            }
            else
            {
                _player.Name = NameTextBox.Text;
            }

            if(!int.TryParse(AgeTextBox.Text, out int age) || age < 1)
            {
                errorMessage += "Player Age is required and must be an integer above 0.\n";
            }
            else
            {
                _player.Age = age;
            }

            return errorMessage == "" ? true : false;
        }
    }
}
