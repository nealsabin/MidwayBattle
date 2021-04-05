using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidwayBattle.Models;
using MidwayBattle;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Windows;

namespace MidwayBattle.PresentationLayer
{
    /// <summary>
    /// view model for the game session view
    /// </summary>
    public class GameViewModel : ObservableObject
    {
        #region ENUMS

        #endregion

        #region FIELDS

        private DateTime _gameStartTime;
        private string _gameTimeDisplay;
        //private TimeSpan _gameTime;

        private Player _player;
        private Enemy _enemy;
        private List<string> _messages;

        private Map _gameMap;
        private Location _currentLocation;
        private Location _northLocation, _eastLocation, _southLocation, _westLocation;
        private string _currentLocationInformation;

        private GameItem _currentGameItem;
        private Npc _currentNpc;

        private Random random = new Random();

        #endregion

        #region PROPERTIES
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
            get { return _currentLocation.Message; }
        }
        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                _currentLocationInformation = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
                OnPropertyChanged(nameof(IsNwQuad));
                OnPropertyChanged(nameof(IsNeQuad));
                OnPropertyChanged(nameof(IsSeQuad));
                OnPropertyChanged(nameof(IsSwQuad));
            }
        }

        public Location NorthLocation
        {
            get { return _northLocation; }
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }

        public Location EastLocation
        {
            get { return _eastLocation; }
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }

        public Location SouthLocation
        {
            get { return _southLocation; }
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }

        public Location WestLocation
        {
            get { return _westLocation; }
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }
        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }
        public string MissionTimeDisplay
        {
            get { return _gameTimeDisplay; }
            set
            {
                _gameTimeDisplay = value;
                OnPropertyChanged(nameof(MissionTimeDisplay));
            }
        }
        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set
            {
                _currentGameItem = value;
                OnPropertyChanged(nameof(CurrentGameItem));
                //if(_currentGameItem != null && _currentGameItem is Weapon)
                //{
                //    _player.CurrentWeapon = _currentGameItem.GameItem as Weapon;
                //}
            }
        }

        #region Checking Direction Locations
        public bool HasNorthLocation
        {
            get
            {
                if (NorthLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool HasEastLocation
        {
            get
            {
                if (EastLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool HasSouthLocation
        {
            get
            {
                if (SouthLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool HasWestLocation
        {
            get
            {
                if (WestLocation != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion


        #region Current Quadrant Display
        public bool IsNwQuad
        {
            get
            {
                if (CurrentLocation.Id == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool IsNeQuad
        {
            get
            {
                if (CurrentLocation.Id == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool IsSeQuad
        {
            get
            {
                if (CurrentLocation.Id == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool IsSwQuad
        {
            get
            {
                if (CurrentLocation.Id == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #endregion

        #region CONSTRUCTORS

        public GameViewModel()
        {

        }

        public GameViewModel(
            Player player,
            Enemy enemy,
            List<string> initialMessages,
            Map gameMap,
            GameMapCoordinates currentLocationCoordinates)
        {
            _player = player;
            _enemy = enemy;
            _messages = initialMessages;

            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
            InitializeView();
        }

        /// <summary>
        /// initial setup of the game session view
        /// </summary>
        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            UpdateAvailableTravelPoints();
            _currentLocationInformation = CurrentLocation.Description;
            _player.UpdateInventoryCategories();
        }

        #endregion

        #region METHODS

        private void UpdateAvailableTravelPoints()
        {
            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            if (_gameMap.NorthLocation() != null)
            {
                Location nextNorthLocation = _gameMap.NorthLocation();

                if (nextNorthLocation.Accessible == true)
                {
                    NorthLocation = nextNorthLocation;
                }
            }

            if (_gameMap.EastLocation() != null)
            {
                Location nextEastLocation = _gameMap.EastLocation();

                if (nextEastLocation.Accessible == true)
                {
                    EastLocation = nextEastLocation;
                }
            }

            if (_gameMap.SouthLocation() != null)
            {
                Location nextSouthLocation = _gameMap.SouthLocation();

                if (nextSouthLocation.Accessible == true)
                {
                    SouthLocation = nextSouthLocation;
                }
            }

            if (_gameMap.WestLocation() != null)
            {
                Location nextWestLocation = _gameMap.WestLocation();

                if (nextWestLocation.Accessible == true)
                {
                    WestLocation = nextWestLocation;
                }
            }
        }

        private void OnPlayerMove()
        {
            //
            // adding location to list of visited locations and updating experience points
            //
            if (!_player.HasVisited(_currentLocation))
            {
                _player.LocationsVisited.Add(_currentLocation);

                _player.ExperiencePoints += _currentLocation.ModifyExperiencePoints;

                OnPropertyChanged(nameof(Player));
            }
        }

        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.MoveNorth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.MoveEast();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.MoveSouth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.MoveWest();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }

        public Npc CurrentNpc
        {
            get { return _currentNpc; }
            set
            {
                _currentNpc = value;
                OnPropertyChanged(nameof(CurrentNpc));
            }
        }

        #region Actions
        public void AddItemToInventory()
        {
            if(_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);
                _player.UpdateInventoryCategories();
            }
        }
        public void RemoveItemFromInventory()
        {
            if(_currentGameItem != null)
            {
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

                OnPlayerPutDown(selectedGameItem);
                _player.UpdateInventoryCategories();
            }
        }
        public void OnUseGameItem()
        {
            switch (_currentGameItem)
            {
                //case Weapon weapon:
                //    ProcessWeaponUse(weapon);
                //    break;
                case Provisions provisions:
                    ProcessProvisionsUse(provisions);
                    break;
                default:
                    break;
            }
        }

        private void ProcessProvisionsUse(Provisions provisions)
        {
            _player.Health += provisions.Value;
            OnPropertyChanged(nameof(Player));
        }

        ////to delete
        //private void ProcessWeaponUse(Weapon weapon)
        //{
        //    _enemy.Health -= weapon.Damage;
        //    OnPropertyChanged(nameof(Enemy));
        //    CheckEnemyHealth(Enemy);
        //}

        ////to delete
        //private void CheckEnemyHealth(Enemy enemy)
        //{
        //    if(_enemy.Health <= 0)
        //    {
        //        _enemy.Lives -= 1;
        //        _enemy.Health = 100;
        //        OnPropertyChanged(nameof(Enemy));
        //    }
        //} 

        private void OnPlayerPickUp(GameItem gameItem)
        {
            _player.ExperiencePoints += gameItem.ExperiencePoints;
            OnPropertyChanged(nameof(Player));
        }

        private void OnPlayerPutDown(GameItem gameItem)
        {
            _player.ExperiencePoints -= gameItem.ExperiencePoints;
            OnPropertyChanged(nameof(Player));
        }

        private void OnPlayerDies(string message)
        {
            string messagetext = message +
                "\n\nWould you like to play again?";

            string titleText = "Death";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuiteApplication();
                    break;
            }
        }

        public void OnPlayerTalkTo()
        {
            if(CurrentNpc != null && CurrentNpc is ISpeak)
            {
                ISpeak speakingNpc = CurrentNpc as ISpeak;
                CurrentLocationInformation = speakingNpc.Speak();
            }
        }
        public void OnPlayerAttack()
        {
            _player.BattleMode = BattleModeName.ATTACK;
            Battle();
        }
        public void OnPlayerDefend()
        {
            _player.BattleMode = BattleModeName.DEFEND;
            Battle();
        }
        public void OnPlayerRetreat()
        {
            _player.BattleMode = BattleModeName.RETREAT;
            Battle();
        }
        private void QuiteApplication()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// player chooses to reset game
        /// </summary>
        private void ResetPlayer()
        {
            Environment.Exit(0);
        }

        #endregion

        #region Battle
        private void Battle()
        {
            if(_currentNpc is IBattle)
            {
                IBattle battleNpc = _currentNpc as IBattle;
                int playerHitPoints = 0;
                int battleNpcHitPoints = 0;
                string battleInformation = "";

                if(_player.CurrentWeapon != null)
                {
                    playerHitPoints = CalculatePlayerHitPoints();
                }
                else
                {
                    battleInformation = "You have no weapon." + Environment.NewLine;
                }

                if(battleNpc.CurrentWeapon != null)
                {
                    battleNpcHitPoints = CalculateNpcHitPoints(battleNpc);
                }
                else
                {
                    battleInformation = $"Entering into battle with {_currentNpc.Name} who is not a war ship.";
                }

                //
                // build out the text for the current location information
                //
                battleInformation +=
                    $"Player: {_player.BattleMode}     Hit Points: {playerHitPoints}" + Environment.NewLine +
                    $"NPC: {battleNpc.BattleMode}     Hit Points: {battleNpcHitPoints}" + Environment.NewLine;

                //battle results
                if(playerHitPoints >= battleNpcHitPoints)
                {
                    battleInformation += $"You have destroyed {_currentNpc.Name}.";
                    _currentLocation.Npcs.Remove(_currentNpc);
                }
                else
                {
                    battleInformation += $"You have been destroyed by {_currentNpc.Name}.";
                }

                CurrentLocationInformation = battleInformation;
                if (_player.Lives <= 0) OnPlayerDies("Your ship has been completely destroyed.");
            }
            else
            {
                CurrentLocationInformation = "The current ship is not prepared for battle.";
                _player.ExperiencePoints -= 5;
            }
        }

        private int CalculatePlayerHitPoints()
        {
            int playerHitPoints = 0;
            switch (_player.BattleMode)
            {
                case BattleModeName.ATTACK:
                    playerHitPoints = _player.Attack();
                    break;
                case BattleModeName.DEFEND:
                    playerHitPoints = _player.Defend();
                    break;
                case BattleModeName.RETREAT:
                    playerHitPoints = _player.Retreat();
                    break;
            }
            return playerHitPoints;
        }

        private int CalculateNpcHitPoints(IBattle battleNpc)
        {
            int battleNpcHitPoints = 0;

            switch (NpcBattleResponse())
            {
                case BattleModeName.ATTACK:
                    battleNpcHitPoints = battleNpc.Attack();
                    break;
                case BattleModeName.DEFEND:
                    battleNpcHitPoints = battleNpc.Defend();
                    break;
                case BattleModeName.RETREAT:
                    battleNpcHitPoints = battleNpc.Retreat();
                    break;
            }
            return battleNpcHitPoints;
        }

        private BattleModeName NpcBattleResponse()
        {
            BattleModeName npcBattleResponse = BattleModeName.RETREAT;

            switch (DieRoll(3))
            {
                case 1:
                    npcBattleResponse = BattleModeName.ATTACK;
                    break;
                case 2:
                    npcBattleResponse = BattleModeName.DEFEND;
                    break;
                case 3:
                    npcBattleResponse = BattleModeName.RETREAT;
                    break;
            }
            return npcBattleResponse;
        }
        #endregion

        private int DieRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }

        #endregion

        #region EVENTS



        #endregion
    }

}