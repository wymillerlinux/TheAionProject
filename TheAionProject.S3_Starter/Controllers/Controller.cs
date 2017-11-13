using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TheAionProject
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Traveler _gameTraveler;
        private Universe _gameUniverse;
        private SpaceTimeLocation _currentLocation;
        private bool _playingGame;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameTraveler = new Traveler();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameUniverse);
            _playingGame = true;

            Console.CursorVisible = false;
        }

        //
        // timer example, it's cool, maybe use timers for a countdown?
        // timer example included players dying after 5 five seconds cause why not?
        //
        //private void InitializeTimers()
        //{
        //    Timer InstantDeath = new Timer(5000);
        //    InstantDeath.Elapsed += InstantDeathHandler;
        //    InstantDeath.Start();
        //    InstantDeath.AutoReset = false;
            
        //}

        //private void InstantDeathHandler(object sender, ElapsedEventArgs e)
        //{
        //    _gameConsoleView.DisplayGamePlayScreen("You Lose!", "\t\tYou are dead.", ActionMenu.MainMenu, "");
        //}

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            TravelerAction travelerActionChoice = TravelerAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

            // init timers, example, see method for details on why I didn't add this.
            // InitializeTimers();

            //
            // game loop
            //
            while (_playingGame)
            {
                //
                // process all flags, events, and stats
                //
                UpdateGameStatus();

                //
                // get next game action from player
                //
                travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

                //
                // choose an action based on the player's menu choice
                //
                switch (travelerActionChoice)
                {
                    case TravelerAction.None:
                        break;

                    case TravelerAction.TravelerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;

                    case TravelerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case TravelerAction.Travel:
                        //
                        // get new location choice and update the current location property
                        //                        
                        _gameTraveler.SpaceTimeLocationID = _gameConsoleView.DisplayGetNextSpaceTimeLocation();
                        _currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationID);

                        //
                        // display the new space-time location info
                        //
                        _gameConsoleView.DisplayCurrentLocationInfo();
                        break;

                    case TravelerAction.TravelerLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                          break;

                    case TravelerAction.ListSpaceTimeLocations:
                        _gameConsoleView.DisplayListOfSpaceTimeLocations();
                        break;

                    case TravelerAction.Exit:
                        _playingGame = false;
                        break;
                        
                    case TravelerAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObject();
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Traveler traveler = _gameConsoleView.GetInitialTravelerInfo();

            _gameTraveler.Name = traveler.Name;
            _gameTraveler.Age = traveler.Age;
            _gameTraveler.Race = traveler.Race;
            _gameTraveler.SpaceTimeLocationID = 1;

            _gameTraveler.ExperiencePoints = 0;
            _gameTraveler.Health = 100;
            _gameTraveler.Lives = 3;
        }

        private void UpdateGameStatus()
        {
            if (!_gameTraveler.HasVisited(_currentLocation.SpaceTimeLocationID))
            {
                //
                // add new location to the list of visited locations if this is a first visit
                //
                _gameTraveler.SpaceTimeLocationsVisited.Add(_currentLocation.SpaceTimeLocationID);

                //
                // update experience points for visiting locations
                //
                _gameTraveler.ExperiencePoints += _currentLocation.ExperiencePoints;
            }

            if (_gameTraveler.SpaceTimeLocationID == 2)
            {
                _gameTraveler.Lives -= 1;
            }

            if (_gameTraveler.Lives == 0)
            {
                _gameConsoleView.DisplayGamePlayScreen("Game Over", Text.GameOver(), ActionMenu.MainMenu, "");
                _gameConsoleView.GetContinueKey();
                Environment.Exit(0);
            }
        }

        #endregion
    }
}
