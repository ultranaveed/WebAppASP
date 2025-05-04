using System;

namespace WebApp.DataAccess.Repository.Irepository;

public interface IUnitOfWork{
	ICategoryRepository Category {get;}
	IProductRepository Product{ get; }

	void Save();

}
