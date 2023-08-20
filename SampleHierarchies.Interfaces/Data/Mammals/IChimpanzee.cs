namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a African Elephant.
/// </summary>
public interface IChimpanzee : IMammal
{
    #region Interface Members
    /// <summary>
    /// IOpposableThumbs
    /// DescOfOpposableThumbs
    /// ComplexSocialBehavio
    /// IToolUse
    /// DescOfToolUse
    /// HighIntelligence
    /// FlexibleDiet
    /// </summary>
    bool IOpposableThumbs  { get; set; }
    string DescOfOpposableThumbs { get; set; }
    string ComplexSocialBehavio { get; set; }
    bool IToolUse  { get; set; }
    string DescOfToolUse { get; set; }
    int HighIntelligence { get; set; }
    string FlexibleDiet { get; set; } 
    #endregion // Interface Members
}
