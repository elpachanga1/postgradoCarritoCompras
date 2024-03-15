using AutoMapper;
using DataRepository.Repositories;

namespace Services.Domain.Services
{
    public class SessionService
    {
        private readonly IMapper _mapper;
        private IRepository<DataRepository.Models.Session> _sessionRepository;

        public SessionService(
            IMapper mapper,
            IRepository<DataRepository.Models.Session> sessionRepository)
        {
            _mapper = mapper;
            _sessionRepository = sessionRepository;
        }

        public async Task<Models.Session> AddSession(Models.User user)
        {
            Models.Session sessionDomainEntity = new Models.Session
            {
                UserId = user.Id,
                SessionStart = DateTime.Now,
                SessionEnd = DateTime.Now.AddMinutes(5),
            };

            DataRepository.Models.Session sessionDataEntity = _mapper.Map<DataRepository.Models.Session>(sessionDomainEntity);
            await _sessionRepository.AddAsync(sessionDataEntity);
            await _sessionRepository.SaveAsync();

            return sessionDomainEntity;
        }
    }
}
