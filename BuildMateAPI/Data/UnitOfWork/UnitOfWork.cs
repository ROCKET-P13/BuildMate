using BuildMateAPI.Data.UnitOfWork.Interfaces;

namespace BuildMateAPI.Data.UnitOfWork;

public sealed class UnitOfWork(AppDatabaseContext databaseContext) : IUnitOfWork
{
	private readonly AppDatabaseContext _databaseContext = databaseContext;

	public async Task SaveChanges()
	{
		await _databaseContext.SaveChangesAsync();
	}
}
