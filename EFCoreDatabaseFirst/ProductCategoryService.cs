using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreDatabaseFirst.Database;
using EFCoreDatabaseFirst.Database.AppDbContextModels;

namespace EFCoreDatabaseFirst
{

    public class ProductCategoryService
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
           
            var lst = db.TblProductCategories.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i].ProductCategoryId);
                Console.WriteLine(lst[i].ProductCategoryCode);
                Console.WriteLine(lst[i].ProductCategoryName);
            }
        }
        public void Create()
        {
            AppDbContext db = new AppDbContext();
            var item = new TblProductCategory()
            {
                ProductCategoryCode = "003",
                ProductCategoryName = "Test",
                DeleteFlag = false

            };

            db.TblProductCategories.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            AppDbContext db = new AppDbContext();
       
            var item = db.TblProductCategories.FirstOrDefault(x => x.ProductCategoryId == 3);
            if (item is null)
            {
                return;
            }

            item.ProductCategoryName = "Fresh Fruit";
            item.ModifiedDateTime = DateTime.Now;
            int result = db.SaveChanges();
            string message = result > 0 ? "Update Successful." : "Update Failed.";
            Console.WriteLine(message);
        }
        public void Delete()
        {
            AppDbContext db = new AppDbContext();

            var item = db.TblProductCategories.FirstOrDefault(x => x.ProductCategoryId == 3);
            if (item is null)
            {
                return;
            }
          
            item.DeleteFlag = true;
            int result = db.SaveChanges();
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            Console.WriteLine(message);

        }
    }
   
}
