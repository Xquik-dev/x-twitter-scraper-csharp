// SPDX-FileCopyrightText: 2026 Xquik contributors
//
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using XTwitterScraper.Core;
using XTwitterScraper.Exceptions;
using XTwitterScraper.Models;

namespace XTwitterScraper.Tests.Models;

public class FootballPollRankingTest
{
    const string Game =
        "\"id\":\"2055084502741811200\",\"seasonType\":\"RegularSeason\",\"week\":12,"
        + "\"startsAt\":null,\"status\":\"Scheduled\",\"clock\":null,\"quarter\":null,"
        + "\"home\":{\"teamId\":\"689566294702555136\",\"points\":null},"
        + "\"away\":{\"teamId\":\"689566294702555137\",\"points\":null},"
        + "\"teamIds\":[\"689566294702555136\",\"689566294702555137\"],\"periods\":[],\"odds\":null";

    static FootballScheduleGame Read(string fields)
    {
        var game = JsonSerializer.Deserialize<FootballScheduleGame>(
            "{" + Game + fields + "}",
            ModelBase.SerializerOptions
        );
        Assert.NotNull(game);
        game.Validate();
        return game;
    }

    [Fact]
    public void AGameReadsEachRankedTeamAndItsRank()
    {
        var game = Read(
            ",\"rankings\":[{\"teamId\":\"689566294702555136\",\"rank\":5},"
                + "{\"teamId\":null,\"rank\":null}]"
        );

        Assert.NotNull(game.Rankings);
        Assert.Equal(2, game.Rankings.Count);
        Assert.Equal("689566294702555136", game.Rankings[0].TeamID);
        Assert.Equal(5, game.Rankings[0].Rank);
        Assert.Null(game.Rankings[1].TeamID);
        Assert.Null(game.Rankings[1].Rank);
    }

    [Fact]
    public void AGameXRanksNeitherTeamInReadsEmpty()
    {
        var game = Read(",\"rankings\":[]");

        Assert.NotNull(game.Rankings);
        Assert.Empty(game.Rankings);
    }

    [Fact]
    public void AGameWithoutRankingsFailsValidation()
    {
        Assert.Throws<XTwitterScraperInvalidDataException>(() => Read(""));
    }

    [Fact]
    public void RankingsWriteTheirWireValues()
    {
        var game = Read(",\"rankings\":[]") with
        {
            Rankings = [new() { TeamID = "689566294702555136", Rank = 1 }],
        };

        var json = JsonSerializer.SerializeToElement(game, ModelBase.SerializerOptions);
        var ranking = Assert.Single(json.GetProperty("rankings").EnumerateArray());

        Assert.Equal("689566294702555136", ranking.GetProperty("teamId").GetString());
        Assert.Equal(1, ranking.GetProperty("rank").GetInt64());
    }
}
