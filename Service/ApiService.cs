using NativeStats.DTO;
using System.Net.Http.Json;
using System.Text.Json;

namespace NativeStats.Service
{
    public class ApiService
    {
        private readonly bool _isRecent;
        private readonly IHttpClientFactory _httpClientFactory;
        private const string BaseUrl = "https://api.football-data.org/";
        private const string ApiToken = "9fb0a9e1e96149ddafce7a1d191eafe6";

        public ApiService(bool isRecent, IHttpClientFactory httpClientFactory)
        {
            _isRecent = isRecent;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<MatchesByAreaDTO>> CallFootballServiceAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Add("X-Auth-Token", ApiToken);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                int[] competitions = { 2017, 2084, 2003, 2012, 2019, 2179, 2013 };
                DateTime date = DateTime.UtcNow;
                DateTime dateFrom = _isRecent ? date.AddDays(-6) : date;
                DateTime dateTo = _isRecent ? date : date.AddDays(6);

                string endpoint = $"/v4/matches/?competitions={string.Join(',', competitions)}&dateFrom={dateFrom:yyyy-MM-dd}&dateTo={dateTo:yyyy-MM-dd}";
                var response = await client.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    // Log ou retorno informando o erro
                    Console.Error.WriteLine($"API Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return Enumerable.Empty<MatchesByAreaDTO>();
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var data = await response.Content.ReadFromJsonAsync<FootbalDataDTO>(options);

                if (data == null || data.Matches == null || data.Matches.Count == 0)
                {
                    // Log ou aviso de dados nulos
                    Console.Error.WriteLine("API returned no data or invalid response.");
                    return Enumerable.Empty<MatchesByAreaDTO>();
                }

                return data.Matches
                    .GroupBy(match => match.Competition.Id)
                    .Select(group => new MatchesByAreaDTO
                    {
                        Competition = group.First().Competition,
                        Matches = group.Where(x => _isRecent ? x.Status == "FINISHED" : x.Status != "FINISHED").ToList()
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log do erro
                Console.Error.WriteLine($"An error occurred while calling the API: {ex.Message}");
                return Enumerable.Empty<MatchesByAreaDTO>();
            }
        }
    }
}
