using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Notify
    {
        public string Code { get; set; }

        public string Property { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return $"Notify - Code: {Code}, Property: {Property}, Message: {Message}";
        }
    }
}
