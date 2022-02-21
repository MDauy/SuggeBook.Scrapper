using AutoMapper;
using SuggeBook.Domain.Repositories;
using SuggeBookScrapper.Domain.Model;
using SuggeBookScrapper.Framework;
using SuggeBookScrapper.Infrastructure.Documents;

namespace SuggeBookScrapper.Infrastructure.Repositories
{
    public class MissedAuthorRepository : IMissedAuthorRepository
    {
        private IBaseRepository<MissedAuthorDocument> _baseRepository;
        private IMapper _mapper;
        public MissedAuthorRepository(IBaseRepository<MissedAuthorDocument> baseRepository,
            IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<MissedAuthor> Register(MissedAuthor missedAuthor)
        {
            var missedAuthorDocument = _mapper.Map<MissedAuthorDocument>(missedAuthor);

            missedAuthorDocument = await _baseRepository.Insert(missedAuthorDocument);

            return _mapper.Map<MissedAuthor>(missedAuthorDocument);
        }
    }
}
