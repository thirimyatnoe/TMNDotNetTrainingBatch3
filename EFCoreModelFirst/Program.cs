// See https://aka.ms/new-console-template for more information
using EFCoreModelFirst;

Console.WriteLine("Hello, EFCore model first!");
ProductEFCoreService productEFCoreService = new ProductEFCoreService();
//productEFCoreService.Read();
//productEFCoreService.Create();
//productEFCoreService.Update();
productEFCoreService.Delete();

