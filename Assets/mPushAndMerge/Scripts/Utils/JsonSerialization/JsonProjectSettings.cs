using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mPushAndMerge.Scripts.Utils.JsonSerialization
{
    public class JsonProjectSettings
    {
        public static void ApplyJsonEntityConverterSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new JsonEntityConverter());

            JsonConvert.DefaultSettings = () => settings;
        }
    }
}
