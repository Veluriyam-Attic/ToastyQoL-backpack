using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ToastyQoL.Content.Items.Spawners.PreHardmode
{
    public class BoCSpawner : ModItem
    {
        public int Amount = 1;
        public Color TextColor = new(153, 0, 0);
        public string bossname = Language.GetTextValue($"NPCName.BrainofCthulhu");

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Brain Of Cthulhu Spawner");
            /* Tooltip.SetDefault("Instantly summons Brain Of Cthulhu\n" +
                "Right-click to increase spawn count up to 10\nSpawn Count"); */
        }
        public override void SetDefaults()
        {
            Item item = Item;
            item.width = 58;
            item.height = 64;
            item.maxStack = 1;
            item.rare = ItemRarityID.Purple;
            item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = ItemUseStyleID.Swing;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (player.altFunctionUse == 2)
            {
                int Direction = Math.Sign(Main.MouseWorld.X - player.position.X);
                Amount += Direction;
                if (Amount > 10)
                    Amount = 1;
                if (Amount < 1)
                    Amount = 10;
                Main.NewText(Language.GetTextValue($"Mods.ToastyQoL.Items.SpawnCountChat", bossname, Amount), TextColor);
            }
            else
            {
                for (int i = 0; i < Amount; i++)
                {
                    int idx = NPC.NewNPC(null, (int)player.Center.X - 600, (int)player.Center.Y, NPCID.BrainofCthulhu, 1);
                }

            }
            return true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Color color = ToastyQoLUtils.TwoColorPulse(Color.Pink, Color.Tomato, 2);
            TooltipLine nameLine = tooltips.FirstOrDefault((x) => x.Name == "ItemName" && x.Mod == "Terraria");
            if (nameLine != null)
            {
                nameLine.OverrideColor = color;
            }
            Player player = Main.player[Main.myPlayer];
            if (player is null)
                return;
            foreach (TooltipLine l in tooltips)
            {
                if (l.Text == null)
                    continue;

                if (l.Text.StartsWith("[Spawn Count]"))
                {
                    l.OverrideColor = color;
                    l.Text = Language.GetTextValue($"Mods.ToastyQoL.Items.SpawnCountTooltip", Amount);


                }
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.BloodySpine, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
