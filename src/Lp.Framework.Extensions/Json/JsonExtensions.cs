using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lp.Framework.Extensions.Json
{
    public static class JsonExtensions
    {
        public static string ToJson(this object? obj)
        {
            if (obj is null)
            {
                return "";
            }

            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static T? ToObject<T>(this string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}