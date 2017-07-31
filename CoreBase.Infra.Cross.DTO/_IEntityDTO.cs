using System;

namespace CoreBase.Infra.Cross.DTO
{
    public interface IEntityDTO
    {
        DateTime CreatedAt { get; set; }
        bool Active { get; set; }
    }
}
