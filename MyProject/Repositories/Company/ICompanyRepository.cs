namespace MyProject.Repositories.Company;

public interface ICompanyRepository
{
    void Add(Entities.Company company);
    IReadOnlyList<Entities.Company> GetAll();
    Entities.Company? GetById(int id);
}