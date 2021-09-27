using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace EnumDesriptor
{
    /// <summary>
    /// Класс методов расширения для <see langward="enum"/> для получения описания членов перечисления, декорированных
    /// аттрибутом <see cref="System.ComponentModel.DescriptionAttribute"/>
    /// </summary>
    public static class EnumExtensions
    {
        private static readonly Dictionary<Enum, string> descMap = new();

        private static string GetDescriptionImpl(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field is null) return value.ToString();

            var attr = field.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description ?? value.ToString();
        }

        /// <summary>
        /// получить описание члена перечисления
        /// </summary>
        /// <param name="item">искамый член перечисления</param>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <returns>Строка с описанием из аттрибута Description,</returns>
        public static string GetDescription<T>(this T item) where T: struct, Enum
        {
            if (descMap.TryGetValue(item, out var desc))
                return desc;
            var description = GetDescriptionImpl(item);
            descMap.Add(item, description);
            return description;
        }
    }
}
