﻿namespace api_doc_memory.domain.Results
{
    public class ResultRepository<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public ResultRepository(bool success, string message, T? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public ResultRepository()
        {
        }
    }
}