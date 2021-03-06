// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using Cybermancy.Core.Contracts.Persistance;
using Cybermancy.Domain;
using MediatR;

namespace Cybermancy.Core.Features.Shared.Commands.RoleCommands.AddRole
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand>
    {
        private readonly ICybermancyDbContext _cybermancyDbContext;

        public AddRoleCommandHandler(ICybermancyDbContext cybermancyDbContext)
        {
            this._cybermancyDbContext = cybermancyDbContext;
        }

        public async Task<Unit> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            await this._cybermancyDbContext.Roles.AddAsync(new Role
                {
                    Id = request.RoleId,
                    GuildId = request.GuildId
                }, cancellationToken);
            await this._cybermancyDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
