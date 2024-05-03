using Rally.Core.Repositories.Base;
using Rally.Application.Dto.Sign;
using Rally.Application.Dto.SignBase;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Services.Base;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class SignService : Service<SignDto, Sign, SignWithoutIdDto>, ISignService
    {
        private readonly ISignRepository _signRepository;
        public SignService(IRepository<Sign> repository, ISignRepository signRepository) : base(repository)
        {
            _signRepository = signRepository ?? throw new ArgumentNullException(nameof(signRepository));
        }



        public async Task<SignWithSignBaseDto> GetSignWithSignBases(int signId)
        {
            var sign = await _signRepository.GetSignWithSignBasesAsync(signId);

            var mappedSign = ObjectMapper.Mapper.Map<SignWithSignBaseDto>(sign);
            if (mappedSign is null)
                throw new ApplicationException("Sign with SignBases could not be mapped");

            return mappedSign;
        }

        //REVIEW - This method is for testing purposes only. It should be deleted in the future.
        public Task<SignWithSignBaseDto> CreateSignWithSignBase(SignWithSignBaseDto signDto, int signBaseId)
        {
            throw new NotImplementedException();
        }
        // public async Task<SignWithSignBaseDto> CreateSignWithSignBase(SignWithSignBaseDto signDto, int signBaseId)
        // {
        //     if (signDto.SignBase == null)
        //         signDto.SignBase = new SignBaseDto();

        //     signDto.SignBase.Id = signBaseId;

        //     var signEntity = ObjectMapper.Mapper.Map<Sign>(signDto);
        //     if (signEntity is null)
        //         throw new ApplicationException("Sign with sign base could not be mapped");

        //     await _signRepository.Create(signEntity);

        //     var mappedSign = ObjectMapper.Mapper.Map<SignWithSignBaseDto>(signEntity);
        //     if (mappedSign is null)
        //         throw new ApplicationException("Sign with sign base could not be mapped");

        //     return mappedSign;
        // }
        //REVIEW - 

        // public async Task<SignDto> GetSignWithTrack(int signId)
        // {
        //     var sign = await _signRepository.GetSignWithTrackAsync(signId);

        //     var mappedSign = ObjectMapper.Mapper.Map<SignDto>(sign);
        //     if (mappedSign is null)
        //         throw new ApplicationException("Sign with track could not be mapped");

        //     return mappedSign;
        // }
    }
}

