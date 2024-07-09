using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ToastyQoL.Core.Globals
{
    internal class ToastyQoLGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;

        

        public override void UpdateInventory(Item item, Player player)
        {
           if (Toggles.InfinitePotions)
            {
               if (item.type == ItemID.Campfire)
                  player.AddBuff(BuffID.Campfire, 2);

               if (item.type == ItemID.HeartLantern)
                  player.AddBuff(BuffID.HeartLamp, 2);

               if (item.type == ItemID.StarinaBottle)
                  player.AddBuff(BuffID.StarInBottle, 2);
            }
               
           
        }
    }
}
