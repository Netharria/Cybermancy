// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using Cybermancy.Domain.Shared;

namespace Cybermancy.Domain
{
    public enum SinType
    {
        Warn,
        Mute,
        Ban,
    }

    public class Sin : IIdentifiable, IMember
    {
        public ulong Id { get; set; }

        public ulong UserId { get; set; }

        public virtual Member Member { get; set; } = null!;

        public ulong ModeratorId { get; set; }

        public virtual Member Moderator { get; set; } = null!;

        public ulong GuildId { get; set; }

        public virtual Guild Guild { get; set; } = null!;

        public string Reason { get; set; } = string.Empty;

        public DateTime InfractionOn { get; }

        public SinType SinType { get; set; }

        public virtual Mute? Mute { get; set; }

        public virtual Pardon? Pardon { get; set; }

        public virtual ICollection<PublishedMessage> PublishMessages { get; set; } = new List<PublishedMessage>();
    }
}
