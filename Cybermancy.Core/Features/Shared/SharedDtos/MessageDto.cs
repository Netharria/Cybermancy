// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

namespace Cybermancy.Core.Features.Shared.SharedDtos
{
    public class MessageDto
    {
        public ulong UserId { get; init; }
        public ulong ChannelId { get; init; }
        public ulong MessageId { get; init; }
        public string MessageContent { get; init; } = string.Empty;
        public AttachmentDto[] Attachments { get; init; } = Array.Empty<AttachmentDto>();
    }
}
