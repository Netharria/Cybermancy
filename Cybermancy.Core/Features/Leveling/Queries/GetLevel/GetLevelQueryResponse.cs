// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using Cybermancy.Core.Responses;

namespace Cybermancy.Core.Features.Leveling.Queries.GetLevel
{
    public class GetLevelQueryResponse : BaseResponse
    {
        public ulong UsersXp { get; init; }
        public uint UsersLevel { get; init; }
        public ulong LevelProgress { get; init; }
        public ulong XpForNextLevel { get; init; }
        public ulong? NextRoleRewardId { get; init; }
        public uint? NextRewardLevel { get; init; }
    }
}
