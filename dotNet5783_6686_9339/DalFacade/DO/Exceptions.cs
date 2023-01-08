namespace DO;

public class DalDoesNotExistException : Exception
{
    public DalDoesNotExistException(string? message) : base(message) { }
}
public class DalAlreadyExistException : Exception
{
    public DalAlreadyExistException(string? message) : base(message) { }
}

public class DalDataCorruption : Exception
{
    public DalDataCorruption(string? message) : base(message) { }
}

[Serializable]
public class DalConfigException : Exception // exception for level 4 to suitable with the new class we created
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}
