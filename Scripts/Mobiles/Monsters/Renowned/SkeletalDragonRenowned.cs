using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Skeletal Dragon [Renowned] corpse")]
    public class SkeletalDragonRenowned : BaseRenowned
    {
        [Constructable]
        public SkeletalDragonRenowned()
            : base(AIType.AI_Mage)
        {
            Name = "Skeletal Dragon";
            Title = "[Renowned]";
            Body = 104;
            BaseSoundID = 0x488;

            Hue = 906;

            SetStr(898, 1030);
            SetDex(100, 200);
            SetInt(488, 620);

            SetHits(558, 599);

            SetDamage(29, 35);

            SetDamageType(ResistanceType.Physical, 75);
            SetDamageType(ResistanceType.Fire, 25);

            SetResistance(ResistanceType.Physical, 75, 80);
            SetResistance(ResistanceType.Fire, 40, 60);
            SetResistance(ResistanceType.Cold, 40, 60);
            SetResistance(ResistanceType.Poison, 70, 80);
            SetResistance(ResistanceType.Energy, 40, 60);

            SetSkill(SkillName.EvalInt, 80.1, 100.0);
            SetSkill(SkillName.Magery, 80.1, 100.0);
            SetSkill(SkillName.MagicResist, 100.3, 130.0);
            SetSkill(SkillName.Tactics, 97.6, 100.0);
            SetSkill(SkillName.Wrestling, 97.6, 100.0);

            Fame = 22500;
            Karma = -22500;

            VirtualArmor = 80;

            PackItem(new EssencePersistence());
        }

        public SkeletalDragonRenowned(Serial serial)
            : base(serial)
        {
        }

        public override Type[] UniqueSAList
        {
            get { return new[] {typeof (UndyingFlesh)}; }
        }

        public override Type[] SharedSAList
        {
            get
            {
                return new[]
                {
                    typeof (AxeOfAbandon), typeof (DemonBridleRing), typeof (DemonBridleRing), typeof (MagicalResidue),
                    typeof (DelicateScales), typeof (VoidInfusedKilt)
                };
            }
        }

        public override bool ReacquireOnMovement
        {
            get { return true; }
        }

        public override bool HasBreath
        {
            get { return true; }
        } // fire breath enabled

        public override int BreathFireDamage
        {
            get { return 0; }
        }

        public override int BreathColdDamage
        {
            get { return 100; }
        }

        public override int BreathEffectHue
        {
            get { return 0x480; }
        }

        public override double BonusPetDamageScalar
        {
            get { return (Core.SE) ? 3.0 : 1.0; }
        }

        // TODO: Undead summoning?
        public override bool AutoDispel
        {
            get { return true; }
        }

        public override Poison PoisonImmune
        {
            get { return Poison.Lethal; }
        }

        public override bool BleedImmune
        {
            get { return true; }
        }

        public override int Meat
        {
            get { return 19; }
        } // where's it hiding these? :)

        public override int Hides
        {
            get { return 20; }
        }

        public override HideType HideType
        {
            get { return HideType.Barbed; }
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 4);
            AddLoot(LootPack.Gems, 5);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            var version = reader.ReadInt();
        }
    }
}