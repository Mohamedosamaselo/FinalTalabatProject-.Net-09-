namespace LinkDev.Talabat.Domain.Contracts.PersistenceLayer;

public interface IStoreContextInitilazer
{
    Task InitilizeAsync();

    Task SeedAsync();
}