using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Domain.Core
{
    public class Entity
    {
        public ObjectId  Id { get; set; }

        public DateTime CreatedDate { get; protected set; } = DateTime.Now.ToUniversalTime();
        public DateTime UpdatedDate { get; protected set; } 


        protected Entity()
        {
            this.Id = ObjectId.GenerateNewId();
        }

        public override bool Equals(object obj)
        {
            Entity temp = obj as Entity;
            if (temp==null)
            {
                return false;
            }

            bool tempIsTransient = Equals(temp.Id, default(ObjectId));
            bool thisIsTransient = Equals(this.Id, default(ObjectId));

            if (tempIsTransient && thisIsTransient)
            {
                return ReferenceEquals(temp, this);
            }

            return temp.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        private ICollection<INotification> domainEvents;
        public ICollection<INotification> DomainEvents => domainEvents;

        public void AddDomainEvents(INotification notification)
        {
            domainEvents ??= new List<INotification>();

            domainEvents.Add(notification);
        }
    }
}
