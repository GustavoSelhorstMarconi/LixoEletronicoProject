using LixoEletronico.Domain.Contracts;
using LixoEletronico.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LixoEletronico.Infra.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly Context _context;

        public ReviewRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetReviewsByCompanyId(List<int> idsCompanies)
        {
            List<Review> reviews = await _context.Reviews
                .Where(x => idsCompanies.Contains(x.CompanyId))
                .ToListAsync();

            return reviews;
        }
    }
}
