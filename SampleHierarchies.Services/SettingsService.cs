using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using Newtonsoft;
using Newtonsoft.Json;
using SampleHierarchies.Data;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
public class SettingsService : ISettingsService
{
    #region ISettings Implementation
    /// <inheritdoc/>
    public void Read()
    {
       
    }

    /// <inheritdoc/>
    public void Write(ISettings settings, string jsonPath)
    {

    }


    #endregion // ISettings Implementation
}