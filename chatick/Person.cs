using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace chatick
{
    class Person
    {
            [BsonId]
            public ObjectId _id { get; set; }
            public string nickname { get; set; }
            public string firstName { get; set; }
            public string secondName { get; set; }
            public int age { get; set; }
    }
}
