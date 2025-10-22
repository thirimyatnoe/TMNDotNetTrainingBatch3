// See https://aka.ms/new-console-template for more information
using DapperService;

Console.WriteLine("Hello,Product Dapper Service!");
ProductDapperService productService = new ProductDapperService();

//productService.Create();
//productService.Update();
//productService.Delete();
productService.Read();
SaleDapperService saleService = new SaleDapperService();

//saleService.Create();

saleService.Read();
Console.ReadLine();