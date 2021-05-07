﻿using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PsuHistory.Data.Domain.Models.Monuments;
using PsuHistory.Data.EF.SQL;
using PsuHistory.Data.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsuHistory.Data
{
    [TestFixture]
    class VictimServiceTest
    {
        private PsuHistoryDbContext _dbContext;
        private IVictimService _service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<PsuHistoryDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            _dbContext = new PsuHistoryDbContext(options.Options);
            _service = new VictimService(_dbContext);
        }

        [TearDown]
        public void Teardown()
        {
            _dbContext.Dispose();
        }

        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        [TestCase(0)]
        public async Task TestInsertAndGetAsync(int number)
        {
            // Arrange
            var entity = GetList()[number];
            await _service.InsertAsync(entity);
            _dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.Entry(entity.TypeVictim).State = EntityState.Detached;
            _dbContext.Entry(entity.DutyStation).State = EntityState.Detached;
            _dbContext.Entry(entity.BirthPlace).State = EntityState.Detached;
            _dbContext.Entry(entity.ConscriptionPlace).State = EntityState.Detached;
            _dbContext.Entry(entity.Burial).State = EntityState.Detached;
            _dbContext.Entry(entity.Burial.TypeBurial).State = EntityState.Detached;

            // Act
            var result = await _service.GetAsync(entity.Id);
            _dbContext.Entry(result).State = EntityState.Detached;
            _dbContext.Entry(entity.TypeVictim).State = EntityState.Detached;
            _dbContext.Entry(entity.DutyStation).State = EntityState.Detached;
            _dbContext.Entry(entity.BirthPlace).State = EntityState.Detached;
            _dbContext.Entry(entity.ConscriptionPlace).State = EntityState.Detached;
            _dbContext.Entry(entity.Burial).State = EntityState.Detached;
            _dbContext.Entry(entity.Burial.TypeBurial).State = EntityState.Detached;

            // Assert
            Assert.IsTrue(
                entity.LastName == result.LastName &&
                entity.FirstName == result.FirstName &&
                entity.MiddleName == result.MiddleName &&
                entity.IsHeroSoviet == result.IsHeroSoviet &&
                entity.IsPartisan == result.IsPartisan &&
                entity.DateOfBirth == result.DateOfBirth &&
                entity.DateOfDeath == result.DateOfDeath &&
                entity.TypeVictimId == result.TypeVictimId &&
                entity.DutyStationId == result.DutyStationId &&
                entity.BirthPlaceId == result.BirthPlaceId &&
                entity.ConscriptionPlaceId == result.ConscriptionPlaceId &&
                entity.BurialId == result.BurialId &&
                entity.CreatedAt == result.CreatedAt &&
                entity.UpdatedAt == result.UpdatedAt
                );
        }

        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        [TestCase(0)]
        public async Task TestGetAllAsync(int count)
        {
            // Arrange
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

        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        [TestCase(0)]
        public async Task TestUpdateAsync(int number)
        {
            // Arrange
            var entity = GetList()[number];
            await _service.InsertAsync(entity);
            _dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.Entry(entity.TypeVictim).State = EntityState.Detached;
            _dbContext.Entry(entity.DutyStation).State = EntityState.Detached;
            _dbContext.Entry(entity.BirthPlace).State = EntityState.Detached;
            _dbContext.Entry(entity.ConscriptionPlace).State = EntityState.Detached;
            _dbContext.Entry(entity.Burial).State = EntityState.Detached;
            _dbContext.Entry(entity.Burial.TypeBurial).State = EntityState.Detached;

            entity = new Victim()
            {
                Id = entity.Id,
                FirstName = "Имя Тест",
                LastName = "Фамилия Тест",
                MiddleName = "Отчество Тест",
                IsHeroSoviet = !entity.IsHeroSoviet,
                IsPartisan = !entity.IsPartisan,
                DateOfBirth = DateTime.Now.AddDays(4).ToString(),
                DateOfDeath = DateTime.Now.AddDays(-4).ToString(),
                TypeVictimId = Guid.NewGuid(),
                TypeVictim = GetTypeVictim(),
                DutyStationId = Guid.NewGuid(),
                DutyStation = GetDutyStation(),
                BirthPlaceId = Guid.NewGuid(),
                BirthPlace = GetBirthPlace(),
                ConscriptionPlaceId = Guid.NewGuid(),
                ConscriptionPlace = GetConscriptionPlace(),
                BurialId = Guid.NewGuid(),
                Burial = GetBurial(),
                CreatedAt = DateTime.Now.AddMinutes(60),
                UpdatedAt = DateTime.Now.AddMinutes(60)
            };
            await _service.UpdateAsync(entity);
            _dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.Entry(entity.TypeVictim).State = EntityState.Detached;
            _dbContext.Entry(entity.DutyStation).State = EntityState.Detached;
            _dbContext.Entry(entity.BirthPlace).State = EntityState.Detached;
            _dbContext.Entry(entity.ConscriptionPlace).State = EntityState.Detached;
            _dbContext.Entry(entity.Burial).State = EntityState.Detached;
            _dbContext.Entry(entity.Burial.TypeBurial).State = EntityState.Detached;

            // Act
            var result = await _service.GetAsync(entity.Id);
            _dbContext.Entry(result).State = EntityState.Detached;
            _dbContext.Entry(result.TypeVictim).State = EntityState.Detached;
            _dbContext.Entry(result.DutyStation).State = EntityState.Detached;
            _dbContext.Entry(result.BirthPlace).State = EntityState.Detached;
            _dbContext.Entry(result.ConscriptionPlace).State = EntityState.Detached;
            _dbContext.Entry(result.Burial).State = EntityState.Detached;
            _dbContext.Entry(result.Burial.TypeBurial).State = EntityState.Detached;

            // Assert
            Assert.IsTrue(
                entity.LastName == result.LastName &&
                entity.FirstName == result.FirstName &&
                entity.MiddleName == result.MiddleName &&
                entity.IsHeroSoviet == result.IsHeroSoviet &&
                entity.IsPartisan == result.IsPartisan &&
                entity.DateOfBirth == result.DateOfBirth &&
                entity.DateOfDeath == result.DateOfDeath &&
                entity.TypeVictimId == result.TypeVictimId &&
                entity.DutyStationId == result.DutyStationId &&
                entity.BirthPlaceId == result.BirthPlaceId &&
                entity.ConscriptionPlaceId == result.ConscriptionPlaceId &&
                entity.BurialId == result.BurialId &&
                entity.CreatedAt == result.CreatedAt &&
                entity.UpdatedAt == result.UpdatedAt
                );
        }

        [TestCase(4)]
        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        [TestCase(0)]
        public async Task TestDeleteAsync(int number)
        {
            // Arrange
            var entity = GetList()[number];
            entity = await _service.InsertAsync(entity);
            var id = entity.Id;
            _dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.Entry(entity.TypeVictim).State = EntityState.Detached;
            _dbContext.Entry(entity.DutyStation).State = EntityState.Detached;
            _dbContext.Entry(entity.BirthPlace).State = EntityState.Detached;
            _dbContext.Entry(entity.ConscriptionPlace).State = EntityState.Detached;
            _dbContext.Entry(entity.Burial).State = EntityState.Detached;
            _dbContext.Entry(entity.Burial.TypeBurial).State = EntityState.Detached;

            // Act
            var entityExsist = await _service.GetAsync(id);
            _dbContext.Entry(entityExsist).State = EntityState.Detached;
            _dbContext.Entry(entityExsist.TypeVictim).State = EntityState.Detached;
            _dbContext.Entry(entityExsist.DutyStation).State = EntityState.Detached;
            _dbContext.Entry(entityExsist.BirthPlace).State = EntityState.Detached;
            _dbContext.Entry(entityExsist.ConscriptionPlace).State = EntityState.Detached;
            _dbContext.Entry(entityExsist.Burial).State = EntityState.Detached;
            _dbContext.Entry(entityExsist.Burial.TypeBurial).State = EntityState.Detached;
            await _service.DeleteAsync(id);
            var entityNotExsist = await _service.GetAsync(id) ?? null;

            // Assert
            Assert.IsTrue(
                entityExsist is not null &&
                entityNotExsist is null
                );
        }


        private List<Victim> GetList()
        {
            return new List<Victim>()
            {
                new Victim()
                {
                    FirstName = "Имя 1",
                    LastName = "Фамилия 1",
                    MiddleName = "Отчество 1",
                    IsHeroSoviet = true,
                    IsPartisan = true,
                    DateOfBirth = DateTime.Now.AddDays(2).ToString(),
                    DateOfDeath = DateTime.Now.AddDays(-2).ToString(),
                    TypeVictimId = Guid.NewGuid(),
                    TypeVictim = GetTypeVictim(),
                    DutyStationId = Guid.NewGuid(),
                    DutyStation = GetDutyStation(),
                    BirthPlaceId = Guid.NewGuid(),
                    BirthPlace = GetBirthPlace(),
                    ConscriptionPlaceId = Guid.NewGuid(),
                    ConscriptionPlace = GetConscriptionPlace(),
                    BurialId = Guid.NewGuid(),
                    Burial = GetBurial(),
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UpdatedAt = DateTime.Now.AddDays(-5)
                },
                new Victim()
                {
                    FirstName = "Имя 2",
                    LastName = "Фамилия 2",
                    MiddleName = "Отчество 2",
                    IsHeroSoviet = false,
                    IsPartisan = true,
                    DateOfBirth = DateTime.Now.AddDays(-2).ToString(),
                    DateOfDeath = DateTime.Now.AddDays(-2).ToString(),
                    TypeVictimId = Guid.NewGuid(),
                    TypeVictim = GetTypeVictim(),
                    DutyStationId = Guid.NewGuid(),
                    DutyStation = GetDutyStation(),
                    BirthPlaceId = Guid.NewGuid(),
                    BirthPlace = GetBirthPlace(),
                    ConscriptionPlaceId = Guid.NewGuid(),
                    ConscriptionPlace = GetConscriptionPlace(),
                    BurialId = Guid.NewGuid(),
                    Burial = GetBurial(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Victim()
                {
                    FirstName = "Имя 3",
                    LastName = "Фамилия 3",
                    MiddleName = "Отчество 3",
                    IsHeroSoviet = true,
                    IsPartisan = false,
                    DateOfBirth = DateTime.Now.AddDays(2).ToString(),
                    DateOfDeath = DateTime.Now.AddDays(2).ToString(),
                    TypeVictimId = Guid.NewGuid(),
                    TypeVictim = GetTypeVictim(),
                    DutyStationId = Guid.NewGuid(),
                    DutyStation = GetDutyStation(),
                    BirthPlaceId = Guid.NewGuid(),
                    BirthPlace = GetBirthPlace(),
                    ConscriptionPlaceId = Guid.NewGuid(),
                    ConscriptionPlace = GetConscriptionPlace(),
                    BurialId = Guid.NewGuid(),
                    Burial = GetBurial(),
                    CreatedAt = DateTime.Now.AddDays(5),
                    UpdatedAt = DateTime.Now.AddDays(5)
                },
                new Victim()
                {
                    FirstName = "Имя 4",
                    LastName = "Фамилия 4",
                    MiddleName = "Отчество 4",
                    IsHeroSoviet = false,
                    IsPartisan = false,
                    DateOfBirth = DateTime.Now.AddDays(7).ToString(),
                    DateOfDeath = DateTime.Now.AddDays(7).ToString(),
                    TypeVictimId = Guid.NewGuid(),
                    TypeVictim = GetTypeVictim(),
                    DutyStationId = Guid.NewGuid(),
                    DutyStation = GetDutyStation(),
                    BirthPlaceId = Guid.NewGuid(),
                    BirthPlace = GetBirthPlace(),
                    ConscriptionPlaceId = Guid.NewGuid(),
                    ConscriptionPlace = GetConscriptionPlace(),
                    BurialId = Guid.NewGuid(),
                    Burial = GetBurial(),
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UpdatedAt = DateTime.Now.AddDays(-3)
                },
                new Victim()
                {
                    FirstName = "Имя 5",
                    LastName = "Фамилия 5",
                    MiddleName = "Отчество 5",
                    IsHeroSoviet = true,
                    IsPartisan = false,
                    DateOfBirth = DateTime.Now.AddDays(-7).ToString(),
                    DateOfDeath = DateTime.Now.AddDays(-7).ToString(),
                    TypeVictimId = Guid.NewGuid(),
                    TypeVictim = GetTypeVictim(),
                    DutyStationId = Guid.NewGuid(),
                    DutyStation = GetDutyStation(),
                    BirthPlaceId = Guid.NewGuid(),
                    BirthPlace = GetBirthPlace(),
                    ConscriptionPlaceId = Guid.NewGuid(),
                    ConscriptionPlace = GetConscriptionPlace(),
                    BurialId = Guid.NewGuid(),
                    Burial = GetBurial(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
        }

        private TypeVictim GetTypeVictim()
        {
            return new TypeVictim()
            {
                Name = "Тип",
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now.AddDays(-5)
            };
        }

        private DutyStation GetDutyStation()
        {
            return new DutyStation()
            {
                Place = "ул. Блохина 29, Новополоцк 211440",
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now.AddDays(-5)
            };
        }

        private BirthPlace GetBirthPlace()
        {
            return new BirthPlace()
            {
                Place = "ул. Блохина 29, Новополоцк 211440",
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now.AddDays(-5)
            };
        }

        private ConscriptionPlace GetConscriptionPlace()
        {
            return new ConscriptionPlace()
            {
                Place = "ул. Блохина 29, Новополоцк 211440",
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now.AddDays(-5)
            };
        }

        private Burial GetBurial()
        {
            return new Burial()
            {
                NumberBurial = 1,
                Location = "ул. Блохина 29, Новополоцк 211440",
                NumberPeople = 10,
                UnknownNumber = 10,
                Year = 2001,
                Latitude = 28.01,
                Longitude = 32.01,
                Description = "Описание",
                TypeBurialId = Guid.NewGuid(),
                TypeBurial = GetTypeBurial(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        private TypeBurial GetTypeBurial()
        {
            return new TypeBurial()
            {
                Name = "Тип",
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now.AddDays(-5)
            };
        }
    }
}