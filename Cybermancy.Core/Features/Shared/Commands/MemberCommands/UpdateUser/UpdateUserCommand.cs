// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using MediatR;

namespace Cybermancy.Core.Features.Shared.Commands.MemberCommands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public ulong UserId { get; init; }
        public string UserName { get; init; } = string.Empty;
    }
}
