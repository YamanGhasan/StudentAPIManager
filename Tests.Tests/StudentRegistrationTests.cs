using System;
using System.Net;
using System.Threading.Tasks;
using PostApiDemo.Helpers;
using PostApiDemo.Pages;
using Xunit;

namespace PostApiDemo.Tests
{
    public class StudentRegistrationTests : IClassFixture<TestSetup>
    {
        private readonly TestSetup _testSetup;

        public StudentRegistrationTests(TestSetup testSetup)
        {
            _testSetup = testSetup;   
        }
        [Fact]
        public async Task AddOneStudent_ShouldReturnSuccess()
        {
            var response = await _testSetup.StudentApi.AddStudentAsync(_testSetup.PostData);

            Console.WriteLine($"Response Status Code: {response.StatusCode}");
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Content: {responseContent}");

            // Check if the response is a 200 OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Check for the success message
            Assert.Contains("Student added successfully!", responseContent);

            // In case of failure, print additional details
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode} - {responseContent}");
            }
        }





    }
}
