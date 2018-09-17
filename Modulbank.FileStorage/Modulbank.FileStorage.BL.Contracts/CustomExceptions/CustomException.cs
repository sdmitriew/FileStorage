using System;
using System.Collections.Generic;
using System.Text;

namespace Modulbank.FileStorage.BL.Contracts.CustomExceptions
{
    public abstract class CustomException : Exception
    {
        public abstract string ErrorCode { get; }
    }
}
