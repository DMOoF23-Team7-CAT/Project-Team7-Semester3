using FluentValidation;
using Rally.Application.Dto.Sign;
using Rally.Application.Dto.SignBase;
using Rally.Application.Exceptions;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Validators;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class SignService : ISignService
    {
        private readonly ISignRepository _signRepository;
        public SignService(ISignRepository signRepository)
        {
            _signRepository = signRepository ?? throw new ArgumentNullException(nameof(signRepository));
        }

        public async Task<IEnumerable<SignDto>> GetAll()
        {
            var signs = await _signRepository.GetAllAsync();
            if (signs is null)
                throw new NotFoundException("Signs could not be found.");

            var mappedSigns = ObjectMapper.Mapper.Map<IEnumerable<SignDto>>(signs);
            if (mappedSigns is null)
                throw new MappingException("Signs could not be mapped.");

            return mappedSigns;
        }

        public async Task<SignDto> GetById(int id)
        {
            var sign = await _signRepository.GetByIdAsync(id);
            if (sign is null)
                throw new NotFoundException("Sign could not be found.");

            var mappedSign = ObjectMapper.Mapper.Map<SignDto>(sign);
            if (mappedSign is null)
                throw new MappingException("Sign could not be mapped.");

            return mappedSign;
        }

        public async Task<SignDto> Create(SignWithoutIdDto dto)
        {
            var sign = ObjectMapper.Mapper.Map<Sign>(dto);
            if (sign is null)
                throw new MappingException("Sign could not be mapped.");

            var validator = new SignValidator();
            var validationResult = await validator.ValidateAsync(sign);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _signRepository.AddAsync(sign);

            var newSign = ObjectMapper.Mapper.Map<SignDto>(sign);
            if(newSign is null)
                throw new MappingException("Sign could not be mapped.");

            return newSign;
        }

        public async Task Delete(int id)
        {
            var sign = await _signRepository.GetByIdAsync(id);
            if (sign is null)
                throw new NotFoundException("Sign could not be found.");

            await _signRepository.DeleteAsync(sign);
        }

        public async Task Update(SignDto dto)
        {
            var oldSign = await _signRepository.GetByIdAsync(dto.Id);
            if (oldSign is null)
                throw new NotFoundException("Sign could not be found.");

            var sign = ObjectMapper.Mapper.Map<Sign>(dto);
            if (sign is null)
                throw new MappingException("Sign could not be mapped.");

            var validator = new SignValidator();
            var validationResult = await validator.ValidateAsync(sign);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _signRepository.UpdateAsync(ObjectMapper.Mapper.Map(dto, oldSign));
        }

        public async Task<SignWithSignBaseDto> GetSignWithSignBases(int signId)
        {
            var sign = await _signRepository.GetSignWithSignBasesAsync(signId);

            var mappedSign = ObjectMapper.Mapper.Map<SignWithSignBaseDto>(sign);
            if (mappedSign is null)
                throw new MappingException("Sign with SignBases could not be mapped");

            return mappedSign;
        }

    }
}

