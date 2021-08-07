using Newtonsoft.Json;
using System;

namespace BlockChainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is basic Sample of displaying Block
            Blockchain objBlockChain = new();
            objBlockChain.AddBlock(new Block(DateTime.Now, null, "{sender:Chandradev,receiver:Kevin,amount:10}"));
            objBlockChain.AddBlock(new Block(DateTime.Now, null, "{sender:Kevin,receiver:Chandradev,amount:5}"));
            objBlockChain.AddBlock(new Block(DateTime.Now, null, "{sender:Kevin,receiver:Chandradev,amount:5}"));

            Console.WriteLine(JsonConvert.SerializeObject(objBlockChain, Formatting.Indented));

            //This is used for Validation
            Console.WriteLine($"Is Chain Valid: {objBlockChain.IsValid()}");

            //Updating block of data
            Console.WriteLine($"Update amount to 1000");
            objBlockChain.Chain[1].Data = "{sender:Chandradev,receiver:Kevin,amount:1000}";

            Console.WriteLine($"Is Chain Valid: {objBlockChain.IsValid()}");

            //Updating Hash value
            Console.WriteLine($"Update hash");
            objBlockChain.Chain[1].Hash = objBlockChain.Chain[1].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {objBlockChain.IsValid()}");

            //Updating entire chain
            Console.WriteLine($"Update the entire chain");
            objBlockChain.Chain[2].PreviousHash = objBlockChain.Chain[1].Hash;
            objBlockChain.Chain[2].Hash = objBlockChain.Chain[2].CalculateHash();
            objBlockChain.Chain[3].PreviousHash = objBlockChain.Chain[2].Hash;
            objBlockChain.Chain[3].Hash = objBlockChain.Chain[3].CalculateHash();

            Console.WriteLine($"Is Chain Valid: {objBlockChain.IsValid()}");
            Console.ReadKey();
        }

    }
}
