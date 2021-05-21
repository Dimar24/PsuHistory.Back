﻿using PsuHistory.Business.Service.Helpers;
using PsuHistory.Business.Service.Interfaces;
using PsuHistory.Business.Service.Models;
using PsuHistory.Data.Domain.Models.Histories;
using PsuHistory.Data.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PsuHistory.Business.Service.BusinessServices
{
    public interface IAttachmentFormBusinessService : IBaseBusinessService<Guid, AttachmentForm>
    { }

    class AttachmentFormBusinessService : IAttachmentFormBusinessService
    {
        private readonly FileHelper fileHelper;
        private readonly IBaseService<Guid, AttachmentForm> dataAttachmentForm;
        private readonly IBaseValidation<Guid, AttachmentForm> attachmentFormValidation;

        public AttachmentFormBusinessService(
            FileHelper fileHelper,
            IBaseService<Guid, AttachmentForm> dataAttachmentForm,
            IBaseValidation<Guid, AttachmentForm> attachmentFormValidation)
        {
            this.fileHelper = fileHelper;
            this.dataAttachmentForm = dataAttachmentForm;
            this.attachmentFormValidation = attachmentFormValidation;
        }

        public async Task<ValidationModel<AttachmentForm>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var validation = await attachmentFormValidation.GetValidationAsync(id, cancellationToken);

            if (!validation.IsValid)
            {
                return validation;
            }

            validation.Result = await dataAttachmentForm.GetAsync(id, cancellationToken);

            return validation;
        }

        public async Task<ValidationModel<IEnumerable<AttachmentForm>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var validation = new ValidationModel<IEnumerable<AttachmentForm>>();

            validation.Result = await dataAttachmentForm.GetAllAsync(cancellationToken);

            return validation;
        }

        public async Task<ValidationModel<AttachmentForm>> InsertAsync(AttachmentForm newEntity, CancellationToken cancellationToken = default)
        {
            var validation = await attachmentFormValidation.InsertValidationAsync(newEntity, cancellationToken);

            if (!validation.IsValid)
            {
                return validation;
            }

            var fileData = await fileHelper.SaveFile(newEntity.File);

            newEntity.FilePath = fileData.FilePath;
            newEntity.FileName = fileData.FileName;
            newEntity.FileType = fileData.FileType;
            newEntity.CreatedAt = DateTime.Now;
            newEntity.UpdatedAt = DateTime.Now;

            validation.Result = await dataAttachmentForm.InsertAsync(newEntity, cancellationToken);

            return validation;
        }

        public async Task<ValidationModel<AttachmentForm>> UpdateAsync(AttachmentForm newEntity, CancellationToken cancellationToken = default)
        {
            var validation = await attachmentFormValidation.UpdateValidationAsync(newEntity, cancellationToken);

            if (!validation.IsValid)
            {
                return validation;
            }

            var oldEntity = await dataAttachmentForm.GetAsync(newEntity.Id, cancellationToken);

            newEntity.CreatedAt = oldEntity.CreatedAt;
            newEntity.UpdatedAt = DateTime.Now;

            validation.Result = await dataAttachmentForm.UpdateAsync(newEntity, cancellationToken);

            return validation;
        }

        public async Task<ValidationModel<AttachmentForm>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var validation = await attachmentFormValidation.DeleteValidationAsync(id, cancellationToken);

            if (!validation.IsValid)
            {
                return validation;
            }

            var entity = await dataAttachmentForm.GetAsync(id, cancellationToken);

            fileHelper.DeleteFile(entity.FilePath + entity.FileName + "." + entity.FileType);

            await dataAttachmentForm.DeleteAsync(id, cancellationToken);

            return validation;
        }
    }
}
