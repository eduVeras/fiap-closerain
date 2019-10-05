using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Models
{
    public class ResultError
    {
        public bool Succes { get; set; }
        public string Message { get; set; }

        public ResultError()
        {
            
        }

        public ResultError( string message)
        {
            Succes = false;
            Message = message;
        }   
    }
}
