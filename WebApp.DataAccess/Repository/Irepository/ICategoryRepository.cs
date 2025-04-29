using System;
using WebApp.Models;

namespace WebApp.DataAccess.Repository.Irepository;

public interface ICategoryRepository : IRepository<Category>{

	void Update(Category obj);
}
