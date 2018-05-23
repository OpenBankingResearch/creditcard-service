using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CreditCardAPI.Model
{
    [Serializable]
    [BsonIgnoreExtraElements]
    public class CreditCard
    {
        //[BsonId]
        //public ObjectId _id { get; set; }

        public string customerId { get; set; }

        public long creditCardNumber { get; set; }

        public string creditCardType { get; set; }

        public string issueDate { get; set; }

        public string expiryDate { get; set; }

        public int maxLimit { get; set; }

        public int cvv { get; set; }
        
    }
}
