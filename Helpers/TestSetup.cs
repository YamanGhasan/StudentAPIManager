using PostApiDemo.Pages;
using PostApiDemo;  
using System;

namespace PostApiDemo.Helpers
{
    public class TestSetup : IDisposable
    {
        public StudentApi StudentApi { get; private set; }
        public PostData PostData { get; private set; } // Change to use PostData class

        public TestSetup()
        {
            // Initialize the Page Object with the API's base URL
            StudentApi = new StudentApi("http://127.0.0.1:3000/");

            // Test input data for student registration using the PostData class
            PostData = new PostData
            (
                name: "Lily",
                email: "Lily@example.com",
                addedAt: DateTime.UtcNow,  // Keep as DateTime
                courseName: "Test Course"
            );
        }

        public void Dispose()
        {
            StudentApi?.Dispose();
        }
    }
}