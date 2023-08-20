using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Very basic dog class.
/// </summary>
public class AfricanElephant : MammalBase, IAfricanElephant
{
    #region Public Methods

    /// <inheritdoc/>
    public override void MakeSound()
    {
        Console.WriteLine("My name is: {0} and I am African Elephant", Name);
    }

    /// <inheritdoc/>
    public override void Move()
    {
        Console.WriteLine("My name is: {0} and I am running", Name);
    }

    /// <inheritdoc/>
    public override void Display()
    {
        Console.WriteLine($"Height : {Height}, Weight : {Weight}, Tusk length: {TuskLenght}, Lifespan: {LongLifespan}, Social behavior: {SocialBehavior}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IAfricanElephant ad)
        {
            base.Copy(animal);
            Height = ad.Height;
            Weight = ad.Weight;
            TuskLenght = ad.TuskLenght;
            LongLifespan = ad.LongLifespan;
            SocialBehavior = ad.SocialBehavior;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties

    /// <inheritdoc/>
    public float Height { get; set; }
    public float Weight { get; set; }
    public float TuskLenght { get; set; }
    public int LongLifespan { get; set; }
    public string SocialBehavior { get; set; }

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
    public AfricanElephant(string name, int age, float height, float weight, float tuskLenght, int longLifespan, string socialBehavior) : base(name, age, MammalSpecies.AfricanElephant)
    {
        Height = height;
        Weight = weight;
        TuskLenght = tuskLenght;
        LongLifespan = longLifespan;
        SocialBehavior = socialBehavior;
    }

    #endregion // Ctors And Properties
}
