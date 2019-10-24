using System;

namespace Fiap.CloseRain.Models
{
    public class ResultError
    {
        public ResultError() { }

        public ResultError( string message)
        {
            Success = false;
            Message = message;
        }

        public ResultError(Exception e)
        {
            Success = false;
            Message = e.Message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
