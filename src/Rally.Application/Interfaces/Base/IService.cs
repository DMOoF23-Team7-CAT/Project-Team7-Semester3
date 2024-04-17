using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;

namespace Rally.Application.Interfaces.Base
{
    public interface IService<TDto> where TDto : BaseDto
    {
        Task<IEnumerable<TDto>> GetList();
        Task<TDto> GetById(int id);
        Task<TDto> Create(TDto dto);
        Task Update(TDto dto);
        Task Delete(TDto dto);

        //NOTE Implement this method if we have Use cases that require it
        // Task<IEnumerable<TDto>> GetByName(string name);
    }
}

