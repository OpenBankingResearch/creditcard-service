using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CreditCardAPI.Model
{
    public class CreditCard
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

        public string gender { get; set; }

        public long creditcardnumber { get; set; }

        public string creditcardtype { get; set; }

        public string dateofbirth { get; set; }

        public string opendate { get; set; }

        public string exipydate { get; set; }

        public int maxlimit { get; set; }

        public int currentavailablebalance { get; set; }

        public string street { get; set; }

        public string postcode { get; set; }

        public string city { get; set; }

        public string country { get; set; }

        public string billdate { get; set; }
    }
}
