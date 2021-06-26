using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GSalvi.Template.Domain.SeedWork.Models
{
    public abstract class Enumeration : IComparable
    {
        public int Id { get; }
        public string Name { get; }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int CompareTo(object other) => Id.CompareTo(((Enumeration) other).Id);

        public override bool Equals(object obj)
        {
            if (obj is not Enumeration otherValue) return false;

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;

        private static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetProperties(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public static T FromValue<T>(int value) where T : Enumeration
        {
            return Parse<T>(item => item.Id == value);
        }

        public static T FromDisplayName<T>(string displayName) where T : Enumeration
        {
            return Parse<T>(item => string.Equals(item.Name, displayName, StringComparison.OrdinalIgnoreCase));
        }

        private static T Parse<T>(Func<T, bool> predicate) where T : Enumeration
        {
            return GetAll<T>().FirstOrDefault(predicate);
        }
    }
}