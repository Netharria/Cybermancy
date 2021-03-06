// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using Cybermancy.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cybermancy.Core.Configuration
{
    public class NicknameHistoryConfiguration : IEntityTypeConfiguration<NicknameHistory>
    {
        public void Configure(EntityTypeBuilder<NicknameHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id)
                .HasColumnType("bigint")
                .UseIdentityAlwaysColumn();
            builder.HasOne(x => x.Member)
                .WithMany(x => x.NicknamesHistory)
                .HasForeignKey(x => new { x.UserId, x.GuildId })
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.Nickname)
                .HasMaxLength(32)
                .IsRequired();
            builder.Property(x => x.Timestamp)
                .HasDefaultValueSql("now()");
        }
    }
}
