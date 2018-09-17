using System;
using System.Collections.Generic;
using System.Text;
using Modulbank.FileStorage.BL.Contracts.CustomExceptions;

namespace Modulbank.FileStorage.BL.Contracts.ErrorCodes
{
    public static class ExceptionCode
    {
        public static string FatalExceptionCode => "fatal";
        public static string NotFileCustomException => "file.notfound";
        
    }
}
