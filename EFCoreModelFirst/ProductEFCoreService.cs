using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreModelFirst
{
    public class ProductEFCoreService
    {
       // private readonly AppDbContext _db;
        public ProductEFCoreService()
        { 
          //  _db= new AppDbContext();
        }
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Products.Where(x => x.DeleteFlag==false).ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i].ProductId);
                Console.WriteLine(lst[i].ProductName);
            }
        }

        public void Create()
        {
            AppDbContext db = new AppDbContext();
            var item = new tbl_Product()
            {
                ProductName = "mango",
                Price = 1000,
                Quantity=20,
                CreatedDateTime=DateTime.Now,
                DeleteFlag=false,
            };
            db.Products.Add(item);
            int result= db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            AppDbContext db = new AppDbContext();
            //var item= db.Products.Where(x => x.ProductId == 9).FirstOrDefault();
            var item = db.Products.FirstOrDefault(x => x.ProductId == 9);
            if (item is null)
            {
                return;
            }
            item.ProductName = "apple";
            item.ModifiedDateTime = DateTime.Now;
            int result = db.SaveChanges();
            string message = result > 0 ? "Update Successful." : "Update Failed.";
            Console.WriteLine(message);
        }
        public void Delete()
        {
            AppDbContext db = new AppDbContext();

            var item = db.Products.FirstOrDefault(x => x.ProductId == 10);
            if (item is null)
            {
                return;
            }
            //db.Remove(item);
            item.DeleteFlag = true;
            int result = db.SaveChanges();
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            Console.WriteLine(message);

        }

    }
}
