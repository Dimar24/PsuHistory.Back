﻿using Microsoft.AspNetCore.Http;
using System;

namespace PsuHistory.Business.DTO.Models.CreateDataModels
{
    public class CreateAttachmentBurial 
    {
        public Guid BurialId { get; set; }
        public IFormFile File { get; set; }
    }
}
