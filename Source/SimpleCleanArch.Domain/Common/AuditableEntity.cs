﻿using System.ComponentModel.DataAnnotations;

namespace SimpleCleanArch.Domain.Common;


public abstract class AuditableEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
