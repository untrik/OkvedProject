namespace MyProject.Repositories.Okved;

public interface IOkvedRepository
{
    void Add(Entities.Okved okved);
    IReadOnlyList<Entities.Okved> GetAll();
    Entities.Okved? GetByCode(string code);
}