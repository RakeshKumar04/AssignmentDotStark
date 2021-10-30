using System;

namespace AssignmentDotStark.Domain
{
    public interface IBaseEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
