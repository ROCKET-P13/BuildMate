namespace BuildMateAPI.Data.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
	Task SaveChanges();
}
