﻿using System.Collections.Generic;
using Cybermancy.Domain.Shared;

namespace Cybermancy.Domain
{
    public class Guild : Identifiable
    {
        public ulong? ModChannelLog { get; set; }
        public virtual ICollection<Channel> Channels { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<OldLogMessage> OldLogMessages { get; set; }
        public virtual ICollection<Tracker> Trackers { get; set; }
        public virtual ICollection<Reward> Rewards { get; set; }
        public virtual ICollection<UserLevel> UserLevels { get; set; }
        public virtual ICollection<Sin> Sins { get; set; }
        public virtual ICollection<Mute> ActiveMutes { get; set; }
        public virtual ICollection<Lock> LockedChannels { get; set; }
        public virtual GuildLogSettings LogSettings { get; set; }
        public virtual GuildLevelSettings LevelSettings { get; set; }
        public virtual GuildModerationSettings ModerationSettings { get; set; }
    }
}