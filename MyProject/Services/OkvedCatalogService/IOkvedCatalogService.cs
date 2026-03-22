namespace MyProject.Services.OkvedCatalogService;

public interface IOkvedCatalogService
{
    public void AddSection(string codeSection, string nameSection);
    public void AddGroup(string codeGroup, string nameGroup, string sectionCode);
    public void AddOkved(string name, string code, string codeGroup);

    public IReadOnlyList<Entities.OkvedSection> GetAllSections();
    public IReadOnlyList<Entities.OkvedGroup> GetGroupsBySection(string sectionCode);
    public IReadOnlyList<Entities.Okved> GetOkvedsByGroup(string groupCode);
    public IReadOnlyList<Entities.Okved> FindOkvedsByName(string namePart);
    public Entities.Okved? GetOkvedByCode(string code);
}