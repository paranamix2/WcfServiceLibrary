using Domain.Entities.Interface;

namespace Domain.Entities
{
    public abstract class EntityBase : IEntity 
    {
        public virtual long Id { get; set; }
    }
}
