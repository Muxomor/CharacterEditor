using MongoDB.Bson;

namespace WpfApp1
{
    public class Character
    {
        public ObjectId _id;
        public string Name { get; set; }
        public string ClassName { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Vitality { get; set; }
    }
}
