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
		_db.Products.Update(obj);
	}
}
