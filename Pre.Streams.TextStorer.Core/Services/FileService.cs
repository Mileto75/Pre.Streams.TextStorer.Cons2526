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
            string pathToDesktop = Environment
                .GetFolderPath(Environment.SpecialFolder.Desktop);
            
            string pathToSecretDirectory =
                Path.Combine(pathToDesktop,"Pre","Secret");
            //check if exists
            try
            {
                if (!Directory.Exists(pathToSecretDirectory))
                {
                    //If not: create
                    Directory.CreateDirectory(pathToSecretDirectory);
                }
            }catch(IOException iOexception)
            {
                Console.WriteLine(iOexception.Message);
            }

            //build path to file
            string pathToFile = Path.Combine(pathToSecretDirectory, fileName);
            try
            {
                //check if exists
                if(!File.Exists(pathToFile))
                {
                    // if not: create
                    File.Create(pathToFile);
                }
            }
            catch (IOException iOexception)
            {
                Console.WriteLine(iOexception.Message);
            }
            //return pathToFile
            return pathToFile;
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

        public bool WriteToFile(string text,string pathToFile)
        {
            //create a streamWriter
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(pathToFile))
                {
                    //write to file
                    streamWriter.Write(text);
                }
                return true;
            }
            catch(IOException iOexception)
            {
                Console.WriteLine(iOexception.Message);
                return false;
            }
        }
    }
}
