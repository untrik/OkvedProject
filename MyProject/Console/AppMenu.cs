using MyProject.Services.Company;
using MyProject.Services.OkvedCatalogService;

namespace MyProject.Console;


public class AppMenu
{
    private readonly ICompanyService _companyService;
    private readonly IOkvedCatalogService _okvedCatalogService;

    public AppMenu(ICompanyService companyService, IOkvedCatalogService okvedCatalogService)
    {
        _companyService = companyService;
        _okvedCatalogService = okvedCatalogService;
    }
    public void Run()
    {
        while (true)
        {
            PrintMenu();
            var key = System.Console.ReadLine()?.Trim() ?? "";

            if (key == "0")
                break;
                switch (key)
                {
                    case "1": ShowAllSections(); break;
                    case "2": ShowGroupsBySection(); break;
                    case "3": ShowOkvedsByGroup(); break;
                    case "4": FindOkvedsByName(); break;
                    case "5": ShowTopCompaniesByCapital(); break;
                    case "6": ShowFractionActiveCompanies(); break;
                    case "7": ShowCompaniesInSection(); break;
                    case "8": ShowCompaniesInGroup(); break;
                    case "9": ShowAllCompanies(); break;
                    
                    default: System.Console.WriteLine("Неизвестный пункт меню."); break;
                }
            System.Console.WriteLine();
        }

        System.Console.WriteLine("Выход из программы.");
    }

    private void PrintMenu()
    {
        System.Console.WriteLine("--- Меню ---");
        System.Console.WriteLine("1 — Показать все секции ОКВЭД");
        System.Console.WriteLine("2 — Показать группы по секции");
        System.Console.WriteLine("3 — Показать ОКВЭДы по группе");
        System.Console.WriteLine("4 — Найти ОКВЭДы по названию");
        System.Console.WriteLine("5 — Топ-5 компаний по капиталу");
        System.Console.WriteLine("6 — Доля активных компаний");
        System.Console.WriteLine("7 — Компании по секции");
        System.Console.WriteLine("8 — Компании по группе");
        System.Console.WriteLine("9 — Показать все компании");
        System.Console.WriteLine("0 — Выход");
        System.Console.Write("Выбор: ");
    }

    private void ShowAllSections()
    {
        var sections = _okvedCatalogService.GetAllSections();

        System.Console.WriteLine("Секции ОКВЭД:");
        foreach (var section in sections)
          System.Console.WriteLine($"  {section.CodeSection} - {section.NameSection}");

        if (sections.Count == 0)
            System.Console.WriteLine("  Список пуст.");
    }

    private void ShowGroupsBySection()
    {
        System.Console.Write("Введите код секции: ");
        var sectionCode = System.Console.ReadLine()?.Trim() ?? "";

        var groups = _okvedCatalogService.GetGroupsBySection(sectionCode);

        System.Console.WriteLine($"Группы секции {sectionCode}:");
        foreach (var group in groups)
          System.Console.WriteLine($"  {group.CodeGroup} - {group.NameGroup}");

        if (groups.Count == 0)
           System.Console.WriteLine("  Ничего не найдено.");
    }

    private void ShowOkvedsByGroup()
    {
        System.Console.Write("Введите код группы: ");
        var groupCode = System.Console.ReadLine()?.Trim() ?? "";

        var okveds = _okvedCatalogService.GetOkvedsByGroup(groupCode);

       System.Console.WriteLine($"ОКВЭДы группы {groupCode}:");
        foreach (var okved in okveds)
            System.Console.WriteLine($"  {okved.Code} - {okved.Name}");

        if (okveds.Count == 0)
            System.Console.WriteLine("  Ничего не найдено.");
    }

    private void FindOkvedsByName()
    {
        System.Console.Write("Введите часть названия ОКВЭД: ");
        var namePart = System.Console.ReadLine()?.Trim() ?? "";

        var okveds = _okvedCatalogService.FindOkvedsByName(namePart);

        System.Console.WriteLine("Результаты поиска:");
        foreach (var okved in okveds)
            System.Console.WriteLine($"  {okved.Code} - {okved.Name} (группа {okved.CodeGroup})");

        if (okveds.Count == 0)
            System.Console.WriteLine("  Ничего не найдено.");
    }

    private void ShowTopCompaniesByCapital()
    {
        var companies = _companyService.TopCompaniesForCapitalM();

        System.Console.WriteLine("Топ-5 компаний по капиталу:");
        foreach (var company in companies)
        {
            System.Console.WriteLine(
                $"  #{company.Id} | {company.Title} | капитал: {company.CapitalM} | статус: {company.Status} | основной ОКВЭД: {company.MainOKVEDCode}");
        }

        if (companies.Count == 0)
            System.Console.WriteLine("  Компании не найдены.");
    }

    private void ShowFractionActiveCompanies()
    {
        var fraction = _companyService.FractionActiveCompanies();
        System.Console.WriteLine($"Доля активных компаний: {fraction:F2}");
    }

    private void ShowCompaniesInSection()
    {
        System.Console.Write("Введите код секции: ");
        var sectionCode = System.Console.ReadLine()?.Trim() ?? "";

        var companies = _companyService.CompaniesInSection(sectionCode);

        System.Console.WriteLine($"Компании секции {sectionCode}:");
        foreach (var company in companies)
        {
            System.Console.WriteLine(
                $"  #{company.Id} | {company.Title} | капитал: {company.CapitalM} | основной ОКВЭД: {company.MainOKVEDCode}");
        }

        if (companies.Count == 0)
            System.Console.WriteLine("  Компании не найдены.");
    }

    private void ShowCompaniesInGroup()
    {
        System.Console.Write("Введите код группы: ");
        var groupCode = System.Console.ReadLine()?.Trim() ?? "";

        var companies = _companyService.CompaniesInGroup(groupCode);

        System.Console.WriteLine($"Компании группы {groupCode}:");
        foreach (var company in companies)
        {
            System.Console.WriteLine(
                $"  #{company.Id} | {company.Title} | капитал: {company.CapitalM} | основной ОКВЭД: {company.MainOKVEDCode}");
        }

        if (companies.Count == 0)
            System.Console.WriteLine("  Компании не найдены.");
    }

    private void ShowAllCompanies()
    {
        var companies = _companyService.GetAllCompanies();

        System.Console.WriteLine("Все компании:");
        foreach (var company in companies)
        {
            System.Console.WriteLine(
                $"  #{company.Id} | {company.Title} | ИНН: {company.Inn} | капитал: {company.CapitalM} | статус: {company.Status} | основной ОКВЭД: {company.MainOKVEDCode}");
        }

        if (companies.Count == 0)
            System.Console.WriteLine("  Список пуст.");
    }
}