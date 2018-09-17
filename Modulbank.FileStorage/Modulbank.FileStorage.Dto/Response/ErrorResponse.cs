using System;
using System.Collections.Generic;
using System.Text;

namespace Modulbank.FileStorage.Dto.Response
{
    public class ErrorResponse : Response
    {
        public string Message { get; set; }
        public IEnumerable<Error> Errors { get; set; } = new Error[0];

        public class Error
        {
            public string Code { get; set; }
            public string Message { get; set; }
            public string FieldId { get; set; }
        }
    }
}
