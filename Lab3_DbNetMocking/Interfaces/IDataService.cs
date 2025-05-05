namespace NetDbMockApp.Interfaces
{
    public interface IDataService
    {
        // Retrieves data, mocked during testing
        Task<T> GetDataAsync<T>(string id);

        // Saves data, again mocked in tests
        Task<bool> SaveDataAsync<T>(T data);

        // Retrieves a list of data (could represent a collection from a database)
        Task<IEnumerable<T>> GetAllDataAsync<T>();

        // Simulate other database interactions, like updates or deletes
        Task<bool> DeleteDataAsync(string id);
    }
}