namespace MyProject.Entities;

public class OkvedSection
{ 
  /// <summary>
  /// Уникальный идентификатор секции ОКВЭДов.
  /// </summary>
    public string CodeSection{get;}
  /// <summary>
  /// Название секции ОКВЭДов.
  /// </summary>
    public string NameSection{get;}

    public OkvedSection(string codeSection, string nameSection)
    {
        CodeSection = codeSection;
        NameSection = nameSection;
    }
}