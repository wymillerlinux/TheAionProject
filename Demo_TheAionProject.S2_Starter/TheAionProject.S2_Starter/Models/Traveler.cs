using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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


        #endregion

        #region FIELDS

        private List<int> _spaceTimeLocationsVisited;
        private int _health;
        private int _expPoints;
        private int _lives;

        #endregion


        #region PROPERTIES

        public List<int> SpaceTimeLocationsVisited
        {
            get { return _spaceTimeLocationsVisited; }
            set { _spaceTimeLocationsVisited = value; }
        }

        public int Health 
        {
            get { return _health; }
            set { _health = value; }
        }
        
        public int ExpPoints 
        {
            get { return _expPoints; }
            set { _expPoints = value; }
        }
        
        public int Lives 
        {
            get { return _lives; }
            set { _lives = value; }
        }
        
        #endregion


        #region CONSTRUCTORS

        public Traveler()
        {
            _spaceTimeLocationsVisited = new List<int>();
        }

        public Traveler(string name, RaceType race, int spaceTimeLocationID) : base(name, race, spaceTimeLocationID)
        {
            _spaceTimeLocationsVisited = new List<int>();
        }

        #endregion


        #region METHODS

        public bool HasVisited(int _spaceTimeLocationID)
        {
            if (SpaceTimeLocationsVisited.Contains(_spaceTimeLocationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
