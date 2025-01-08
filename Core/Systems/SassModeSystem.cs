using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ToastyQoL.Helpers;

namespace ToastyQoL.Core.Systems
{
    internal class SassModeSystem : ModSystem
    {
        private static string SassToSay = null;

        internal static List<LazyLocalization> GenericSassQuotesLose
        {
            get;
            set;
        } = [];

        internal static List<LazyLocalization> GenericSassQuotesWin
        {
            get;
            set;
        } = [];

        internal static Dictionary<int, List<LazyLocalization>> SassSpecificBossQuotes
        {
            get;
            set;
        } = [];

        public override void Load()
        {
            for(int i = 1; i <= 18; ++i)
            {
                GenericSassQuotesLose.Add(new($"Mods.ToastyQoL.SassQuotes.Lose.{i}"));
            }
            //GenericSassQuotesLose = new()
            //{
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.1"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.2"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.3"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.4"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.5"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.6"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.7"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.8"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.9"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.10"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.11"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.12"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.13"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.14"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.15"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.16"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.17"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Lose.18")
            //};

            for(int i = 1; i <= 8; ++i)
            {
                GenericSassQuotesWin.Add(new($"Mods.ToastyQoL.SassQuotes.Win.{i}"));
            }
            //GenericSassQuotesWin = new()
            //{
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Win.1"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Win.2"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Win.3"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Win.4"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Win.5"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Win.6"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Win.7"),
            //    Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Win.8"),
            //};

            SassSpecificBossQuotes = new()
            {
                [NPCID.KingSlime] = [new($"Mods.ToastyQoL.SassQuotes.Specific.KingSlime"), new($"Mods.ToastyQoL.SassQuotes.Specific.KingSlimeAlt")],
                [NPCID.EyeofCthulhu] = [new($"Mods.ToastyQoL.SassQuotes.Specific.EyeGeneric")],
                [NPCID.Plantera] = [new($"Mods.ToastyQoL.SassQuotes.Specific.Plantera")],
                [NPCID.WallofFlesh] = [new($"Mods.ToastyQoL.SassQuotes.Specific.Spacebar")],
                [NPCID.Deerclops] = [new($"Mods.ToastyQoL.SassQuotes.Specific.Spacebar")],
                [NPCID.Retinazer] = [new($"Mods.ToastyQoL.SassQuotes.Specific.EyeGeneric")],
                [NPCID.Spazmatism] = [new($"Mods.ToastyQoL.SassQuotes.Specific.EyeGeneric")],
                [NPCID.QueenBee] = [new($"Mods.ToastyQoL.SassQuotes.Specific.QueenBee")],
                [NPCID.DukeFishron] = [new($"Mods.ToastyQoL.SassQuotes.Specific.Fishron"), new($"Mods.ToastyQoL.SassQuotes.Specific.FishronAlt")]
            };

            //SassSpecificBossQuotes = new()
            //{
            //    [NPCID.KingSlime] = new() { Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Specific.KingSlime"), Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Specific.KingSlimeAlt") },
            //    [NPCID.EyeofCthulhu] = new() { Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Specific.EyeGeneric") },
            //    [NPCID.Plantera] = new () { Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Specific.Plantera") },
            //    [NPCID.WallofFlesh] = new() { Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Specific.Spacebar") },
            //    [NPCID.Deerclops] = new() { Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Specific.Spacebar") },
            //    [NPCID.Retinazer] = new() { Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Specific.EyeGeneric") },
            //    [NPCID.Spazmatism] = new() { Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Specific.EyeGeneric") },
            //    [NPCID.QueenBee] = new() { Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Specific.QueenBee") },
            //    [NPCID.DukeFishron] = new() { Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Specific.Fishron"), Language.GetTextValue($"Mods.ToastyQoL.SassQuotes.Specific.FishronAlt") }
            //};
        }

        public override void Unload()
        {
            GenericSassQuotesLose = null;
            GenericSassQuotesWin = null;
            SassSpecificBossQuotes = null;
        }

        public static void SassModeHandler(NPC boss, bool bossDead)
        {
            if (bossDead)
                SassToSay = SassMode_BossDead(boss.type);
            else
                SassToSay = SassMode_BossAlive(boss.type);

            if (SassToSay != null)
                ToastyQoLUtils.DisplayText(SassToSay, Color.Orange);
        }

        private static string SassMode_BossDead(int bossType)
        {
            string textToReturn;

            int index = Main.rand.Next(GenericSassQuotesWin.Count);

            textToReturn = GenericSassQuotesWin[index].ToString();
            if (SassSpecificBossQuotes.TryGetValue(bossType, out var texts) && Main.rand.NextBool())
                textToReturn = texts[Main.rand.Next(0, texts.Count)].ToString();

            return textToReturn;
        }

        private static string SassMode_BossAlive(int bossType)
        {
            string textToReturn;
            if (SassSpecificBossQuotes.TryGetValue(bossType, out var texts) && Main.rand.NextBool(5))
                textToReturn = texts[Main.rand.Next(0, texts.Count)].ToString();
            else
                textToReturn = Main.rand.NextFromList(GenericSassQuotesLose.ToArray()).ToString();

            return textToReturn;
        }
    }
}
