﻿using System;

namespace OpenNos.Data
{
    [Serializable]
    public class QuestLogDTO
    {
        public long Id { get; set; }

        public long CharacterId { get; set; }

        public long QuestId { get; set; }

        public string IpAddress { get; set; }

        public DateTime? LastDaily { get; set; }
    }
}