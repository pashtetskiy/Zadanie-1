namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a African Elephant.
/// </summary>
public interface IPlatypus : IMammal
{
    #region Interface Members
    /// <summary>
    /// Height
    /// Weight
    /// Habitat
    /// IsMale
    /// IsVenomous
    /// </summary>
    float Height { get; set; }
    float Weight { get; set; }
    float Habitat { get; set; }
    bool IsMale { get; set; }
    bool IsVenomous { get; set; } 
    #endregion // Interface Members
}
