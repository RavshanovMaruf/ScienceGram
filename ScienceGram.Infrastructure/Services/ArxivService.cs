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
        public async Task<ArxivFeed> GetArxiv(string searchQuery, string idList, int? start, int? maxResults)
        {
            try
            {
                using (HttpClient client = _clientFactory.CreateClient())
                {
                    // Make the HTTP request
                    UriBuilder uriBuilder = new UriBuilder("http://export.arxiv.org/api/query");
                    
                    if (searchQuery is null && idList is null && start is null && maxResults is null)
                    {
                        uriBuilder.Query = string.Empty;
                    }
                    uriBuilder.Query = "searchQuery="+ searchQuery;
                    
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
