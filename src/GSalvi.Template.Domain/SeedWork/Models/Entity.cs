using System;

namespace GSalvi.Template.Domain.SeedWork.Models
{
    public abstract class Entity<T> where T : Entity<T>
    {
        public Guid Id { get; protected init; }

        public override bool Equals(object obj)
        {
            if (obj is not T compareTo) return false;
            return ReferenceEquals(this, compareTo) || Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907;
        }

        public override string ToString()
        {
            return GetType().Name;
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }
    }
}