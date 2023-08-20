using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Very basic dog class.
/// </summary>
public class Platypus : MammalBase, IPlatypus
{
    #region Public Methods

    /// <inheritdoc/>
    public override void MakeSound()
    {
        Console.WriteLine("My name is: {0} and I am Platypus", Name);
    }

    /// <inheritdoc/>
    public override void Move()
    {
        Console.WriteLine("My name is: {0} and I am running", Name);
    }

    /// <inheritdoc/>
    public override void Display()
    {
        Console.WriteLine($"Height : {Height}, Weight : {Weight}, Habitat: {Habitat}, IsMale: {IsMale}, IsVenomous: {IsVenomous}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IPlatypus ad)
        {
            base.Copy(animal);
            Height = ad.Height;
            Weight = ad.Weight;
            Habitat = ad.Habitat;
            IsMale = ad.IsMale;
            IsVenomous = ad.IsVenomous;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public float Height { get; set; }
    public float Weight { get; set; }
    public float Habitat { get; set; }
    public bool IsMale { get; set; }
    public bool IsVenomous { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="weight">Weight</param>
    /// <param name="height">Height</param>
    /// <param name="tuskLenght">TuskLenght</param>
    /// <param name="longLifespan">LongLifespan</param>
    /// <param name="socialBehavior">SocialBehavior</param>
    public Platypus(string name, int age, float height, float weight, float habitat, bool isMale, bool isVenomous) : base(name, age, MammalSpecies.Platypus)
    {
        Height = height;
        Weight = weight;
        Habitat = habitat;
        IsMale = isMale;
        IsVenomous = isVenomous;
    }

    #endregion // Ctors And Properties
}
