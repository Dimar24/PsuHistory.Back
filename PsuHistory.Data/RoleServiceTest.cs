﻿using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PsuHistory.Data.Domain.Models.Monuments;
using PsuHistory.Data.Domain.Models.Users;
using PsuHistory.Data.EF.SQL;
using PsuHistory.Data.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsuHistory.Data
{
    [TestFixture]
    class RoleServiceTest
    {
        private PsuHistoryDbContext _dbContext;
        private IRoleService _service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<PsuHistoryDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            _dbContext = new PsuHistoryDbContext(options.Options);
            _service = new RoleService(_dbContext);
        }

        [TearDown]
        public void Teardown()
        {
            _dbContext.Dispose();
        }

        [Test]
        public async Task TestInsertAndGetAsync()
        {
            // Arrange
            var random = new Random(0);
            var number = random.Next(5);
            var entity = GetList()[number];
            await _service.InsertAsync(entity);
            _dbContext.Entry(entity).State = EntityState.Detached;

            // Act
            var result = await _service.GetAsync(entity.Id);
            _dbContext.Entry(result).State = EntityState.Detached;

            // Assert
            Assert.IsTrue(entity.Name == result.Name);
            Assert.IsTrue(entity.CreatedAt == result.CreatedAt);
            Assert.IsTrue(entity.UpdatedAt == result.UpdatedAt);
        }

        [Test]
        public async Task TestGetAllAsync()
        {
            // Arrange
            var random = new Random(0);
            var count = random.Next(5);
            var entityList = GetList().Take(count);
            foreach (var entity in entityList)
            {
                await _service.InsertAsync(entity);
            }

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.AreEqual(entityList.Count(), result.Count());
        }

        [Test]
        public async Task TestUpdateAsync()
        {
            // Arrange
            var random = new Random(0);
            var number = random.Next(5);
            var entity = GetList()[number];
            await _service.InsertAsync(entity);
            _dbContext.Entry(entity).State = EntityState.Detached;

            entity = new Role()
            {
                Id = entity.Id,
                Name = "cat",
                CreatedAt = DateTime.Now.AddMinutes(60),
                UpdatedAt = DateTime.Now.AddMinutes(60)
            };
            await _service.UpdateAsync(entity);
            _dbContext.Entry(entity).State = EntityState.Detached;

            // Act
            var result = await _service.GetAsync(entity.Id);
            _dbContext.Entry(result).State = EntityState.Detached;

            // Assert
            Assert.IsTrue(entity.Name == result.Name);
            Assert.IsTrue(entity.CreatedAt == result.CreatedAt);
            Assert.IsTrue(entity.UpdatedAt == result.UpdatedAt);
        }

        [Test]
        public async Task TestDeleteAsync()
        {
            // Arrange
            var random = new Random(0);
            var number = random.Next(5);
            var entity = GetList()[number];
            entity = await _service.InsertAsync(entity);
            var id = entity.Id;
            _dbContext.Entry(entity).State = EntityState.Detached;

            // Act
            var entityExsist = await _service.GetAsync(id);
            _dbContext.Entry(entityExsist).State = EntityState.Detached;
            await _service.DeleteAsync(id);
            var entityNotExsist = await _service.GetAsync(id) ?? null;

            // Assert
            Assert.IsNull(entityNotExsist);
            Assert.IsNotNull(entityExsist);
        }


        private List<Role> GetList()
        {
            return new List<Role>()
            {
                new Role()
                {
                    Name = "admin",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UpdatedAt = DateTime.Now.AddDays(-5)
                },
                new Role()
                {
                    Name = "user",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Role()
                {
                    Name = "superuser",
                    CreatedAt = DateTime.Now.AddDays(5),
                    UpdatedAt = DateTime.Now.AddDays(5)
                },
                new Role()
                {
                    Name = "superman",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UpdatedAt = DateTime.Now.AddDays(-3)
                },
                new Role()
                {
                    Name = "check",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
        }
    }
}
