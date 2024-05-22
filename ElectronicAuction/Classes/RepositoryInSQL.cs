public abstract class RepositoryInSQL
{
    protected readonly string _connectionString;

    public RepositoryInSQL(string connectionString)
    {
        _connectionString = connectionString;
    }
}