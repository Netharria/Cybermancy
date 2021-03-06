// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using Cybermancy.Core.Contracts.Persistance;
using Cybermancy.Core.Extensions;
using Cybermancy.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cybermancy.Core.Features.Logging.Queries.GetTrackerWithOldMessage
{
    public class GetTrackerWithOldMessageQueryHandler : IRequestHandler<GetTrackerWithOldMessageQuery, GetTrackerWithOldMessageQueryResponse?>
    {
        private readonly ICybermancyDbContext _cybermancyDbContext;

        public GetTrackerWithOldMessageQueryHandler(ICybermancyDbContext cybermancyDbContext)
        {
            this._cybermancyDbContext = cybermancyDbContext;
        }

        public Task<GetTrackerWithOldMessageQueryResponse?> Handle(GetTrackerWithOldMessageQuery request, CancellationToken cancellationToken)
            => _cybermancyDbContext.Trackers
            .WhereMemberIs(request.UserId, request.GuildId)
            .Select(x => new GetTrackerWithOldMessageQueryResponse
            {
                Success = true,
                TrackerChannelId = x.LogChannelId,
                OldMessageContent = x.Member.Messages
                    .Where(x => x.Id == request.MessageId)
                    .Select(x => x.MessageHistory
                        .Where(x => x.Action != MessageAction.Deleted
                            && x.TimeStamp < DateTime.UtcNow.AddSeconds(1))
                        .OrderByDescending(x => x.TimeStamp)
                        .First().MessageContent)
                    .First()
            }).FirstOrDefaultAsync(cancellationToken);
    }
}
