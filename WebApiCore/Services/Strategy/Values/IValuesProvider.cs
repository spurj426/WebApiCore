﻿using System.Collections.Generic;

namespace WebApiCore.Services.Strategy.Values
{
    public interface IValuesProvider
    {
        // What is going on here?  We have a FetchData method for IValuesClient,
        // and now we have a FetchData method for the IValuesProvider.
        // The IValuesClient simply provides the interface on the service to be called.
        // The IValuesProvider is a class that will encapsulate the implementation details.
        // For example, you could have a file system provider, and http requestor provider, etc.
        IEnumerable<string> FetchData();
    }
}
