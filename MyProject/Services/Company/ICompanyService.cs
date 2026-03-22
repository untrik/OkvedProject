namespace MyProject.Services.Company;

public interface ICompanyService
{
    public void AddCompany(int id, double capitalM, string title, string inn, string websiteURL, string phoneNumber,
        string email);

    public double FractionActiveCompanies();
    public IReadOnlyList<Entities.Company> TopCompaniesForCapitalM();
    public IReadOnlyList<Entities.Company> CompaniesInSection(string sectionCode);
    public IReadOnlyList<Entities.Company> CompaniesInGroup(string groupCode);
    public void SetMainOkved(int companyId, string okvedCode);
    public void AddAdditionalOkved(int companyId, string okvedCode);
    public IReadOnlyList<Entities.Company> GetAllCompanies();




}