using MyProject.Entities;
using MyProject.Repositories.Okved;

namespace MyProject.Services.OkvedCatalogService;

public class OkvedCatalogService : IOkvedCatalogService
{
    private readonly IOkvedRepository _okvedRepository;
    private readonly Repositories.OkvedGroup.IOkvedGroupRepository _okvedGroupRepository;
    private readonly Repositories.OkvedSection.IOkvedSectionRepository _okvedSectionRepository;

    public OkvedCatalogService(IOkvedRepository okvedRepository,Repositories.OkvedGroup.IOkvedGroupRepository okvedGroupRepository,
        Repositories.OkvedSection.IOkvedSectionRepository okvedSectionRepository)
    {
        _okvedRepository = okvedRepository;
        _okvedGroupRepository = okvedGroupRepository;
        _okvedSectionRepository = okvedSectionRepository;
    }
    
    public void AddSection(string codeSection, string nameSection)=> _okvedSectionRepository.Add(new OkvedSection(codeSection, nameSection));
    
    public void AddGroup(string codeGroup, string nameGroup, string sectionCode)=> _okvedGroupRepository.Add(new OkvedGroup(codeGroup, nameGroup, sectionCode));

    public void AddOkved(string name, string code, string codeGroup) => _okvedRepository.Add(new Okved(name, code, codeGroup));

    public IReadOnlyList<OkvedSection> GetAllSections()=>_okvedSectionRepository.GetAll();

    public IReadOnlyList<OkvedGroup> GetGroupsBySection(string sectionCode) =>
    _okvedGroupRepository.GetAll().Where(g => g.SectionCode == sectionCode).ToList();

    public IReadOnlyList<Okved> GetOkvedsByGroup(string groupCode) =>
        _okvedRepository.GetAll().Where(o => o.CodeGroup == groupCode).ToList();

    public IReadOnlyList<Okved> FindOkvedsByName(string namePart)=> _okvedRepository.GetAll()
        .Where(o => o.Name.Contains(namePart, StringComparison.OrdinalIgnoreCase))
        .ToList();

    public Okved? GetOkvedByCode(string code)=> _okvedRepository.GetByCode(code);
}