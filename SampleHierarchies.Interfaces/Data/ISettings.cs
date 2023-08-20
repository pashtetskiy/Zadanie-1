using SampleHierarchies.Enums;


namespace SampleHierarchies.Interfaces.Data;

    /// <summary>
    /// Interface describing an Settings.
    /// </summary>  
public interface ISettings
{
    #region Interface Members
    public void UpdateScreenColor(ScreensEnum id);
    public void SetScreenColor(ScreensEnum id);
    public void LoadAutoJson();

    #endregion // Interface Members
}

