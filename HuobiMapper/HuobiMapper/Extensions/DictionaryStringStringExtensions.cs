using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HuobiMapper.Extensions
{
    internal static class DictionaryStringStringExtensions
    {
        public static object FromDictToAnonymousObj<TValue>(this IDictionary<string, TValue> dict)
        {
            var types = new Type[dict.Count];

            for (int i = 0; i < types.Length; i++)
            {
                types[i] = typeof(TValue);
            }

            // dictionaries don't have an order, so we force an order based
            // on the Key
            var ordered = dict.OrderBy(x => x.Key).ToArray();

            string[] names = Array.ConvertAll(ordered, x => x.Key);

            Type type = AnonymousType.CreateType(types, names);

            object[] values = Array.ConvertAll(ordered, x => (object)x.Value);

            object obj = type.GetConstructor(types).Invoke(values);

            return obj;
        }
        public static void AddObjectIfNotNull<T>( this IDictionary<string, T> dictionary,
             string key,  T value)
        {
            if (value == null) return;

            dictionary.Add(key, value);
        }
        public static void AddObjectIfNotNull<T>( this IDictionary<Enum, T> dictionary,
             Enum key,  T value)
        {
            if (value == null) return;

            dictionary.Add(key, value);
        }
        public static void AddStringIfNotEmptyOrWhiteSpace( this IDictionary<string, string> dictionary,
             string key,  string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;

            dictionary.Add(key, value);
        }

        public static void AddDecimal( this IDictionary<string, string> dictionary,
             string key, decimal value) =>
            dictionary.Add(key, value.ToFormattedStringPublic());

        public static void AddDecimalIfNotNull( this IDictionary<string, string> dictionary,
             string key, decimal? value)
        {
            if (!value.HasValue) return;

            dictionary.Add(key, value.Value.ToFormattedStringPublic());
        }

        public static void AddBoolean( this IDictionary<string, string> dictionary,
             string key, bool value) =>
            dictionary.Add(key, value.ToString(CultureInfo.InvariantCulture).ToLower());

        public static void AddBooleanIfNotNull( this IDictionary<string, string> dictionary,
             string key, bool? value)
        {
            if (!value.HasValue) return;

            dictionary.Add(key, value.Value.ToString(CultureInfo.InvariantCulture).ToLower());
        }

        public static void AddSimpleStruct<T>( this IDictionary<string, string> dictionary,
             string key, T value) where T : struct
            => dictionary.Add(key, value.ToString());

        public static void AddSimpleStructIfNotNull<T>( this IDictionary<string, string> dictionary,
             string key, T? value) where T : struct
        {
            if (!value.HasValue) return;

            dictionary.Add(key, value.Value.ToString());
        }

        public static void AddEnum<T>( this IDictionary<string, string> dictionary,
             string key, T value) where T : struct
        {
            dictionary.Add(key, EnumHelper.GetEnumMemberAttributeValue(value));
        }

        public static void AddEnumIfNotNull<T>( this IDictionary<string, string> dictionary,
             string key,  T? value) where T : struct
        {
            if (!value.HasValue) return;

            dictionary.Add(key, EnumHelper.GetEnumMemberAttributeValue(value.Value));
        }

        public static void AddListEnums<T>(this IDictionary<string,string> dictionary, string key, List<T> value) where T : struct
        {
            string str = string.Empty;
            List<string> strs = new List<string>();
            value.ForEach(x => { strs.Add(EnumHelper.GetEnumMemberAttributeValue(x)); });
            str = string.Join(",", strs);
            dictionary.Add(key, str);
        }
    }
}