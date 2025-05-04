using System;
using WebApp.Models;

namespace WebApp.DataAccess.Repository.Irepository;

public interface IProductRepository : IRepository<Product>{

	void Update(Product obj);
}
