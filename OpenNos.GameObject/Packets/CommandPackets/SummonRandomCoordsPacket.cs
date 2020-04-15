﻿////<auto-generated <- Codemaid exclusion for now (PacketIndex Order is important for maintenance)

using OpenNos.Core;
using OpenNos.Domain;

namespace OpenNos.GameObject.CommandPackets
{
    [PacketHeader("$MobRain", PassNonParseablePacket = true, Authorities = new AuthorityType[]{ AuthorityType.GA } )]
    public class MobRainPacket : PacketDefinition
    {
        #region Properties

        [PacketIndex(0)]
        public short NpcMonsterVNum { get; set; }

        [PacketIndex(1)]
        public short Amount { get; set; }

        [PacketIndex(2)]
        public bool IsMoving { get; set; }

        public static string ReturnHelp() => "$MobRain <VNum> <Amount> <IsMoving>";

        #endregion
    }
}