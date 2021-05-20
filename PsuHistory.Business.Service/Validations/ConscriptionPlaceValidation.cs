﻿using PsuHistory.Business.Service.Interfaces;
using PsuHistory.Business.Service.Models;
using PsuHistory.Data.Domain.Models.Monuments;
using PsuHistory.Data.Service.Interfaces;
using PsuHistory.Resource.Recources.Validation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PsuHistory.Business.Service.Validations
{
    public interface IConscriptionPlaceValidation : IBaseValidation<Guid, ConscriptionPlace>
    { }

    public class ConscriptionPlaceValidation : IConscriptionPlaceValidation
    {
        private ValidationModel<ConscriptionPlace> validation;
        private readonly IBaseService<Guid, ConscriptionPlace> dataConscriptionPlace;

        public ConscriptionPlaceValidation(IBaseService<Guid, ConscriptionPlace> dataConscriptionPlace)
        {
            this.dataConscriptionPlace = dataConscriptionPlace;
            validation = new ValidationModel<ConscriptionPlace>();
        }

        public async Task<ValidationModel<ConscriptionPlace>> GetValidationAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (await dataConscriptionPlace.ExistByIdAsync(id, cancellationToken))
            {
                validation.Errors.Add(nameof(ConscriptionPlace), BaseValidation.ObjectNotExistById);
            }

            return validation;
        }

        public async Task<ValidationModel<ConscriptionPlace>> InsertValidationAsync(ConscriptionPlace newEntity, CancellationToken cancellationToken = default)
        {
            if (newEntity is not null)
            {
                if (await dataConscriptionPlace.ExistAsync(newEntity, cancellationToken))
                {
                    validation.Errors.Add(nameof(ConscriptionPlace), BaseValidation.ObjectExistWithThisData);
                }

                if (newEntity.Place is null)
                {
                    validation.Errors.Add(nameof(ConscriptionPlace.Place), BaseValidation.FieldNotCanBeNull);
                }
                else if (newEntity.Place.Length < 3 || newEntity.Place.Length > 512)
                {
                    validation.Errors.Add(nameof(ConscriptionPlace.Place), BaseValidation.FieldInvalidLength);
                }
            }
            else
            {
                validation.Errors.Add(nameof(ConscriptionPlace), BaseValidation.ObjectNotCanBeNull);
            }

            return validation;
        }

        public async Task<ValidationModel<ConscriptionPlace>> UpdateValidationAsync(ConscriptionPlace newEntity, CancellationToken cancellationToken = default)
        {
            if (newEntity is not null)
            {
                if (await dataConscriptionPlace.ExistByIdAsync(newEntity.Id, cancellationToken))
                {
                    validation.Errors.Add(nameof(ConscriptionPlace), BaseValidation.ObjectNotExistById);
                }

                if (await dataConscriptionPlace.ExistAsync(newEntity, cancellationToken))
                {
                    validation.Errors.Add(nameof(ConscriptionPlace), BaseValidation.ObjectExistWithThisData);
                }

                if (newEntity.Place is null)
                {
                    validation.Errors.Add(nameof(ConscriptionPlace.Place), BaseValidation.FieldNotCanBeNull);
                }
                else if (newEntity.Place.Length < 3 || newEntity.Place.Length > 512)
                {
                    validation.Errors.Add(nameof(ConscriptionPlace.Place), BaseValidation.FieldInvalidLength);
                }
            }
            else
            {
                validation.Errors.Add(nameof(ConscriptionPlace), BaseValidation.ObjectNotCanBeNull);
            }

            return validation;
        }

        public async Task<ValidationModel<ConscriptionPlace>> DeleteValidationAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (await dataConscriptionPlace.ExistByIdAsync(id, cancellationToken))
            {
                validation.Errors.Add(nameof(ConscriptionPlace), BaseValidation.ObjectNotExistById);
            }

            return validation;
        }
    }
}
