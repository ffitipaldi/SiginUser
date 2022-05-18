namespace SiginUser.Data
{
    public class SqlAdoDbContext
    {
        public string ConnectioString { get; }
        public SqlAdoDbContext(string connectioString)
        {
            ConnectioString = connectioString;
        }
    }
}
