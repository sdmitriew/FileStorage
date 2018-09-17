using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Modulbank.FileStorage.BL.Contracts.File.Helpers
{
    public interface IFileHelper
    {
        string ReplaceInvalidFileNameChars(string str);
        string ReplaceInvalidPathChars(string str);
        string ReplaceInvalidPathAndFileNameChars(string str);

        /// <summary>
        /// Замена символов на '_'
        /// </summary>
        /// <param name="str"></param>
        /// <param name="symbols"></param>
        /// <returns></returns>
        string ReplaceSymbols(string str, char[] symbols);

        string DetectMimeType(string fileName);

        string GetExtension(string fileName);

        bool CheckPermitExtension(string fileName);

        bool CheckFileSize(long size, int allowableSize);

        bool CheckFileExtension(string fileName, params string[] correctextensions);

        byte[] MakeArchiveInMemory(Dictionary<string, byte[]> files);

        byte[] GenerateZipFileContent(List<(string name, byte[] content)> files);
    }
}
