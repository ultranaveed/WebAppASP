using System;
using WebApp.DataAccess.Data;
using WebApp.DataAccess.Repository.Irepository;

namespace WebApp.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
	private ApplicationDbContext _db;
	public ICategoryRepository Category {get;private set;}
	public IProductRepository Product { get; private set; }
	public UnitOfWork(ApplicationDbContext db){
		_db=db;
		Category = new CategoryRepository(_db);
		Product = new ProductRepository(_db);
	}
	
	public void Save(){
		_db.SaveChanges();
	}
}
