using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDatabaseFirst.Database;
using EFCoreDatabaseFirst.Database.AppDbContextModels;

namespace EFCoreDatabaseFirst
{

    public class SaleService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();


            List<TblSale> lst = db.TblSales.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lst.Count; i++)
            {

                Console.WriteLine(lst[i].SaleId);
                Console.WriteLine(lst[i].ProductId);
                Console.WriteLine(lst[i].Price);
            }
        }
        public void Create()
        {
            AppDbContext db = new AppDbContext();
            var item = new TblSale()
            {
                ProductId = 1,
                Price = 700,
                Quantity = 2,
                DeleteFlag = false,
                CreatedDateTime = DateTime.Now,
                ModifiedDateTime = DateTime.Now,

            };

            db.TblSales.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Save Sale Successful." : "Save Sale Failed.";
            Console.WriteLine(message);
        }

    } 
}
