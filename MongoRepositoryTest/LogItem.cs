using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoRepositoryTest
{
    public class LogItem : MongoRepository.Entity
    {
        public LogItem()
        {
            this.IP = "";
            this.HostName = "";
        }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local, Representation = BsonType.DateTime)]
        public DateTime DateTime { get; set; }

        public LogLevel LogLevel { get; set; }
        public string IP { get; private set; }
        public string HostName { get; private set; }
        public string Message { get; set; }
        public object Args { get; set; }
        public string Exception { get; set; }
    }
}
