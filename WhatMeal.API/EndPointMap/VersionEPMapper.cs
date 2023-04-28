using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace WhatMeal.API;

internal class VersionEPMapper : IEPMapper
{
    private const string Tag = "Version";

    public WebApplication Map(WebApplication app)
    {
        app.MapGet("version", () =>
        {
            Log.Logger.Information("Requested version: {ver}", Version.CURRENT);
            return Results.Ok($"Version {Version.CURRENT}");
        }).WithTags(Tag).Produces<string>(StatusCodes.Status200OK);
        return app;
    }
}
