// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using Cybermancy.Core.Contracts.Persistance;
using Cybermancy.Core.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cybermancy.Core.Features.Logging.Queries.GetTracker
{
    public class GetTrackerQueryHandler : IRequestHandler<GetTrackerQuery, GetTrackerQueryResponse?>
    {
        private readonly ICybermancyDbContext _cybermancyDbContext;

        public GetTrackerQueryHandler(ICybermancyDbContext cybermancyDbContext)
        {
            this._cybermancyDbContext = cybermancyDbContext;
        }

        public Task<GetTrackerQueryResponse?> Handle(GetTrackerQuery request, CancellationToken cancellationToken)
            => _cybermancyDbContext.Trackers
            .WhereMemberIs(request.UserId, request.GuildId)
            .Select(x => new GetTrackerQueryResponse
            {
                Success = true,
                TrackerChannelId = x.LogChannelId
            }).FirstOrDefaultAsync(cancellationToken);

    }
}
