namespace MyProject.Repositories.OkvedGroup;

public interface IOkvedGroupRepository
{
    void Add(Entities.OkvedGroup okvedGroup);
    IReadOnlyList<Entities.OkvedGroup> GetAll();
    Entities.OkvedGroup? GetByCode(string code);
}