using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Traveler : Character
    {
        #region ENUMERABLES
        public enum StartingItem
        {
            None,
            Berry,
            HealthPak,
            StimPak
        }
        #endregion

        #region FIELDS
        private string _homePlanet;
        private bool _isTerrorist;
        private Enum _startingItem;
        #endregion


        #region PROPERTIES

        public string HomePlanet
        {
            get { return _homePlanet; }
            set { _homePlanet = value; }
        }
        public bool IsTerrorist
        {
            get { return _isTerrorist; }
            set { _isTerrorist = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Traveler()
        {

        }

        public Traveler(string name, RaceType race, int spaceTimeLocationID) : base(name, race, spaceTimeLocationID)
        {

        }

        #endregion


        #region METHODS

        public override string Greeting()
        {
            return $"Greetings, I am {base.Name}, and I am {base.Race}, and I am from {HomePlanet}";
        }
        #endregion
    }
}
