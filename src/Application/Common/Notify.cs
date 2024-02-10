using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Notify
    {
        public string Code { get; set; } = string.Empty;

        public string Property { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Notify - Code: {Code}, Property: {Property}, Message: {Message}";
        }
    }
}
