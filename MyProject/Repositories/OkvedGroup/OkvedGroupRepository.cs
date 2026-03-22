namespace MyProject.Repositories.OkvedGroup;

public class OkvedGroupRepository : IOkvedGroupRepository
{
    private readonly Dictionary<string, Entities.OkvedGroup> _okvedGroups = [];

    public void Add(Entities.OkvedGroup okvedGroup) => _okvedGroups[okvedGroup.CodeGroup] = okvedGroup;

    public IReadOnlyList<Entities.OkvedGroup> GetAll() => _okvedGroups.Values.ToList();

    public Entities.OkvedGroup? GetByCode(string code) =>
        _okvedGroups.TryGetValue(code, out var okvedGroup) ? okvedGroup : null;
    public bool Exists(string code) => _okvedGroups.ContainsKey(code);
}
    