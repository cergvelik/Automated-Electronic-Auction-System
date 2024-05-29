public abstract class RepositoryInSQL // базовый класс репозитория
{
    protected readonly string _connectionString;

    public RepositoryInSQL(string connectionString)
    {
        _connectionString = connectionString;
    }
}