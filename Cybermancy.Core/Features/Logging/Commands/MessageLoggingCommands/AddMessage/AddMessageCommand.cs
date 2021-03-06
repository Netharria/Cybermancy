// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using Cybermancy.Core.Features.Shared.SharedDtos;
using MediatR;

namespace Cybermancy.Core.Features.Logging.Commands.MessageLoggingCommands.AddMessage
{
    public class AddMessageCommand : IRequest
    {
        public ulong MessageId { get; init; }
        public ulong ChannelId { get; init; }
        public string MessageContent { get; init; } = string.Empty;
        public ulong UserId { get; init; }
        public AttachmentDto[] Attachments { get; init; } = Array.Empty<AttachmentDto>();
        public ulong? ReferencedMessageId { get; init; }
        public ulong GuildId { get; init; }
    }
}
