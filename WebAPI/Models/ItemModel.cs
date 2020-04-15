﻿namespace WebAPI.Models
{
    public class ItemModel
    {
        public long CharacterId { get; set; }

        public short ItemVNum { get; set; }

        public short VNum { get; set; }

        public ushort Amount { get; set; }

        public byte Rare { get; set; }

        public byte Upgrade { get; set; }

        public byte Design { get; set; }
    }
}
