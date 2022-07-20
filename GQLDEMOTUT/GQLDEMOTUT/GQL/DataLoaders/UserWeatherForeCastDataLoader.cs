using GQLDEMOTUT.Services;

namespace GQLDEMOTUT.GQL.DataLoaders
{
    public class UserWeatherForeCastDataLoader : BatchDataLoader<Guid, WeatherForecast>
    {
        private readonly NationalityAndForicastIntegrationServices _weatherServ;
        public UserWeatherForeCastDataLoader(
            NationalityAndForicastIntegrationServices weatherServ,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options)
            : base(batchScheduler, options)
        {
            _weatherServ = weatherServ ??
                throw new ArgumentNullException(nameof(_weatherServ));
        }

        protected override async Task<IReadOnlyDictionary<Guid, WeatherForecast>> LoadBatchAsync(
            IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            var weather = await _weatherServ.UsersWeatherForecasts(keys.ToList());
            return  weather.ToDictionary(w => w.ForUser.Value );
        }
    }
}
