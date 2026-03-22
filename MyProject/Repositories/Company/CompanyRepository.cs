namespace MyProject.Repositories.Company;

public class CompanyRepository : ICompanyRepository
{
    private readonly Dictionary<int, Entities.Company> _companies = [];

    public void Add(Entities.Company company) => _companies[company.Id] = company;

    public IReadOnlyList<Entities.Company> GetAll() => _companies.Values.ToList();

    public Entities.Company? GetById(int id) =>
        _companies.TryGetValue(id, out var company) ? company : null;
    
}