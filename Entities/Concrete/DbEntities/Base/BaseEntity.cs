﻿namespace Entities.Concrete.DbEntities.Base
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }

}