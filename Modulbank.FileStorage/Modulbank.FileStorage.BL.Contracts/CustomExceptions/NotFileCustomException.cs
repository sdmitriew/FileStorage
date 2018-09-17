using System;
using System.Collections.Generic;
using System.Text;
using Modulbank.FileStorage.BL.Contracts.ErrorCodes;

namespace Modulbank.FileStorage.BL.Contracts.CustomExceptions
{
    public class NotFileCustomException : CustomException
    {
        public override string Message => "Неизвестный идентификатор файла";
        public override string ErrorCode => ExceptionCode.NotFileCustomException;
    }
}
