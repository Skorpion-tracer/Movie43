using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Movie43.Helper.Converters.ServiceEnum
{
    public static class EnumHelper
    {
        /// <summary>
        /// Получить Description атрибут из enum с заданным значением
        /// </summary>
        public static string Description(this Enum value)
        {
            var attributes = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Any())
                return (attributes.First() as DescriptionAttribute).Description;
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            return ti.ToTitleCase(ti.ToLower(value.ToString().Replace("_", " ")));
        }
        /// <summary>
        /// Получить Description атрибут из любого enum и соответствующего значения
        /// </summary>
        public static string Description(Enum enumObj, byte value)
        {
            Type type = enumObj.GetType();
            type.GetField("value__").SetValue(enumObj, value);
            var attributes = type.GetField(enumObj.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Any())
                return (attributes.First() as DescriptionAttribute).Description;
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            return ti.ToTitleCase(ti.ToLower(value.ToString().Replace("_", " ")));
        }
        /// <summary>
        /// Привести значение byte к любому enum
        /// </summary>
        /// <returns> Возвращается новый экземпляр Enum с заданным значением </returns>
        public static Enum ByteToEnum(Enum enumType, byte value)
        {
            Enum enumOut = (Enum)Activator.CreateInstance(enumType.GetType());
            enumOut.GetType().GetField("value__").SetValue(enumOut, value);
            return enumOut;
        }
        /// <summary>
        /// Получить значение любого Enum
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static byte EnumToByte(Enum enumType)
        {
            int value = (int)enumType.GetType().GetField("value__").GetValue(enumType);
            return Convert.ToByte(value);
        }
        public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions(Type t)
        {
            if (!t.IsEnum)
                throw new ArgumentException($"{nameof(t)} must be an enum type");
            return Enum.GetValues(t).Cast<Enum>().Select((e) => new ValueDescription() { Value = e, Description = e.Description() }).ToList();
        }
        /// <summary>
        /// Извлечь наименование атрибута класса
        /// </summary>
        public static string Description(Type inf, string nameAttribute)
        {
            string myAttrebute = default;
            foreach (CustomAttributeData customAttributeData in inf.CustomAttributes)
            {
                if (customAttributeData.AttributeType.Name == nameAttribute)
                {
                    myAttrebute = customAttributeData.ConstructorArguments[0].Value.ToString();
                }
            }
            return myAttrebute;
        }
    }
}
