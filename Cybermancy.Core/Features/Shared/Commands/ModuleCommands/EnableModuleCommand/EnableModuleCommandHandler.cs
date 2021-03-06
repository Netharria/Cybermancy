// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using Cybermancy.Core.Contracts.Persistance;
using Cybermancy.Core.DatabaseQueryHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cybermancy.Core.Features.Shared.Commands.ModuleCommands.EnableModuleCommand
{
    public class EnableModuleCommandHandler : IRequestHandler<EnableModuleCommand, EnableModuleCommandResponse>
    {
        private readonly ICybermancyDbContext _cybermancyDbContext;

        public EnableModuleCommandHandler(ICybermancyDbContext cybermancyDbContext)
        {
            this._cybermancyDbContext = cybermancyDbContext;
        }

        public async Task<EnableModuleCommandResponse> Handle(EnableModuleCommand request, CancellationToken cancellationToken)
        {
            var guildModule = await this._cybermancyDbContext.Guilds
                .WhereIdIs(request.GuildId)
                .GetModulesOfType(request.Module, cancellationToken)
                .Select(x => new
                {
                    Module = x,
                    x.Guild.ModChannelLog,
                })
                .FirstAsync(cancellationToken);
            guildModule.Module.ModuleEnabled = request.Enable;
            await this._cybermancyDbContext.SaveChangesAsync(cancellationToken);
            return new EnableModuleCommandResponse
            {
                ModerationLog = guildModule.ModChannelLog,
                Success = true
            };
        }
    }
}
