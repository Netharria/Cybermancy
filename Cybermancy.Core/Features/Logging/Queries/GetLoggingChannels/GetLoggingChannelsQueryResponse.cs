// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using Cybermancy.Core.Responses;

namespace Cybermancy.Core.Features.Logging.Queries.GetLoggingChannels
{
    public class GetLoggingChannelsQueryResponse : BaseResponse
    {
        public ulong? JoinChannelLogId { get; set; }

        public ulong? LeaveChannelLogId { get; set; }

        public ulong? DeleteChannelLogId { get; set; }

        public ulong? BulkDeleteChannelLogId { get; set; }

        public ulong? EditChannelLogId { get; set; }

        public ulong? UsernameChannelLogId { get; set; }

        public ulong? NicknameChannelLogId { get; set; }

        public ulong? AvatarChannelLogId { get; set; }
    }
}
