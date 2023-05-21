using UnityEngine;

namespace NexusUprising
{
    namespace Enumerators
    {
        public enum ItemCategory
        {
            Null_Object_Type = 0,
            Weapon_Melee = 1,
            Weapon_Ranged = 2,
            Weapon_Magic = 3,

            Accessory = 4,
            Equipment_Head = 5,
            Equipment_Arms = 6,
            Equipment_Body = 7,
            Equipment_Legs = 8,
            Equipment_Feet = 9,

            Material = 10,
            Quest = 11,
        }

        public enum ItemRarity
        {
            Common = 1,
            Uncommon = 2,
            Rare = 3,
            Epic = 4,
            Legendary = 5,
            Mythical = 6,
            Otherworldly = 7,
        }

        public enum ObjectType
        {
            Player,
            Enemy,
            Level
        }
    }

    namespace Functions
    {
        public static class Common
        {
            public static GameObject FindPlayer(GameObject playerGO)
            {
                GameObject newPlayerGO;

                if (playerGO == null)
                {
                    newPlayerGO = GameObject.FindWithTag("Player");
                    playerGO = newPlayerGO;
                }
                return playerGO;
            }
        }
    }
}
