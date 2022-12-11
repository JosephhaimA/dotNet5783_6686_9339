using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

[Serializable]
public class BlDoesNotExistException : Exception
{
    public BlDoesNotExistException(string? message) : base(message) { }
}

[Serializable]
public class BlAlreadyExistException : Exception
{
    public BlAlreadyExistException(string? message) : base(message) { }

    public BlAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

[Serializable]
public class BlDataCorruption : Exception
{
    public BlDataCorruption(string? message) : base(message) { }
}

