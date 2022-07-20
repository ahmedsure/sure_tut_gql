using GQLDEMOTUT.GQL.DataLoaders;

namespace GQLDEMOTUT.GQL.Queries.NodesExtentions
{
    [Node]
    [ExtendObjectType]
    public class UserNodeExt
    {
        public UserNodeExt()
        {

        }

        [NodeResolver]
        public static async Task<WeatherForecast> GetUserWeatherByIdAsync(
              Guid id,
             UserWeatherForeCastDataLoader waetherbyID)
             => await waetherbyID.LoadAsync(id);
    }
}
