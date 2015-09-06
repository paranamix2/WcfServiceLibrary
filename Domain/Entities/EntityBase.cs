using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Interface;

namespace Domain.Entities
{
    public abstract class EntityBase : IEntity 
    {
        public virtual long Id { get; set; }
    }
}
