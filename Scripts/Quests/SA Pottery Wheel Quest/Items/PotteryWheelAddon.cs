////////////////////////////////////////


//                                    //
//   Generated by CEO's YAAAG - V1.2  //
// (Yet Another Arya Addon Generator) //
//                                    //

////////////////////////////////////////

namespace Server.Items
{
    public class PotteryWheelAddon : BaseAddon
    {
        private static readonly int[,] m_AddOnSimpleComponents =
        {
            {2886, 1, 0, 8} // 7	
        };

        [Constructable]
        public PotteryWheelAddon()
        {
            for (var i = 0; i < m_AddOnSimpleComponents.Length/4; i++)
                AddComponent(new AddonComponent(m_AddOnSimpleComponents[i, 0]), m_AddOnSimpleComponents[i, 1],
                    m_AddOnSimpleComponents[i, 2], m_AddOnSimpleComponents[i, 3]);

            AddComplexComponent(this, 2602, 0, 0, 0, 1861, -1, "", 1); // 1
            AddComplexComponent(this, 7026, 1, 0, 0, 1725, -1, "", 1); // 2
            AddComplexComponent(this, 7027, 1, 0, 2, 1725, -1, "", 1); // 3
            AddComplexComponent(this, 7027, 1, 0, 3, 1725, -1, "", 1); // 4
            AddComplexComponent(this, 7027, 1, 0, 4, 1725, -1, "", 1); // 5
            AddComplexComponent(this, 7026, 1, 0, 5, 1725, -1, "", 1); // 6
            AddComplexComponent(this, 4017, 1, 1, 0, 1725, -1, "", 1); // 8
            AddComplexComponent(this, 7026, 1, 1, 4, 1725, -1, "", 1); // 9
        }

        public PotteryWheelAddon(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddonDeed Deed
        {
            get { return new PotteryWheelAddonDeed(); }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            var version = reader.ReadInt();
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset,
            int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset,
            int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
        }
    }

    public class PotteryWheelAddonDeed : BaseAddonDeed
    {
        [Constructable]
        public PotteryWheelAddonDeed()
        {
            Name = "PotteryWheelAddon";
        }

        public PotteryWheelAddonDeed(Serial serial)
            : base(serial)
        {
        }

        public override BaseAddon Addon
        {
            get { return new PotteryWheelAddon(); }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            var version = reader.ReadInt();
        }
    }
}