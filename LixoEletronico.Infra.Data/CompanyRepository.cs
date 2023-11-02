using LixoEletronico.Domain.Contracts;
using LixoEletronico.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LixoEletronico.Infra.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly Context _context;

        public CompanyRepository(Context context)
        {
            _context = context;
        }

        public async Task UpdateCompany(int id, Company company)
        {
            Company? companyToUpdate = await _context.Companies
                .SingleOrDefaultAsync(x => x.Id == id);

            if (companyToUpdate == null)
            {
                throw new ApplicationException("Compania não encontrada.");
            }

            companyToUpdate.UpdateCompany(company);

            await _context.SaveChangesAsync();
        }

        public async Task<Company> GetCompany(int id)
        {
            Company? company = await _context.Companies
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            if (company == null)
            {
                throw new ApplicationException("Compania não encontrada.");
            }

            return company;
        }
    }
}
