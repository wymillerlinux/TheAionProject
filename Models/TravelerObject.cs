﻿using System;
using System.Net.NetworkInformation;
using System.Security.Permissions;

namespace TheAionProject
{
    public class TravelerObject : GameObject
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override int SpaceTimeLocationId { get; set; }
        public Traveler Inventory { get; set; }
        public TravelerObjectType Type { get; set; }
        public bool CanInventory { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsVisible { get; set; }
        public int Value { get; set; }
        public int ExpPoints { get; set; }
    }
}