using LixoEletronico.Domain.Contracts;
using LixoEletronico.Domain.Entities;
using LixoEletronico.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace LixoEletronico.Infra.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly Context _context;
        private const double _earthRadius = 6.371;

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
                .ThenInclude(x => x.Person)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (company == null)
            {
                throw new ApplicationException("Compania não encontrada.");
            }

            return company;
        }

        public async Task<List<CompanyDto>> GetAllCompanies(FilterCompanySearchDto filter)
        {
            Point locationBase = new Point(filter.LongitudeBase, filter.LatitudeBase)
            {
                SRID = 4326
            };

            IQueryable<Company> companies = _context.Companies
                .Include(x => x.Representant)
                .Include(x => x.Address)
                .AsNoTracking();

            var companiesDto = await FilterCompanies(companies, filter, locationBase)
                .Select(x => new CompanyDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Representant = new()
                    {
                        Name = x.Representant.Name,
                        Email = x.Representant.Email,
                        IsRepresentant = x.Representant.IsRepresentant
                    },
                    Address = new()
                    {
                        Number = x.Address.Number,
                        Street = x.Address.Street,
                        City = x.Address.City,
                        District = x.Address.District,
                        Country = x.Address.Country,
                        Latitude = x.Address.Location.Y,
                        Longitude = x.Address.Location.X
                    },
                    Distance = x.Address.Location.Distance(locationBase) / 1000,
                    LogoRetorno = x.Logo != null ? Convert.ToBase64String(x.Logo) : string.Empty
                })
                .OrderBy(x => x.Distance)
                .ToListAsync();

            if (companiesDto == null)
            {
                throw new ApplicationException("Companias não encontradas.");
            }

            return companiesDto;
        }

        private IQueryable<Company> FilterCompanies(IQueryable<Company> companies, FilterCompanySearchDto filter, Point locationBase)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                companies = companies
                    .Where(x => (x.Name + x.Address.Street + x.Address.District + x.Address.City + x.Address.State + x.Address.Country).Contains(filter.Name));
            }

            if (filter.MinDistance is not null && filter.MinDistance > 0)
            {
                companies = companies
                    .Where(x => x.Address.Location.Distance(locationBase) / 1000 >= filter.MinDistance);
            }

            if (filter.MaxDistance is not null && filter.MaxDistance > 0)
            {
                companies = companies
                    .Where(x => x.Address.Location.Distance(locationBase) / 1000 <= filter.MaxDistance);
            }

            return companies;
        }
    }
}
