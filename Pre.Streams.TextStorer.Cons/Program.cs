using Pre.Streams.TextStorer.Core.Services;

namespace Pre.Streams.TextStorer.Cons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declare FileService instance
            FileService fileService = new FileService();

            Console.WriteLine("Give me your secret...");
            string input = Console.ReadLine(); 
            var secret = fileService.Encrypt(input);
            Console.WriteLine("Give me a filename:");
            string fileName = Console.ReadLine();
            Console.WriteLine("Creating file...");
            string pathToFile = fileService.CreateFile(fileName);
            Console.WriteLine("Writing secret to file...");
            if(fileService.WriteToFile(secret,pathToFile))
            {
                Console.WriteLine("Secret stored!");
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }
            Console.WriteLine("Decrypt the secret");
            secret = fileService.ReadFromFile(pathToFile);
            Console.WriteLine("Your terrible secret is:");
            Console.WriteLine(fileService.DeCrypt(secret));
        }
    }
}
