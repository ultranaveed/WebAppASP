using System;
using System.Data.Common;
using System.Linq.Expressions;
using WebApp.DataAccess.Data;
using WebApp.DataAccess.Repository.Irepository;
using WebApp.Models;

namespace WebApp.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
	private ApplicationDbContext _db;
	public CategoryRepository(ApplicationDbContext db): base (db)
	{
		_db=db;
	}


	public void Update(Category obj){
		_db.Categories.Update(obj);
	}
}
