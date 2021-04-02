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

namespace MidwayBattle.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        GameViewModel _gameViewModel;
        public GameView(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;

            InitializeComponent();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void NorthTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameViewModel.MoveNorth();
        }

        private void EastTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameViewModel.MoveEast();
        }

        private void SouthTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameViewModel.MoveSouth();
        }

        private void WestTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameViewModel.MoveWest();
        }

        private void PickUpButton_Click(object sender, RoutedEventArgs e)
        {
            if(LocationsItemsDataGrid.SelectedItem != null)
            {
                _gameViewModel.AddItemToInventory();
            }
        }

        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerDataTabControl.SelectedItem != null)
            {
                _gameViewModel.OnUseGameItem();
            }
        }

        private void PutDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerDataTabControl.SelectedItem != null)
            {
                _gameViewModel.RemoveItemFromInventory();
            }
        }
    }
}
