using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;
using Rally.Core.Entities.Base;

namespace Rally.Application.Interfaces.Base
{
    public interface IService<TDto, TEntity, TDtoWithoutId> where TDto : BaseDto where TEntity : Entity where TDtoWithoutId : class
    {
        Task<IEnumerable<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<TDto> Create(TDto dto);
        Task<TDto> Create(TDtoWithoutId dto);
        Task Update(TDto dto);
        Task Delete(int id);

        //NOTE Implement this method if we have Use cases that require it
        //? Task<IEnumerable<TDto>> GetByName(string name);
    }
}

