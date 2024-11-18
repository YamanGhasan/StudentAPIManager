namespace PostApiDemo
{
    public class PostDataResponse
    {
        // Property to hold the message
        public string Message { get; set; }

        // Parameterless constructor for JSON deserialization
        public PostDataResponse() { }

        // Constructor to initialize the message
        public PostDataResponse(string message)
        {
            Message = message;
        }
    }
}