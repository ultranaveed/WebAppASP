using System;
using System.Data.Common;
using System.Linq.Expressions;
using WebApp.DataAccess.Data;
using WebApp.DataAccess.Repository.Irepository;
using WebApp.Models;

namespace WebApp.DataAccess.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
	private ApplicationDbContext _db;
	public ProductRepository(ApplicationDbContext db): base (db)
	{
		_db=db;
	}


	public void Update(Product obj){
		var objFromDb = _db.Products.FirstOrDefault(u=>u.Id == obj.Id);
		if (objFromDb != null){
			objFromDb.Title = obj.Title;
			objFromDb.ISBN = obj.ISBN;
			objFromDb.Price = obj.Price;
			objFromDb.Price50 = obj.Price50;
			objFromDb.Price100 = obj.Price100;
			objFromDb.ListPrice = obj.ListPrice;
			objFromDb.Description = obj.Description;
			objFromDb.CategoryId = obj.CategoryId;
			objFromDb.Author = obj.Author;

			if (obj.ImageUrl != null) {
				objFromDb.ImageUrl = obj.ImageUrl;
			}
		}
	}
}
