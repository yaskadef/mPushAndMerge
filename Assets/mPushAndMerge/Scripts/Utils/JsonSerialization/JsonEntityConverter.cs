using Assets.mPushAndMerge.Scripts.Game.Data.Entities;
using Assets.mPushAndMerge.Scripts.Game.Data.Entities.Mergeable.Buildings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Assets.mPushAndMerge.Scripts.Utils.JsonSerialization
{
    public class JsonEntityConverter : JsonConverter<EntityData>
    {
        private static readonly JsonSerializer _jsonSerializer = new()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public override EntityData ReadJson(JsonReader reader, Type objectType, EntityData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var type = jsonObject["EntityType"].ToObject<EntityType>();

            return type switch
            {
                EntityType.Building => jsonObject.ToObject<BuildingEntityData>(_jsonSerializer),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public override void WriteJson(JsonWriter writer, EntityData value, JsonSerializer serializer)
        {
            _jsonSerializer.Serialize(writer, value);
        }
    }
}
