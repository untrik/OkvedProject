namespace MyProject.Entities;

public class Okved
{
    /// <summary>
    /// Уникальный код ОКВЭД.
    /// </summary>
    public string Code { get; }
    
    /// <summary>
    /// Название ОКВЭД.
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    ///  Код группы к которой относится ОКВЭД.
    /// </summary>
    public string CodeGroup { get; }
    
    public Okved(string name, string code,string codeGroup)
    {
        Name = name;
        Code = code;
        CodeGroup = codeGroup;
    }
}