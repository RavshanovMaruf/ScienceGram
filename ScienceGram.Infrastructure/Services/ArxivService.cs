using ScienceGram.Application.Common.Interfaces;
using ScienceGram.Application.Common.Models.Arxiv;
using System.Xml.Serialization;

namespace ScienceGram.Infrastructure.Services
{
    public class ArxivService : IArxivService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ArxivService(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }
        public async Task<ArxivFeed> GetArxiv(string searchQuery, int? start, int? maxResults)
        {
            try
            {
                using (HttpClient client = _clientFactory.CreateClient())
                {
                    UriBuilder uriBuilder = new UriBuilder("http://export.arxiv.org/api/query");
                    
                    if (searchQuery != null)
                    {
                        uriBuilder.Query = $"search_query=all:{searchQuery}";
                    }
                    if (start.HasValue)
                    {
                        uriBuilder.Query += $"&start={start}";
                    }
                    if (start.HasValue)
                    {
                        uriBuilder.Query += $"&max_results={maxResults}";
                    }

                    HttpResponseMessage response = await client.GetAsync(uriBuilder.Uri);

                    XmlSerializer serializer = new XmlSerializer(typeof(ArxivFeed));

                    using (StringReader reader = new StringReader(await response.Content.ReadAsStringAsync()))
                    {
                        try
                        {
                            return (ArxivFeed)serializer.Deserialize(reader);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error deserializing XML: {ex.Message}");
                            return default(ArxivFeed);
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request error: {ex.Message}");
                return null;
            }
        }
    }
}
