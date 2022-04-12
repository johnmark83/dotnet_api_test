namespace user_api;

public class User
{
    public int id { get; set; }

    public string firstName { get; set; } = string.Empty;

    public string lastName { get; set;} = string.Empty;

    public List<string> friends { get; set;} = new List<string>();

}
