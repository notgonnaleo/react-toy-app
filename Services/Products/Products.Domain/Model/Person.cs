using Products.Domain.Model.Core;
using System;
using System.Collections.Generic;

namespace Products.Domain.Model.Person;

public partial class Person : BaseModel
{
    public Guid TenantId { get; set; }

    public Guid PersonId { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool? Active { get; set; }
}
