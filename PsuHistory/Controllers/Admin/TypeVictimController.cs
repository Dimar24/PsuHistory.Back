﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsuHistory.Controllers.Abstraction;
using PsuHistory.Business.DTO.Models.CreateDataModels;
using PsuHistory.Business.DTO.Models.UpdateDataModels;
using PsuHistory.Business.Service.Interfaces;
using PsuHistory.Data.Domain.Models.Monuments;
using System;
using System.Threading.Tasks;

namespace PsuHistory.Controllers.Admin
{
    [ApiController]
    [Authorize(Roles = "Admin, Moderator")]
    [Route("api/admin/[controller]")]
    public class TypeVictimController : AbstractionControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBaseService<Guid, TypeVictim> typeVictimService;

        public TypeVictimController(
            IMapper mapper,
            IBaseService<Guid, TypeVictim> typeVictimService)
        {
            this.mapper = mapper;
            this.typeVictimService = typeVictimService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var validation = await typeVictimService.GetAsync(id);

            return CreateObjectResult(validation);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var validation = await typeVictimService.GetAllAsync();

            return CreateObjectResult(validation);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] CreateTypeVictim createTypeVictim)
        {
            var typeVictim = mapper.Map<TypeVictim>(createTypeVictim);

            var validation = await typeVictimService.InsertAsync(typeVictim);

            return CreateObjectResult(validation);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromForm] UpdateTypeVictim updateTypeVictim)
        {
            var typeVictim = mapper.Map<TypeVictim>(updateTypeVictim);

            var validation = await typeVictimService.UpdateAsync(typeVictim);

            return CreateObjectResult(validation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var validation = await typeVictimService.DeleteAsync(id);

            return CreateObjectResult(validation);
        }
    }
}
