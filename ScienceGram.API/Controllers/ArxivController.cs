using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ScienceGram.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArxivController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ArxivController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet(Name = "GetArxivApi")]
        public async Task<IActionResult> Index()
        {
            string apiUrl = $"https://export.arxiv.org/api/query?search_query=all:electron";

            // Make the HTTP request
            string result = await GetArxivDataFromApi(apiUrl);

            // You might want to process the result further or pass it to a view
            return Content(result, "application/json");
        }

        private async Task<string> GetArxivDataFromApi(string apiUrl)
        {
            try
            {
                using (HttpClient client = _clientFactory.CreateClient())
                {
                    // Make the HTTP request
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Check if the request was successful (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and return the response content as a string
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        // If the request was not successful, log an error
                        Console.WriteLine($"Error: {response.StatusCode}");
                        return null;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                // Log the HTTP request error
                Console.WriteLine($"HTTP request error: {ex.Message}");
                return null;
            }
        }
    }
}
