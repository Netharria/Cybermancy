// This file is part of the Cybermancy Project.
//
// Copyright (c) Netharia 2021-Present.
//
// All rights reserved.
// Licensed under the AGPL-3.0 license. See LICENSE file in the project root for full license information.

using System.Linq;
using System.Threading.Tasks;
using Cybermancy.Core.DatabaseQueryHelpers;
using Cybermancy.Core.Enums;
using Cybermancy.Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Cybermancy.Core.Test.Unit.DatabaseQueryHelpers
{
    [TestFixture]
    public class IModuleDatabaseQueryHelperTests
    {
        [Test]
        public async Task WhenGetModulesOfTypeCalled_ReturnCorrectTypeofModuleAsync()
        {
            var context = await TestCybermancyDbContextFactory.CreateAsync();

            var levelingModule = await context.Guilds.GetModulesOfType(Module.Leveling)
                .OfType<GuildLevelSettings>()
                .ToListAsync();
            levelingModule.Should().NotBeEmpty();

            var loggingModule = await context.Guilds.GetModulesOfType(Module.Logging)
                .OfType<GuildLogSettings>()
                .ToListAsync();
            loggingModule.Should().NotBeEmpty();

            var moderationModule = await context.Guilds.GetModulesOfType(Module.Moderation)
                .OfType<GuildModerationSettings>()
                .ToListAsync();
            moderationModule.Should().NotBeEmpty();
        }
    }
}
