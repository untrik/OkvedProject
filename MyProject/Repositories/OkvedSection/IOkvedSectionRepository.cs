namespace MyProject.Repositories.OkvedSection;

public interface IOkvedSectionRepository
{
    void Add(Entities.OkvedSection okvedSection);
    IReadOnlyList<Entities.OkvedSection> GetAll();
   Entities.OkvedSection? GetByCode(string code);
}