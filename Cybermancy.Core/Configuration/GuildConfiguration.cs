// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;
using Cybermancy.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cybermancy.Core.Configuration
{
    [ExcludeFromCodeCoverage]
    public class GuildConfiguration : IEntityTypeConfiguration<Guild>
    {
        public void Configure(EntityTypeBuilder<Guild> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .IsRequired();
            builder.Property(e => e.ModChannelLog).
                IsRequired(false);
            builder.HasOne(e => e.LogSettings)
                .WithOne(e => e.Guild)
                .HasForeignKey<GuildLogSettings>(e => e.GuildId)
                .IsRequired(false);
            builder.HasOne(e => e.LevelSettings)
                .WithOne(e => e.Guild)
                .HasForeignKey<GuildLevelSettings>(e => e.GuildId)
                .IsRequired(false);
            builder.HasOne(e => e.ModerationSettings)
                .WithOne(e => e.Guild)
                .HasForeignKey<GuildModerationSettings>(e => e.GuildId)
                .IsRequired(false);
        }
    }
}
