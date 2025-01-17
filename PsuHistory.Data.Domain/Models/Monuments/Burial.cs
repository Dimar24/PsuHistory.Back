﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsuHistory.Data.Domain.Models.Monuments
{
    public class Burial : KeyGuidEntityBase
    { 
        public string Name { get; set; }
        public int NumberBurial { get; set; }
        public string Location { get; set; }
        public int KnownNumber { get; set; }
        public int UnknownNumber { get; set; }
        public int Year { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }

        public Guid TypeBurialId { get; set; }
        public virtual TypeBurial TypeBurial { get; set; }

        public virtual ICollection<AttachmentBurial> AttachmentBurials { get; set; } = new List<AttachmentBurial>();

        [NotMapped]
        public virtual ICollection<IFormFile> Files { get; set; }
    }
}
