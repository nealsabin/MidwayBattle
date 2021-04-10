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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SpeakToButton_Click(object sender, RoutedEventArgs e)
        {
            if(LocationNpcDataGrid.SelectedItem != null)
            {
                _gameViewModel.OnPlayerTalkTo();
            }
        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            if(LocationNpcDataGrid.SelectedItem != null)
            {
                _gameViewModel.OnPlayerAttack();
            }
        }

        private void DefendButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcDataGrid.SelectedItem != null)
            {
                _gameViewModel.OnPlayerDefend();
            }
        }

        private void RetreatButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcDataGrid.SelectedItem != null)
            {
                _gameViewModel.OnPlayerRetreat();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MissionStatus_Click(object sender, RoutedEventArgs e)
        {
            _gameViewModel.OpenMissionStatusView();
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
