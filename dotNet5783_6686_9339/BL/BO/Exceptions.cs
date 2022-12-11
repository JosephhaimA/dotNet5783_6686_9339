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
public class BlNameWasNull : Exception
{
    public BlNameWasNull(string? message) : base(message) { }
}

[Serializable]
public class BlAdressWasNull : Exception
{
    public BlAdressWasNull(string? message) : base(message) { }
}

[Serializable]
public class BlRongEmail : Exception
{
    public BlRongEmail(string? message) : base(message) { }
}

[Serializable]
public class BlIdNegative : Exception
{
    public BlIdNegative(string? message) : base(message) { }
}


[Serializable]
public class BlDataCorruption : Exception
{
    public BlDataCorruption(string? message) : base(message) { }
}

[Serializable]
public class BlInStockIsNegative : Exception
{
    public BlInStockIsNegative(string? message) : base(message) { }
}

[Serializable]
public class BlInPriceNegative : Exception
{
    public BlInPriceNegative(string? message) : base(message) { }
}

[Serializable]
public class BlCantDeleteB_Used : Exception
{
    public BlCantDeleteB_Used(string? message) : base(message) { }
}

[Serializable]
public class BlNotEnoughInStock : Exception
{
    public BlNotEnoughInStock(string? message) : base(message) { }
}