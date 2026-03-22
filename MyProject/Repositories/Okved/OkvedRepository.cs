namespace MyProject.Repositories.Okved;

public class OkvedRepository : IOkvedRepository
{
    private readonly Dictionary<string, Entities.Okved> _okveds = [];

    public void Add(Entities.Okved okved) => _okveds[okved.Code] = okved;

    public IReadOnlyList<Entities.Okved> GetAll() => _okveds.Values.ToList();

    public Entities.Okved? GetByCode(string code) =>
        _okveds.TryGetValue(code, out var okved) ? okved : null;
}