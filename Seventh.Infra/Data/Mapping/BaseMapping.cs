﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seventh.Domain.Entities;

namespace Seventh.Infra.Data.Mapping
{
    public abstract class BaseMappingg<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
        }
    }
}