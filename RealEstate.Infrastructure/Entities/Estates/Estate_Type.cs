﻿using RealEstate.Infrastructure.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Infrastructure.Entities.Estates
{
    public class Estate_Type : IDeletableEntity
    {
        [Key]
        public int Id { get; init; }

        public string Type_Name { get; init; }


        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}