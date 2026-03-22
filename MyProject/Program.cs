// See https://aka.ms/new-console-template for more information

using MyProject.Console;
using MyProject.Repositories;
using MyProject.Entities;
using MyProject.Repositories.Company;
using MyProject.Repositories.Okved;
using MyProject.Repositories.OkvedGroup;
using MyProject.Repositories.OkvedSection;
using MyProject.Services.Company;
using MyProject.Services.OkvedCatalogService;

var companyRepo = new CompanyRepository();
var okvedRepo = new OkvedRepository();
var okvedGroupRepo = new OkvedGroupRepository();
var okvedSectionRepo = new OkvedSectionRepository();

ICompanyService companyService = new CompanyService(companyRepo, okvedRepo, okvedGroupRepo);
IOkvedCatalogService okvedCatalogService = new OkvedCatalogService(okvedRepo,okvedGroupRepo,okvedSectionRepo);

SeedData(companyService, okvedCatalogService);

var menu = new AppMenu(companyService, okvedCatalogService);
menu.Run();

static void SeedData(ICompanyService companyService, IOkvedCatalogService okvedCatalogService)
{
    okvedCatalogService.AddSection("A", "Сельское хозяйство");
    okvedCatalogService.AddSection("B", "Добыча полезных ископаемых");
    
    okvedCatalogService.AddGroup("01", "Растениеводство", "A");
    okvedCatalogService.AddGroup("02", "Животноводство", "A");
    okvedCatalogService.AddGroup("05", "Добыча угля", "B");
    
    okvedCatalogService.AddOkved("Выращивание зерновых", "01.11", "01");
    okvedCatalogService.AddOkved("Выращивание овощей", "01.13", "01");
    okvedCatalogService.AddOkved("Разведение крупного рогатого скота", "02.10", "02");
    okvedCatalogService.AddOkved("Добыча каменного угля", "05.10", "05");
    
    companyService.AddCompany(1, 500, "AgroTech", "123456789012", "agro.ru", "89991112233", "info@agro.ru");
    companyService.AddCompany(2, 1500, "GreenFarm", "123456789013", "green.ru", "89992223344", "contact@green.ru");
    companyService.AddCompany(3, 3000, "CoalEnergy", "123456789014", "coal.ru", "89993334455", "coal@energy.ru");
    companyService.AddCompany(4, 200, "SmallFarm", "123456789015", "", "", "farm@mail.ru");
    
    companyService.SetMainOkved(1, "01.11"); 
    companyService.SetMainOkved(2, "01.13"); 
    companyService.SetMainOkved(3, "05.10"); 
    companyService.SetMainOkved(4, "02.10"); 
    
    companyService.AddAdditionalOkved(1, "01.13");
    companyService.AddAdditionalOkved(2, "02.10");
    companyService.AddAdditionalOkved(3, "01.11");
    
    companyService.GetAllCompanies().First(c => c.Id == 4).Status = Status.Liquidated;
}