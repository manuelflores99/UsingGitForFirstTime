﻿namespace PL.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }
        public object Data { get; set; }
    }
}
