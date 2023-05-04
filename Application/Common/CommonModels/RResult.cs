using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.CommonModels
{
    public class RResult
    { 
        public bool succeeded { get; set; }
        public object data { get; set; }
        public int statusCode { get; set; }
        public int result { get; set; }
        public long LongID { get; set; }
        public string message { get; set; }
        public object objectID { get; set; }
        public object objectCode { get; set; }
        public string[] Errors { get; set; }

 
    }
}
