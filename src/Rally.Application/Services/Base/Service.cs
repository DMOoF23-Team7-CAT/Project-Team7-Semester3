using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Core.Repositories.Base;
using Rally.Application.Dto.Base;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities.Base;
using Rally.Application.Mapper;

namespace Rally.Application.Services.Base
{
    public class Service<TDto, TEntity, TDtoWithoutId> : IService<TDto, TEntity, TDtoWithoutId> 
        where TDto : BaseDto where TEntity : Entity where TDtoWithoutId : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<TDtoWithoutId> Create(TDto dto)
        {
            await ValidateIfExist(dto);

            var mappedEntity = ObjectMapper.Mapper.Map<TEntity>(dto);
            if (mappedEntity is null)
                throw new ApplicationException("Entity could not be mapped.");

            await _repository.AddAsync(mappedEntity);
            // TODO: Add logging

            var newMappedEntity = ObjectMapper.Mapper.Map<TDtoWithoutId>(mappedEntity);
            return newMappedEntity;
        }

        public async Task Delete(int id)
        {
            var deletedEntity = await _repository.GetByIdAsync(id);
            if (deletedEntity is null)
                throw new ApplicationException("Entity could not be deleted.");

            await _repository.DeleteAsync(deletedEntity);
            // TODO: Add logging
        }
        public async Task Update(TDto dto)
        {
            await ValidateIfNotExist(dto);

            var editEntity = await _repository.GetByIdAsync(dto.Id);
            if (editEntity is null)
                throw new ApplicationException("Entity could not be found.");

            ObjectMapper.Mapper.Map(dto, editEntity);

            await _repository.UpdateAsync(editEntity);
            // TODO: Add logging
        }

        public virtual async Task<TDtoWithoutId> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                throw new ApplicationException("Entity could not be found.");

            var mappedEntity = ObjectMapper.Mapper.Map<TDtoWithoutId>(entity);
            if (mappedEntity is null)
                throw new ApplicationException("Entity could not be mapped.");

            return mappedEntity;
        }


        public virtual async Task<IEnumerable<TDtoWithoutId>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            if (entities is null)
                throw new ApplicationException("Entities could not be found.");

            var mappedEntities = ObjectMapper.Mapper.Map<IEnumerable<TDtoWithoutId>>(entities);
            if (mappedEntities is null)
                throw new ApplicationException("Entities could not be mapped.");

            return mappedEntities;
        }


        // NOTE: this is only for entities without database generated ID
        private async Task ValidateIfExist(TDto dto)
        {
            if (dto.Id != 0)
            {
                var existingEntity = await _repository.GetByIdAsync(dto.Id);
                if (existingEntity != null)
                    throw new ApplicationException($"{dto.ToString()} with this id already exists");
            }
        }

        private async Task ValidateIfNotExist(TDto dto)
        {
            var existingEntity = await _repository.GetByIdAsync(dto.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{dto.ToString()} with this id does not exists");
        }
    }
}