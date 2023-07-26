﻿using Products.Domain.Model.Core;
using System;
using System.Collections.Generic;

namespace Products.Domain.Model.ProductType;

public partial class ProductType : BaseModel
{
    public Guid TenantId { get; set; }

    public Guid ProductTypeId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool? Active { get; set; }
}
