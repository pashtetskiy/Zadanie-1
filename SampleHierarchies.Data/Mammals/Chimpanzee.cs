using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Very basic dog class.
/// </summary>
public class Chimpanzee : MammalBase, IChimpanzee
{
    #region Public Methods

    /// <inheritdoc/>
    public override void MakeSound()
    {
        Console.WriteLine("My name is: {0} and I am Chimpanzee ", Name);
    }

    /// <inheritdoc/>
    public override void Move()
    {
        Console.WriteLine("My name is: {0} and I am running", Name);
    }

    /// <inheritdoc/>
    public override void Display()
    {
        Console.WriteLine($"Opposable Thumbs : {DescOfOpposableThumbs}, Complex Social Behavio : {ComplexSocialBehavio}, Tool Use: {DescOfToolUse}, High Intelligence: {HighIntelligence}, Flexible Diet: {FlexibleDiet} and I am a Chimpanzee.");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IChimpanzee ad)
        {
            base.Copy(animal);
            IOpposableThumbs = ad.IOpposableThumbs;
            DescOfOpposableThumbs = ad.DescOfOpposableThumbs;
            ComplexSocialBehavio = ad.ComplexSocialBehavio;
            IToolUse = ad.IToolUse;
            DescOfToolUse = ad.DescOfToolUse;
            HighIntelligence = ad.HighIntelligence;
            FlexibleDiet = ad.FlexibleDiet;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public bool IOpposableThumbs { get; set; }
    public string DescOfOpposableThumbs { get; set; }
    public string ComplexSocialBehavio { get; set; }
    public bool IToolUse { get; set; }
    public string DescOfToolUse { get; set; }
    public int HighIntelligence { get; set; }
    public string FlexibleDiet { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="descOfOpposableThumbs">OpposableThumbs</param>
    /// <param name="complexSocialBehavio">ComplexSocialBehavio</param>
    /// <param name="descOfToolUse">ToolUse</param>
    /// <param name="highIntelligence">HighIntelligence</param>
    /// <param name="flexibleDiet">FlexibleDiet</param>
    public Chimpanzee(string name, int age, bool iOpposableThumbs, string descOfOpposableThumbs, string complexSocialBehavio, bool iToolUse, string descOfToolUse, int highIntelligence, string flexibleDiet) : base(name, age, MammalSpecies.AfricanElephant)
    {
        IOpposableThumbs = iOpposableThumbs;
        DescOfOpposableThumbs = descOfOpposableThumbs;
        ComplexSocialBehavio = complexSocialBehavio;
        IToolUse = iToolUse;
        DescOfToolUse = descOfToolUse;
        HighIntelligence = highIntelligence;
        FlexibleDiet = flexibleDiet;
    }

    #endregion // Ctors And Properties
}
