// See https://aka.ms/new-console-template for more information
using DapperService;

Console.WriteLine("Hello,Product Dapper Service!");
ProductDapperService productService = new ProductDapperService();
//productService.Read();
//productService.Create();
//productService.Update();
productService.Delete();