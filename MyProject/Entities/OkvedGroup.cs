namespace MyProject.Entities;

public class OkvedGroup
{
    /// <summary>
    /// Уникальный идентификатор групп ОКВЭДов.
    /// </summary>
    public string CodeGroup{get;}
    /// <summary>
    /// Название группы ОКВЭДов.
    /// </summary>
    public string NameGroup{get;}
    /// <summary>
    ///  Код секции к которой относится группа.
    /// </summary>
    public string SectionCode { get; }
    
    public OkvedGroup(string codeGroup, string nameGroup, string sectionCode)
    {
        
        CodeGroup = codeGroup;
        NameGroup = nameGroup;
        SectionCode = sectionCode;
    }
}