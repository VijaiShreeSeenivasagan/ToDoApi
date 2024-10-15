using System;
using System.Text.Json.Serialization;
using TodoApi.Data.Models;

namespace TodoApi.Exceptions
{
    [Serializable]
    public class PublisherNameException : Exception
    {
        public string PublisherName { get; set; }
        public PublisherNameException() { }

        public PublisherNameException(string message) : base(message) { }

        public PublisherNameException(string message, Exception innerException) : base(message, innerException) { }

        public PublisherNameException(string message, string publisherName) : this(message){
            PublisherName = publisherName;
        }
    }
}