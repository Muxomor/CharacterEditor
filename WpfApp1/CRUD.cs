using MongoDB.Driver;
using System;

namespace WpfApp1
{
    public class CRUD
    {
        public static void CreateCharacter(ICharacter character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Shamaev322");
            var collection = database.GetCollection<ICharacter>("Characters");
            collection.InsertOne(character);
        }

        public static ICharacter GetCharacter(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Shamaev322");
            var collection = database.GetCollection<ICharacter>("Characters");
            var character = collection.Find(x => x.Name == name).FirstOrDefault();

            return character;
        }

    }
}
