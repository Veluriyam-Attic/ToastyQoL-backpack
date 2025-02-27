﻿using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ToastyQoL.Helpers;

namespace ToastyQoL.Core.Systems
{
    // This is forced to be quite large considering the sheer amount of bosses that exist.
    public class TieringSystem : ModSystem
    {
        public struct BossLockInformation
        {
            public Func<bool> PastTierCheck;

            public LazyLocalization BossName;

            public List<int> AssosiatedItemTypes;

            public float Weight;

            public BossLockInformation(Func<bool> pastTierCheck, string bossKey, List<int> assosiatedItemTypes, float weight = 1f)
            {
                PastTierCheck = pastTierCheck;
                BossName = new(bossKey);
                AssosiatedItemTypes = assosiatedItemTypes;
                Weight = weight;
            }

            public void AddItem(int itemType) => AssosiatedItemTypes.Add(itemType);
        }

        public static List<BossLockInformation> ItemsTieringInformation
        {
            get;
            private set;
        }

        public static List<BossLockInformation> PotionsTieringInformation
        {
            get;
            private set;
        }

        public static bool ItemShouldBeMarked(int itemType, out BossLockInformation assosiatedLockInformation)
        {
            assosiatedLockInformation = default;
            // Loop through every tier information.
            foreach (var lockInformation in ItemsTieringInformation)
            {
                // If the current item is assosiated,
                if (lockInformation.AssosiatedItemTypes.Contains(itemType))
                {
                    assosiatedLockInformation = lockInformation;
                    // And the past tier check fails,
                    if (!lockInformation.PastTierCheck())
                        return true;
                    // If it passes, it should not be marked
                    else
                        return false;
                }
            }
            return false;
        }

        public static bool PotionShouldBeMarked(int itemType, out BossLockInformation assosiatedLockInformation)
        {
            assosiatedLockInformation = default;
            // Loop through every tier information.
            foreach (var lockInformation in PotionsTieringInformation)
            {
                // If the current item is assosiated,
                if (lockInformation.AssosiatedItemTypes.Contains(itemType))
                {
                    assosiatedLockInformation = lockInformation;
                    // And the past tier check fails,
                    if (!lockInformation.PastTierCheck())
                        return true;
                    // If it passes, it should not be marked
                    else
                        return false;
                }
            }
            return false;
        }

        public static bool LockItemOrPotionFromUse(int itemType)
        {
            if (Toggles.ItemLock)
            {
                foreach (var lockInformation in ItemsTieringInformation)
                {
                    // If the current item is assosiated,
                    if (lockInformation.AssosiatedItemTypes.Contains(itemType))
                    {
                        // And the past tier check fails, return true.
                        if (!lockInformation.PastTierCheck())
                            return false;
                    }
                }
            }
            if (Toggles.PotionLock)
            {    
                foreach (var lockInformation in PotionsTieringInformation)
                {
                    // If the current item is assosiated,
                    if (lockInformation.AssosiatedItemTypes.Contains(itemType))
                    {
                        // And the past tier check fails, return true.
                        if (!lockInformation.PastTierCheck())
                            return false;
                    }
                }
            }
            return true;
        }

        public override void Load()
        {
            ItemsTieringInformation = new()
            {
                new BossLockInformation(() => NPC.downedSlimeKing,
                    $"NPCName.KingSlime",
                    new()
                    {

                        ItemID.SlimySaddle,
                        ItemID.SlimeHook,
                        ItemID.RoyalGel
                    }),

                new BossLockInformation(() => NPC.downedBoss1,
                    $"NPCName.EyeofCthulhu",
                    new()
                    {
                        //Vanilla
                        ItemID.Binoculars,
                        ItemID.EoCShield,
                    }),

                 new BossLockInformation(() => SavingSystem.DownedBrain && SavingSystem.DownedEater,
                    $"Mods.ToastyQoL.Tiering.Eowboc",
                    new()
                    {
                        //Vanilla
                        ItemID.BrainOfConfusion,
                        ItemID.WormScarf,
                        ItemID.MeteorHelmet,
                        ItemID.MeteorSuit,
                        ItemID.MeteorLeggings,
                        ItemID.SpaceGun,
                        ItemID.StarCannon
                    }),

                  new BossLockInformation(() => NPC.downedQueenBee,
                    $"NPCName.QueenBee",
                    new()
                    {
                        //Vanilla
                        ItemID.BeeHeadgear,
                        ItemID.BeeBreastplate,
                        ItemID.BeeGreaves,
                        ItemID.BeesKnees,
                        ItemID.BeeKeeper,
                        ItemID.BeeGun,
                        ItemID.HoneyComb,
                        ItemID.Nectar,
                        ItemID.HoneyedGoggles,
                        ItemID.Beenade,
                        ItemID.HiveBackpack
                    }),

                  new BossLockInformation(() => NPC.downedDeerclops,
                    $"NPCName.Deerclops",
                    new()
                    {
                        ItemID.BoneHelm,
                        ItemID.ChesterPetItem,
                        ItemID.Eyebrella,
                        ItemID.DontStarveShaderItem,
                        ItemID.PewMaticHorn,
                        ItemID.WeatherPain,
                        ItemID.HoundiusShootius,
                        ItemID.LucyTheAxe
                    }),

                  new BossLockInformation(() => NPC.downedBoss3,
                    $"NPCName.SkeletronHead",
                    new()
                    {
                        //Vanilla
                        ItemID.ChippysCouch,
                        ItemID.BoneGlove,
                        ItemID.SkeletronHand,
                        ItemID.BookofSkulls,
                    }),

                  new BossLockInformation(() => Main.hardMode,
                    $"NPCName.WallofFlesh",
                    new()
                    {
                        //Vanilla
                        ItemID.MechanicalGlove,
                        ItemID.DemonHeart,
                        ItemID.Pwnhammer,
                        ItemID.SorcererEmblem,
                        ItemID.WarriorEmblem,
                        ItemID.RangerEmblem,
                        ItemID.SummonerEmblem,
                        ItemID.BreakerBlade,
                        ItemID.ClockworkAssaultRifle,
                        ItemID.LaserRifle,
                        ItemID.FireWhip
                    }),

                  new BossLockInformation(() => NPC.downedQueenSlime,
                    $"NPCName.QueenSlimeBoss",
                    new()
                    {
                        ItemID.CrystalNinjaHelmet,
                        ItemID.CrystalNinjaChestplate,
                        ItemID.CrystalNinjaLeggings,
                        ItemID.VolatileGelatin,
                        ItemID.QueenSlimeHook,
                        ItemID.QueenSlimeMountSaddle,
                        ItemID.Smolstar
                    }),

                   new BossLockInformation(() => NPC.downedMechBoss1,
                    $"Mods.ToastyQoL.Tiering.DestroyerShort",
                    new()
                    {
                        ItemID.Megashark
                    }),

                   new BossLockInformation(() => NPC.downedMechBoss2,
                    "Enemies.TheTwins",
                    new()
                    {
                        ItemID.MagicalHarp,
                        ItemID.RainbowRod,
                        ItemID.OpticStaff
                    }),

                   new BossLockInformation(() => NPC.downedMechBoss3,
                    $"NPCName.SkeletronPrime",
                    new()
                    {
                        ItemID.Flamethrower
                    }),

                   new BossLockInformation(() => NPC.downedPlantBoss,
                    $"NPCName.Plantera",
                    new()
                    {
                        //Vanilla
                        ItemID.SporeSac,
                        ItemID.GrenadeLauncher,
                        ItemID.VenusMagnum,
                        ItemID.NettleBurst,
                        ItemID.LeafBlower,
                        ItemID.FlowerPow,
                        ItemID.WaspGun,
                        ItemID.Seedler,
                        ItemID.Seedling,
                        ItemID.TheAxe,
                        ItemID.PygmyStaff,
                        ItemID.ThornHook,
                        ItemID.ChainGun,
                        ItemID.ChristmasTreeSword
                    }),

                   new BossLockInformation(() => NPC.downedGolemBoss,
                    $"NPCName.Golem",
                    new()
                    {
                        //Vanilla
                        ItemID.FireworksLauncher,
                        ItemID.ShinyStone,
                        ItemID.Picksaw,
                        ItemID.Stynger,
                        ItemID.PossessedHatchet,
                        ItemID.SunStone,
                        ItemID.EyeoftheGolem,
                        ItemID.HeatRay,
                        ItemID.StaffofEarth,
                        ItemID.GolemFist,
                        ItemID.BeetleHusk,
                        ItemID.DestroyerEmblem,
                        ItemID.SniperScope,
                        ItemID.FireGauntlet
                    }),

                   new BossLockInformation(() => NPC.downedEmpressOfLight,
                    $"NPCName.HallowBoss",
                    new()
                    {
                        ItemID.PiercingStarlight,
                        ItemID.RainbowWhip,
                        ItemID.EmpressBlade,
                        ItemID.FairyQueenMagicItem,
                        ItemID.FairyQueenRangedItem,
                        ItemID.RainbowWings,
                        ItemID.SparkleGuitar,
                        ItemID.RainbowCursor
                    }),

                   new BossLockInformation(() => NPC.downedFishron,
                    $"NPCName.DukeFishron",
                    new()
                    {
                        //Vanilla
                        ItemID.ShrimpyTruffle,
                        ItemID.BubbleGun,
                        ItemID.Flairon,
                        ItemID.RazorbladeTyphoon,
                        ItemID.TempestStaff,
                        ItemID.Tsunami,
                        ItemID.FishronWings
                    }),

                   new BossLockInformation(() => NPC.downedAncientCultist,
                    $"Mods.ToastyQoL.Tiering.CultistShort",
                    new()
                    {
                        //Vanilla
                        ItemID.LunarCraftingStation,
                        ItemID.SolarEruption,
                        ItemID.DayBreak,
                        ItemID.Phantasm,
                        ItemID.VortexBeater,
                        ItemID.NebulaBlaze,
                        ItemID.NebulaArcanum,
                        ItemID.StardustDragonStaff,
                        ItemID.StardustCellStaff
                    }),

                   new BossLockInformation(() => NPC.downedMoonlord,
                    $"Enemies.MoonLord",
                    new()
                    {
                        //Vanilla
                        ItemID.GravityGlobe,
                        ItemID.SuspiciousLookingTentacle,
                        ItemID.LongRainbowTrailWings,
                        ItemID.Meowmere,
                        ItemID.Terrarian,
                        ItemID.StarWrath,
                        ItemID.SDMG,
                        ItemID.LastPrism,
                        ItemID.LunarFlareBook,
                        ItemID.RainbowCrystalStaff,
                        ItemID.MoonlordTurretStaff,
                        ItemID.Celeb2,
                        ItemID.PortalGun,
                        ItemID.LunarOre,
                        ItemID.MeowmereMinecart,
                        ItemID.MoonlordArrow,
                        ItemID.MoonlordBullet
                    }),
            };

            PotionsTieringInformation = new()
            {
                new BossLockInformation(() => NPC.downedQueenBee,
                    $"NPCName.QueenBee",
                    new()
                    {
                        ItemID.FlaskofFire,
                        ItemID.FlaskofPoison,
                        ItemID.FlaskofParty
                    }),
            };
        }

        public override void Unload()
        {
            ItemsTieringInformation = null;
            PotionsTieringInformation = null;
        }
    }
}
