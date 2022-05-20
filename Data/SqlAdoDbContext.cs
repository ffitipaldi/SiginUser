namespace SiginUser.Data
{
    public class SqlAdoDbContext
    {
        public string ConnectionString { get; }
        public SqlAdoDbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
