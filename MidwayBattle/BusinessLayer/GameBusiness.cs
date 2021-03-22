using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidwayBattle.PresentationLayer;
using MidwayBattle.Models;
using MidwayBattle.DataLayer;

namespace MidwayBattle.BusinessLayer
{
    public class GameBusiness
    {
        GameViewModel _gameViewModel;
        bool _newPlayer = false;
        Player _player = new Player();
        Enemy _enemy = new Enemy();
        List<string> _messages;
        PlayerSetupView _playerSetupView;

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataset();
            InstantiateAndShowView();
        }

        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();

                _player.ExperiencePoints = 0;
                _player.Health = 100;
                _player.Lives = 3;

                _enemy.Health = 100;
                _enemy.Lives = 3;
            }
            else
            {
                _player = GameData.PlayerData();
                _enemy = GameData.EnemyData();
            }
        }

        private void InitializeDataset()
        {
            _messages = GameData.InitialMessages();
        }

        //Create view model with data set
        private void InstantiateAndShowView()
        {
            _gameViewModel = new GameViewModel(
                _player,
                _enemy, 
                GameData.InitialMessages(), 
                GameData.GameMap(), 
                GameData.InitialGameMapLocation()
                );

            GameView gameView = new GameView(_gameViewModel);

            gameView.DataContext = _gameViewModel;

            gameView.Show();

            //_playerSetupView.Close();
        }
    }
}
