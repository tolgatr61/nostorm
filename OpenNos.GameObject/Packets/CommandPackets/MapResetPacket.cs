﻿////<auto-generated <- Codemaid exclusion for now (PacketIndex Order is important for maintenance)

using OpenNos.Core;
using OpenNos.Domain;

namespace OpenNos.GameObject.CommandPackets
{
    [PacketHeader("$ResetMap" , PassNonParseablePacket = true, Authorities = new AuthorityType[]{ AuthorityType.GM } )]
    public class MapResetPacket : PacketDefinition
    {
        #region Properties

        public static string ReturnHelp() => "$ResetMap";

        #endregion
    }
}