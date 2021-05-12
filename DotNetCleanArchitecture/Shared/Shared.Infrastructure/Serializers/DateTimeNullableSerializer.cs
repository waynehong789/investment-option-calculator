using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;

namespace Shared.Infrastructure.Serializers
{
    public class DateTimeNullableSerializer : IBsonSerializer
    {
        public Type ValueType { get; }
        private DateTimeSerializer dateTimeSerializer;

        public DateTimeNullableSerializer()
        {
            ValueType = typeof(DateTime?);
            dateTimeSerializer = new DateTimeSerializer(DateTimeKind.Utc, BsonType.DateTime);
        }

        public DateTimeNullableSerializer(BsonType representation)
        {
            ValueType = typeof(DateTime?);
            dateTimeSerializer = new DateTimeSerializer(DateTimeKind.Utc, representation);
        }

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            if (context.Reader.CurrentBsonType == BsonType.Null)
            {
                context.Reader.ReadNull();
                return null;
            }

            return dateTimeSerializer.Deserialize(context, args);
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            if (value is null)
            {
                context.Writer.WriteNull();
            }
            else
            {
                dateTimeSerializer.Serialize(context, args, (DateTime)value);
            }
        }
    }
}

