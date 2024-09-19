namespace Fragment.Domain;

public class Tag
{
    private string _name;

    public string Name
    {
        get { return _name; }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name must be supplied.");
            }

            _name = value;
        }
    }

    public Tag(string name)
    {
        Name = name;
    }
}