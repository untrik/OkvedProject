using MyProject.Repositories.Okved;
using MyProject.Repositories.OkvedGroup;

namespace MyProject.Services.Company;

public class CompanyService : ICompanyService
{
    private  readonly Repositories.Company.ICompanyRepository _companyRepository;
    private readonly IOkvedRepository _okvedRepository;
    private readonly IOkvedGroupRepository _okvedGroupRepository;
    
    public CompanyService(Repositories.Company.ICompanyRepository  companyRepository,
        IOkvedRepository okvedRepository, IOkvedGroupRepository okvedGroupRepository)
    {
        _companyRepository = companyRepository;
        _okvedRepository = okvedRepository;
        _okvedGroupRepository = okvedGroupRepository;
    }
    public void AddCompany(int id, double capitalM, string title, string inn, string websiteURL, string phoneNumber,
        string email)
    {
        _companyRepository.Add(new Entities.Company(id, capitalM, title, inn, websiteURL, phoneNumber, email));
    }
    public void SetMainOkved(int companyId, string okvedCode)
    {
        var company = _companyRepository.GetById(companyId);
        var okved = _okvedRepository.GetByCode(okvedCode);

        company.MainOKVEDCode = okved.Code;
    }

    public void AddAdditionalOkved(int companyId, string okvedCode)
    {
        var company = _companyRepository.GetById(companyId);

        var okved = _okvedRepository.GetByCode(okvedCode);

        company.AddAdditionalOkved(okved.Name, okved.Code, okved.CodeGroup);
    }
    public double FractionActiveCompanies() =>
        _companyRepository.GetAll().Count(c => c.Status == Entities.Status.Active) /(double) _companyRepository.GetAll().Count();
    
    public IReadOnlyList<Entities.Company> TopCompaniesForCapitalM() =>
     _companyRepository.GetAll().OrderByDescending(c => c.CapitalM).Take(5).ToList();
    
    public IReadOnlyList<Entities.Company> CompaniesInSection(string sectionCode) =>
    _companyRepository.GetAll().Where(c => 
        _okvedGroupRepository.GetByCode(_okvedRepository.GetByCode(c.MainOKVEDCode).CodeGroup).SectionCode == sectionCode).ToList();
    
    public IReadOnlyList<Entities.Company> CompaniesInGroup(string groupCode) =>
        _companyRepository.GetAll().Where(c =>
            _okvedRepository.GetByCode(c.MainOKVEDCode).CodeGroup == groupCode).ToList();
   public  IReadOnlyList<Entities.Company> GetAllCompanies() => _companyRepository.GetAll();
}
