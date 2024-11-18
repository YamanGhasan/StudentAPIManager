using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PostApiDemo.Pages
{
    public class StudentApi : IDisposable
    {
        private readonly HttpClient _client;

        public StudentApi(string baseUrl)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }
        public async Task<HttpResponseMessage> AddStudentAsync(object postData)
        {
            var json = JsonSerializer.Serialize(postData, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine("Sending JSON: " + json);

            // Send the POST request to add student
            var response = await _client.PostAsync("addStudent", content);
            Console.WriteLine("Response Status Code: " + response.StatusCode);

            // Handle the response
            await HandleResponseAsync(response);

            return response;
        }




         private async Task HandleResponseAsync(HttpResponseMessage response)
        {
            var postResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Raw Response: " + postResponse);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success: " + postResponse);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}, Response: {postResponse}");
            }

            // Deserialize the response and check for the expected message
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                // Deserialize response into a dynamic object to capture the 'message'
                var postDataResponse = JsonSerializer.Deserialize<DynamicResponse>(postResponse, options);

                if (postDataResponse?.Message != null && postDataResponse.Message == "Student added successfully!")
                {
                    Console.WriteLine(postDataResponse.Message);
                }
                else
                {
                    Console.WriteLine("Message does not match expected value.");
                }
            }
            catch (JsonException ex)
            {
                 Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
                 Console.WriteLine($"Raw JSON that caused error: {postResponse}");
            }
        }


        public void Dispose()
        {
            _client.Dispose();
        }
    }

    public class DynamicResponse
    {
        public string Message { get; set; }
    }
}
