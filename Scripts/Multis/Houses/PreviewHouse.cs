using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Multis
{
    public class PreviewHouse : BaseMulti
    {
        private List<Item> m_Components;
        private Timer m_Timer;

        public PreviewHouse(int multiID)
            : base(multiID)
        {
            m_Components = new List<Item>();

            MultiComponentList mcl = Components;

            for (int i = 1; i < mcl.List.Length; ++i)
            {
                MultiTileEntry entry = mcl.List[i];

                if (entry.m_Flags == 0)
                {
                    //Item item = new Static((int)entry.m_ItemID);
                    Item item = new Static(entry.m_ItemID & TileData.MaxItemValue);

                    item.MoveToWorld(new Point3D(X + entry.m_OffsetX, Y + entry.m_OffsetY, Z + entry.m_OffsetZ), Map);

                    m_Components.Add(item);
                }
            }

            m_Timer = new DecayTimer(this);
            m_Timer.Start();
        }

        public PreviewHouse(Serial serial)
            : base(serial)
        {
        }

        public override void OnLocationChange(Point3D oldLocation)
        {
            base.OnLocationChange(oldLocation);

            if (m_Components == null)
                return;

            int xOffset = X - oldLocation.X;
            int yOffset = Y - oldLocation.Y;
            int zOffset = Z - oldLocation.Z;

            for (int i = 0; i < m_Components.Count; ++i)
            {
                Item item = m_Components[i];

                item.MoveToWorld(new Point3D(item.X + xOffset, item.Y + yOffset, item.Z + zOffset), Map);
            }
        }

        public override void OnMapChange()
        {
            base.OnMapChange();

            if (m_Components == null)
                return;

            for (int i = 0; i < m_Components.Count; ++i)
            {
                Item item = m_Components[i];

                item.Map = Map;
            }
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (m_Components == null)
                return;

            for (int i = 0; i < m_Components.Count; ++i)
            {
                Item item = m_Components[i];

                item.Delete();
            }
        }

        public override void OnAfterDelete()
        {
            if (m_Timer != null)
                m_Timer.Stop();

            m_Timer = null;

            base.OnAfterDelete();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_Components);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch ( version )
            {
                case 0:
                    {
                        m_Components = reader.ReadStrongItemList();

                        break;
                    }
            }

            Delete();
            //Timer.DelayCall(TimeSpan.Zero, new TimerCallback(Delete));
        }

        private class DecayTimer : Timer
        {
            private Item m_Item;
            public DecayTimer(Item item)
                : base(TimeSpan.FromSeconds(20.0))
            {
                m_Item = item;
            }

            protected override void OnTick()
            {
                m_Item.Delete();
            }
        }

        /*
        private class DecayTimer : Timer
        {
            private readonly Item m_Item;
            public DecayTimer(Item item)
                : base(TimeSpan.FromSeconds(20.0))
            {
                m_Item = item;
                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                m_Item.Delete();
            }
        }
         */
    }
}