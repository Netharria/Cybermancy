// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using Cybermancy.Domain.Shared;

namespace Cybermancy.Core.Extensions
{
    public static class IMemberExtensions
    {
        public static IQueryable<TSource> WhereMemberIs<TSource>(this IQueryable<TSource> memberObjects, ulong userId, ulong guildId) where TSource : IMember
            => memberObjects.Where(x => x.UserId == userId && x.GuildId == guildId);
    }
}
