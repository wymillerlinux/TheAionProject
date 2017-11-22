﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    public static partial class UniverseObjects
    {
        public static List<GameObject> gameObjects = new List<GameObject>()
        {
            new TravelerObject
            {
                Id = 1,
                Name = "Bag of Gold",
                SpaceTimeLocationId = 1,
                Description = "A small leather pouch filled with 9 gold coins.",
                Type = TravelerObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExpPoints = 10
            },

            new TravelerObject
            {
                Id = 2,
                Name = "Ruby of Saron",
                SpaceTimeLocationId = 3,
                Description = "A bright red jewel, roughly the size of a robin's egg.",
                Type = TravelerObjectType.Treasure,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExpPoints = 20
            },

            new TravelerObject
            {
                Id = 3,
                Name = "Rotogenic Medicine",
                SpaceTimeLocationId = 1,
                Description = "A wooden box containing a small vial filled with a blue liquid.",
                Type = TravelerObjectType.Medicine,
                Value = 45,
                CanInventory = false,
                IsConsumable = true,
                IsVisible = true,
                ExpPoints = 15
            },

            new TravelerObject
            {
                Id = 4,
                Name = "Norlan Document ND-3075",
                SpaceTimeLocationId = 5,
                Description =
                    "Memo: Origin Errata" + "/n" +
                    "Universal Date: 378598" + "/n" +
                    "/n" +
                    "It appears a potential origin for the technology is based on Plenatia 5 in the Star Reach Galaxy.",
                Type = TravelerObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExpPoints = 80
            },

            new TravelerObject
            {
                Id = 8,
                Name = "Aion Tracker",
                SpaceTimeLocationId = 0,
                Description =
                    "Standard issue device worn around wrist that allows for tracking and messaging.",
                Type = TravelerObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true,
                ExpPoints = 10
            },

            new TravelerObject
            {
                Id = 9,
                Name = "RatPak 47",
                SpaceTimeLocationId = 0,
                Description =
                    "Standard issue ration package contain nutrients for 72 hours.",
                Type = TravelerObjectType.Food,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExpPoints = 43
            },

            new TravelerObject
            {
                Id = 10,
                Name = "Stim",
                SpaceTimeLocationId = 5,
                Description =
                    "An injection that feels like something out of a movie.",
                Type = TravelerObjectType.Medicine,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true,
                ExpPoints = 22
            },
        };
    }
}