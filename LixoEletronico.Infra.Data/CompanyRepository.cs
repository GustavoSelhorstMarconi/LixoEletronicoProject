using LixoEletronico.Domain.Contracts;
using LixoEletronico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
                .Include(x => x.Representant)
                .Include(x => x.Address)
                .Include(x => x.Reviews)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (company == null)
            {
                throw new ApplicationException("Compania não encontrada.");
            }

            return company;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            List<Company>? companies = await _context.Companies
                .Include(x => x.Representant)
                .Include(x => x.Address)
                .AsNoTracking()
                .ToListAsync();

            if (companies == null)
            {
                throw new ApplicationException("Companias não encontradas.");
            }

            return companies;
        }
    }
}
