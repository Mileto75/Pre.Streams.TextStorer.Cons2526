using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;


namespace Pre.Streams.TextStorer.Core.Services.Interfaces
{
    public interface IFileService
    {
        string Encrypt(string toEncrypt);
        string DeCrypt(string toDecrypt);
        Task<bool> WriteToFile(string text,string pathToFile);
        string CreateFile(string fileName);
        Task<string> ReadFromFile(string pathToFile);
    }
}
