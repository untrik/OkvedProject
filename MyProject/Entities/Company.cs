namespace MyProject.Entities;

public class Company
{
    /// <summary>
    /// Уникальный идентификатор компании.
    /// </summary>
    public int Id { get; }
    /// <summary>
    ///  Капитал компании в миллионах у.е.
    /// </summary>
    public double CapitalM { get; set; }
    /// <summary>
    /// Название компании.
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// ИНН компании (состоит из 12 цифр)
    /// </summary>
    public string Inn { get; }
    /// <summary>
    /// URL сайта компании.
    /// </summary>
    public string WebsiteURL { get; set; } = "";

    /// <summary>
    /// Номер телефона компании.
    /// </summary>
    public string PhoneNumber { get; set; } = "";

    /// <summary>
    /// Электронная почта компании.
    /// </summary>
    public string Email { get; set; } = "";

    /// <summary>
    /// Статус компании.
    /// </summary>
    public Status Status{ get; set; }

    /// <summary>
    /// Основной ОКВЭД компании
    /// </summary>
    public string MainOKVEDCode{ get; set; }

    private readonly List<Okved> _additionalOkveds = new();
    /// <summary>
    /// Дополнительные ОКВЭДы компании
    /// </summary>
    public IReadOnlyCollection<Okved> AdditionalOkveds => _additionalOkveds;
    
    public Company(int id, double capitalM ,string title,string inn, string websiteURL, string phoneNumber, string email)
    {
      Id = id;
      CapitalM = capitalM;
      Title = title;
      Inn = inn;
      WebsiteURL = websiteURL;
      PhoneNumber = phoneNumber;
      Email = email;
      Status = Status.Active;
    }
    
    public void AddAdditionalOkved(string name, string code, string codeGroup)
    {
        _additionalOkveds.Add(new Okved(name, code, codeGroup));
    }

    public void RemoveAdditionalOkved(string code)
    {
        var okved = _additionalOkveds.FirstOrDefault(o => o.Code == code);
        if (okved != null)
            _additionalOkveds.Remove(okved);
    }
}