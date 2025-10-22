// See https://aka.ms/new-console-template for more information
using ADONet;

Console.WriteLine("Hello, World!");
ProductService productService = new ProductService();
productService.Read();
//productService.Create();
//productService.Update();
//productService.Delete();

SaleService saleService = new SaleService();
saleService.Read();
//saleService.Create();


Console.ReadLine();
