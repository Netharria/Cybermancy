﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cybermancy.Domain;

namespace Cybermancy.Persistance.Configuration
{
    public class PublishedMessageConfiguration : IEntityTypeConfiguration<PublishedMessage>
    {
        public void Configure(EntityTypeBuilder<PublishedMessage> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => new { e.Sin, e.PublishType })
                .IsUnique(true);
            builder.HasOne(e => e.Sin).WithMany(e => e.PublishMessages);
        }
    }
}