namespace Domain.TransactionManager.Interface
{
    public interface ITransFactory
    {
        ITransManager CreateManager();
    }
}
