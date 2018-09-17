using System;
using System.Collections.Generic;
using System.Text;

namespace Modulbank.FileStorage.Dto.Response
{
    public class Response<T> : Response where T : class
    {
        public T Data { get; set; }
    }
}
