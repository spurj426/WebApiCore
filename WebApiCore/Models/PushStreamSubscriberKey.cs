using System;

namespace WebApiCore.Models
{
    public class PushStreamSubscriberKey : IEquatable<PushStreamSubscriberKey>
    {
        public PushStreamSubscriberKey(Guid id, string type)
        {
            Id = id;
            Type = type;
        }

        public Guid Id { get; }
        public string Type { get; }

        public bool Equals(PushStreamSubscriberKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Id, other.Id) && Equals(Type, other.Type);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 9;
                hash = hash * 9 + Id.GetHashCode();
                hash = hash * 9 + Type.GetHashCode();
                return hash;
            }
        }
    }
}
