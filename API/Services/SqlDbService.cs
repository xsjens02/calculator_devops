using MySql.Data.MySqlClient;
using API.Setup;
using Microsoft.Extensions.Options;

namespace API.Services;

public class SqlDbService
{
    private readonly string _connectionString;

    public SqlDbService(IOptions<SqlDbConfig> dbConfig)
    {
        this._connectionString = dbConfig.Value.ConnectionString;
    }

    public void SaveCalculation(string expression, string result)
    {
        using var con = new MySqlConnection(this._connectionString);
        con.Open();
        
        using var command = new MySqlCommand("INSERT INTO tblCalculations (expression, result) VALUES (@expression, @result)", con);
        command.Parameters.AddWithValue("@expression", expression);
        command.Parameters.AddWithValue("@result", result);
        
        command.ExecuteNonQuery();
    }

    public List<string> GetLatestCalculations()
    {
        var calculations = new List<string>();
        
        using var con = new MySqlConnection(this._connectionString);
        con.Open();
        
        using var command = new MySqlCommand("SELECT expression, result FROM tblCalculations ORDER BY id DESC LIMIT 5", con);
        using var reader = command.ExecuteReader();

        while (reader.Read())
            calculations.Add($"{reader.GetString(0)} = {reader.GetString(1)}");
        
        return calculations;
    }
}