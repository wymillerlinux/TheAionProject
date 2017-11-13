using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    public class TravelerObject : GameObject
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        //public override int SpaceTimeLocationId { get; set; }
        public TravelerObjectType Type { get; set; }
        public string PickUpMessage { get; set; }
        public string PutDownMessage { get; set; }
        public bool CanInventory { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsVisible { get; set; }
        public int Value { get; set; }

        //
        // raise event when object is added to inventory
        //
        private int _spaceTimeLocationId;

        public int SpaceTimeLocationId
        {
            get { return _spaceTimeLocationId; }
            set
            {
                _spaceTimeLocationId = value;
                if (value == 0)
                {
                    OnObjectAddedToInventory();
                }
            }
        }

        public event EventHandler ObjectAddedToInventory;
        public void OnObjectAddedToInventory()
        {
            if (ObjectAddedToInventory != null)
            {
                ObjectAddedToInventory(this, EventArgs.Empty);
            }
        }
    }
}
