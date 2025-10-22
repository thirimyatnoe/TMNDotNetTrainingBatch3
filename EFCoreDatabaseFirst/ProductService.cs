using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDatabaseFirst.Database;
using EFCoreDatabaseFirst.Database.AppDbContextModels;

namespace EFCoreDatabaseFirst
{

    public class ProductService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
           
            var lst = db.TblProducts.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lst.Count; i++)
            {
                
                Console.WriteLine(lst[i].ProductName);
                Console.WriteLine(lst[i].Price);
            }
        }
        public void Create()
        {
            AppDbContext db = new AppDbContext();
            var item = new TblProduct()
            {
                ProductName = "Test",
                DeleteFlag = false,
                CreatedDateTime= DateTime.Now,
                ModifiedDateTime= DateTime.Now,

            };

            db.TblProducts.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Save Product Successful." : "Save Product Failed.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            AppDbContext db = new AppDbContext();
       
            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == 3);
            if (item is null)
            {
                return;
            }

            item.ProductName = "Fresh Fruit";
            item.ModifiedDateTime = DateTime.Now;
            int result = db.SaveChanges();
            string message = result > 0 ? "Update Product Successful." : "Update Failed.";
            Console.WriteLine(message);
        }
        public void Delete()
        {
            AppDbContext db = new AppDbContext();

            var item = db.TblProducts.FirstOrDefault(x => x.ProductId == 3);
            if (item is null)
            {
                return;
            }
          
            item.DeleteFlag = true;
            int result = db.SaveChanges();
            string message = result > 0 ? "Delete Product Successful." : "Delete Failed.";
            Console.WriteLine(message);

        }
    }
   
}
