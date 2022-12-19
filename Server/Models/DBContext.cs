using Npgsql;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

public class DBContext
{
    public readonly NpgsqlConnection conn;
    public DBContext()
    {
        var kvUrl = "https://starfestkv.vault.azure.net/";
        var secretClient = new SecretClient(new Uri(kvUrl), new DefaultAzureCredential());
        string connString = secretClient.GetSecret("starfest").Value.Value;
        conn = new NpgsqlConnection(connString);
    }
}