using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.CloseRain.Domain.Model
{
    public class Notification
    {
        public Notification(bool success, Dictionary<string,string> errors)
        {
            Success = success;
            Errors = errors;
        }

        public bool Success { get; set; }
        /// <summary>
        /// Objeto contendo propriedade e o erro
        /// </summary>
        public Dictionary<string,string> Errors { get; set; }

        public static implicit operator Notification(ValidationResult validator)
        {
            var erros = validator.Errors.Select(x => new KeyValuePair<string, string>(x.PropertyName, x.ErrorMessage)).ToDictionary(x => x.Key, v => v.Value);
            return new Notification(validator.IsValid, erros);
        }
    }
}
