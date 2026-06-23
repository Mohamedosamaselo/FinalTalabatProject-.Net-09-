namespace LinkDev.Talabat.Domain.Contracts;

public interface IStoreContextInitilazer
{
    Task InitilizeAsync();

    Task SeedAsync();
}