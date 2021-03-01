using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidwayBattle.Models;

namespace MidwayBattle.PresentationLayer
{
    public class GameViewModel : ObservableObject
    {
        private Player _player;
        private Enemy _enemy;
        private List<string> _messages;
        private DateTime _gameStartTime;
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }
        public Enemy Enemy
        {
            get { return _enemy; }
            set { _enemy = value; }
        }
        public string MessageDisplay
        {
            get { return FormatMessagesForViewer(); }
        }

        public GameViewModel()
        {

        }
        public GameViewModel(Player player, Enemy enemy, List<string> initialMessages)
        {
            _player = player;
            _enemy = enemy;
            _messages = initialMessages;

        }
        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
        }
        private string FormatMessagesForViewer()
        {
            List<string> lifoMessages = new List<string>();

            for (int index = 0; index < _messages.Count; index++)
            {
                lifoMessages.Add($" <T:{GameTime().ToString(@"hh\:mm\:ss")}> " + _messages[index]);
            }

            lifoMessages.Reverse();

            return string.Join("\n\n", lifoMessages);
        }
        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }

    }

}
