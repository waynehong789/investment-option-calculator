using System.Collections.Generic;

namespace DotNetCleanArchitecture.API.Models
{
    public class Response
    {
        public bool Success {get; set;}
        public int StatusCode {get; set;}
        public string Message {get; set;}
        public List<string> Errors {get; set;}
    }

    public class Response<T>: Response
    {
        public T Payload {get; set;}
    }
    
}