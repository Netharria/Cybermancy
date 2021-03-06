// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using Cybermancy.Core.Contracts.Persistance;
using Cybermancy.Core.DatabaseQueryHelpers;
using Cybermancy.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cybermancy.Core.Features.Shared.Commands.MemberCommands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ICybermancyDbContext _cybermancyDbContext;

        public UpdateUserCommandHandler(ICybermancyDbContext cybermancyDbContext)
        {
            this._cybermancyDbContext = cybermancyDbContext;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userName = await this._cybermancyDbContext.UsernameHistory
                .WhereIdIs(request.UserId)
                .OrderByDescending(x => x.Timestamp)
                .Select(x => x.Username)
                .FirstAsync(cancellationToken: cancellationToken);
            if (userName.Equals(request.UserName, StringComparison.Ordinal))
                return Unit.Value;
            await this._cybermancyDbContext.UsernameHistory.AddAsync(new UsernameHistory
                {
                    UserId = request.UserId,
                    Username = request.UserName
                }, cancellationToken);

            await this._cybermancyDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
