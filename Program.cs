using Newtonsoft.Json;
using System;

namespace Kimamo.Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain zamudaCoin = new Blockchain();
            zamudaCoin.AddBlock(new Block(DateTime.UtcNow, null, "{sender:Kibunja,receiver:Kimamo,amount:250}")); //Kibunja --> Kimamo
            zamudaCoin.AddBlock(new Block(DateTime.UtcNow, null, "{sender:Kimamo,receiver:Kibunja,amount:50}"));  // Kimamo --> Kibunja
            zamudaCoin.AddBlock(new Block(DateTime.UtcNow, null, "{sender:Kimamo,receiver:Kibunja,amount:150}"));  // Kibunja --> Kimamo

            Console.WriteLine(JsonConvert.SerializeObject(zamudaCoin, Formatting.Indented));

            Console.WriteLine($"Is Chain Valid: {zamudaCoin.IsValid()}");

            Console.WriteLine($"Update amount to 50000");
            zamudaCoin.Chain[1].Data = "{sender:Kibunja,receiver:Kimamo,amount:5000}";

            Console.WriteLine($"Is Chain Valid: {zamudaCoin.IsValid()}");

            Console.WriteLine($"Update hash");
            zamudaCoin.Chain[1].Hash = zamudaCoin.Chain[1].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {zamudaCoin.IsValid()}");

            Console.WriteLine($"Update the entire chain");
            zamudaCoin.Chain[2].PreviousHash = zamudaCoin.Chain[1].Hash;
            zamudaCoin.Chain[2].Hash = zamudaCoin.Chain[2].CalculateHash();
            zamudaCoin.Chain[3].PreviousHash = zamudaCoin.Chain[2].Hash;
            zamudaCoin.Chain[3].Hash = zamudaCoin.Chain[3].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {zamudaCoin.IsValid()}");

            Console.ReadKey();
        }
    }
}
