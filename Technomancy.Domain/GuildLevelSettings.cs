﻿namespace Technomancy.Domain
{
    public class GuildLevelSettings
    {
        public Guild Guild { get; set; }
        public int TextTime { get; set; }
        public int Base { get; set; }
        public int Modifier { get; set; }
        public int Amount { get; set; }
        public ulong? LevelChannelLog { get; set; }
    }
}