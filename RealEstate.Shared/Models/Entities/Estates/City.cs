﻿using RealEstate.Shared.Models.Entities.BaseEntityModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Shared.Models.Entities.Estates
{
    public class City : IDeletableEntity
    {
        [Key]
        public int Id { get; init; }

        public string City_Name { get; init; }

        [ForeignKey("Country_Id")]
        public int Country_Id { get; init; }
        public Country Country { get; init; }

        public IEnumerable<Estate> Estates { get; init; }


        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DeletedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}