using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MarvelEncyclopedia.Models
{
    public class CharacterDto
    {

        [BsonId]
        public int Id { get; set; }

        
        [BsonElement("name")]
        public string Name { get; set; }

    }
}
