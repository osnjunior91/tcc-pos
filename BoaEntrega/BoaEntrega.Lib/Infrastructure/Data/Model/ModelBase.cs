using System;
using System.Collections.Generic;
using System.Text;

namespace BoaEntrega.Lib.Infrastructure.Data.Model
{
    public class ModelBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
