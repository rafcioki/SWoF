using System;

namespace Core.Services
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
