using System;

namespace WebApp.DataAccess.Repository.Irepository;

public interface IUnitOfWork{
	ICategoryRepository Category {get;}

	void Save();

}
