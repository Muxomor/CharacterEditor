using MongoDB.Driver;
using System;

namespace WpfApp1
{
    public class CRUD
    {
        public static void CreateCharacter(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Shamaev322");
            var collection = database.GetCollection<Character>("Characters");
            collection.InsertOne(character);
        }

        public static void GetCharacter(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Shamaev322");
            var collection = database.GetCollection<Character>("Characters");
            var user = collection.Find(x => x.Name == name).FirstOrDefault();

            if (user != null)
                Console.WriteLine($"{user.Name} {user.ClassName}");
            else
                Console.WriteLine("Not found");
        }

    }
}
