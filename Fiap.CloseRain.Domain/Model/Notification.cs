using System.Linq;
using System.Collections.Generic;

namespace Fiap.CloseRain.Domain.Model
{
    public class Notification<T> where T : class
    {
        private Notification() { }

        public Notification(T data)
        {
            Errors = new Dictionary<string, string>();
            Valid = !HasErrors();
            Data = data;
        }

        public bool Valid
        {
            get => !HasErrors();
            set { }
        }

        public T Data { get; set; }
        public Dictionary<string, string> Errors { get; set; }
        public bool HasErrors() => Errors.Any();

        public void AddError(string property, string message)
        {
            this.Errors.Add(property, message);
        }

        public void AddError(Dictionary<string, string> erroDictionary)
        {
            foreach (var item in erroDictionary)
            {
                this.Errors.Add(item.Key, item.Value);
            }
        }
    }
}
