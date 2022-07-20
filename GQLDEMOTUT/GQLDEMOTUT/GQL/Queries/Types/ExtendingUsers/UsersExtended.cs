
using GQLDEMOTUT.GQL.DataLoaders;

namespace GQLDEMOTUT.Entities;

public partial class GQLUser
{
    public async Task<WeatherForecast>? WeatherForecast([Service] UserWeatherForeCastDataLoader weatherDataLoader)
    {
        var x = await weatherDataLoader.LoadAsync(Id, new CancellationToken());
        return x;
    }
}
