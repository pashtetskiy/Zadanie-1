namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a African Elephant.
/// </summary>
public interface IAfricanElephant : IMammal
{
    #region Interface Members
    /// <summary>
    /// Height
    /// Weight
    /// TuskLenght
    /// LongLifespan
    /// SocialBehavior
    /// </summary>
    float Height { get; set; }
    float Weight { get; set; }
    float TuskLenght { get; set; }
    int LongLifespan { get; set; }
    string SocialBehavior { get; set; } 
    #endregion // Interface Members
}
