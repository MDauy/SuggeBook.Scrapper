using AutoMapper;
using SuggeBook.Domain.Repositories;
using SuggeBookScrapper.Domain.Model;
using SuggeBookScrapper.Framework;
using SuggeBookScrapper.Infrastructure.Documents;

namespace SuggeBookScrapper.Infrastructure.Repositories
{
    public class MissedBookRepository : IMissedBookRepository
    {
        private readonly IBaseRepository<MissedBookDocument> _baseRepository;
        private IMapper _mapper;

        public MissedBookRepository(IBaseRepository<MissedBookDocument> baseRepository,
            IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<MissedBook> Register(MissedBook missedBook)
        {
            var missedBookDocument = _mapper.Map<MissedBookDocument>(missedBook);

            if (missedBookDocument != null)
            {
                missedBookDocument = await _baseRepository.Insert(missedBookDocument);

                return _mapper.Map<MissedBook>(missedBookDocument);
            }
            throw new System.Exception ("Something went wrong in mapping between MissedBook and MissedBookDocument");
        }
    }
}
