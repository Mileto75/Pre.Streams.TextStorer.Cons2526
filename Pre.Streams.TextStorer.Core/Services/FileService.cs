using Pre.Streams.TextStorer.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;


namespace Pre.Streams.TextStorer.Core.Services
{
    public class FileService : IFileService
    {
        private FileStream _fileStream;

        public string CreateFile(string fileName)
        {
            //build path to user Desktop or Documents folder
            //check if exists
            //If not: create
            //build path to file
            //check if exists
            // if not: create
            //return pathToFile
            throw new NotImplementedException();
        }

        public string DeCrypt(string toDecrypt)
        {
            //decrypt string using encryption library
            //create a datastore with private key
            var datastore = DataProtectionProvider.Create(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            //create dataprotector with purpose string
            var dataProtector = datastore.CreateProtector("Pre.Store.Secret");
            //tranform text into byte[]
            var byteArrayText = Encoding.UTF8.GetBytes(toDecrypt);
            return dataProtector.Unprotect(toDecrypt);
        }

        public string Encrypt(string toEncrypt)
        {
            //create a datastore with private key
            var datastore = DataProtectionProvider.Create(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            //create dataprotector with purpose string
            var dataProtector = datastore.CreateProtector("Pre.Store.Secret");
            return dataProtector.Protect(toEncrypt);
        }

        public bool WriteToFile(string text)
        {
            throw new NotImplementedException();
        }
    }
}
