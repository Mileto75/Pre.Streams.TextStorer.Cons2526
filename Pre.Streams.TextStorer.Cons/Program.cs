using Pre.Streams.TextStorer.Core.Services;

namespace Pre.Streams.TextStorer.Cons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My secret...");
            FileService fileService = new FileService();
            var secret = fileService.Encrypt("I love the macarena!");
            Console.WriteLine("Encrypted");
            Console.WriteLine(secret);
            Console.WriteLine("Decrypted:");
            Console.WriteLine(fileService.DeCrypt(secret));
        }
    }
}
