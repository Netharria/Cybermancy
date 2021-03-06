// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cybermancy.Core.Features.Logging.Queries.GetLogSettings
{
    public class GetLoggingSettingsQueryHandler : IRequestHandler<GetLoggingSettingsQuery, GetLoggingSettingsQueryResponse>
    {
        private readonly CybermancyDbContext _cybermancyDbContext;

        public GetLoggingSettingsQueryHandler(CybermancyDbContext cybermancyDbContext)
        {
            this._cybermancyDbContext = cybermancyDbContext;
        }

        public Task<GetLoggingSettingsQueryResponse> Handle(GetLoggingSettingsQuery request, CancellationToken cancellationToken)
        {
            return this._cybermancyDbContext.GuildLogSettings
                .Where(x => x.GuildId == request.GuildId)
                .Select(x => new GetLoggingSettingsQueryResponse
                {
                    JoinChannelLog = x.JoinChannelLogId,
                    LeaveChannelLog = x.LeaveChannelLogId,
                    DeleteChannelLog = x.DeleteChannelLogId,
                    BulkDeleteChannelLog = x.BulkDeleteChannelLogId,
                    EditChannelLog = x.EditChannelLogId,
                    UsernameChannelLog = x.UsernameChannelLogId,
                    NicknameChannelLog = x.NicknameChannelLogId,
                    AvatarChannelLog = x.AvatarChannelLogId,
                    IsLoggingEnabled = x.ModuleEnabled,
                    Success = true
                }).FirstAsync(cancellationToken: cancellationToken);
        }
    }
}
