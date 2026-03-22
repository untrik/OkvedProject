namespace MyProject.Repositories.OkvedSection;

public class OkvedSectionRepository : IOkvedSectionRepository{
private readonly Dictionary<string, Entities.OkvedSection> _okvedSections = [];
    public void Add(Entities.OkvedSection okvedSection) => _okvedSections[okvedSection.CodeSection] = okvedSection;    
    public IReadOnlyList<Entities.OkvedSection> GetAll()=> _okvedSections.Values.ToList();
    public Entities.OkvedSection? GetByCode(string code) => _okvedSections.TryGetValue(code, out var okvedSection) ? okvedSection : null;
}
