using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaPractica.Shared
{
    public class ResponseApi<T>
    {
        public bool Success { get; set; }

        public T? Value { get; set; } 

        public String? Message {  get; set; }
    }
}
