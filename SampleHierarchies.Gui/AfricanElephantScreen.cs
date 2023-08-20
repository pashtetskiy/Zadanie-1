using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// African Elephant screen.
/// </summary>
public sealed class AfricanElephantScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;
    private readonly Settings _settings;
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="settings">Data service reference</param>
    public AfricanElephantScreen(IDataService dataService,Settings settings)
    {
        _dataService = dataService;
        _settings = settings;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settings.UpdateScreenColor(ScreensEnum.AfricanElephantScreen);
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List all African Elephants");
            Console.WriteLine("2. Create a new African Elephant");
            Console.WriteLine("3. Delete existing African Elephant");
            Console.WriteLine("4. Modify existing African Elephant");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                SecondAnimalsScreenChoices choice = (SecondAnimalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case SecondAnimalsScreenChoices.List:
                        ListAfricanElephants();
                        break;

                    case SecondAnimalsScreenChoices.Create:
                        AddAfricanElephant(); break;

                    case SecondAnimalsScreenChoices.Delete:
                        DeleteAfricanElephant();
                        break;

                    case SecondAnimalsScreenChoices.Modify:
                        EditAfricanElephant();
                        break;

                    case SecondAnimalsScreenChoices.Exit:
                        Console.WriteLine("Going back to parent menu.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }

    #endregion // Public Methods

    #region Private Methods

    /// <summary>
    /// List all African Elephants.
    /// </summary>
    private void ListAfricanElephants()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.AfricanElephants is not null &&
            _dataService.Animals.Mammals.AfricanElephants.Count > 0)
        {
            Console.WriteLine("Here's a list of African Elephants");
            int i = 1;
            foreach (AfricanElephant AfricanElephant in _dataService.Animals.Mammals.AfricanElephants)
            {
                Console.Write($"African Elephant number {i}, ");
                AfricanElephant.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of African Elephants is empty.");
        }
    }

    /// <summary>
    /// Add a African Elephant.
    /// </summary>
    private void AddAfricanElephant()
    {
        try
        {
            AfricanElephant AfricanElephant = AddEditAfricanElephant();
            _dataService?.Animals?.Mammals?.AfricanElephants?.Add(AfricanElephant);
            Console.WriteLine("African Elephant with name: {0} has been added to a list of African Elephants", AfricanElephant.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Delete a African Elephant.
    /// </summary>
    private void DeleteAfricanElephant()
    {
        try
        {
            Console.Write("What is the name of the African Elephant you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            AfricanElephant? AfricanElephant = (AfricanElephant?)(_dataService?.Animals?.Mammals?.AfricanElephants
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (AfricanElephant is not null)
            {
                _dataService?.Animals?.Mammals?.AfricanElephants?.Remove(AfricanElephant);
                Console.WriteLine("African Elephant with name: {0} has been deleted from a list of African Elephants", AfricanElephant.Name);
            }
            else
            {
                Console.WriteLine("African Elephant not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing African Elephant after choice made.
    /// </summary>
    private void EditAfricanElephant()
    {
        try
        {
            Console.Write("What is the name of the African Elephant you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            AfricanElephant? AfricanElephant = (AfricanElephant?)(_dataService?.Animals?.Mammals?.AfricanElephants
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (AfricanElephant is not null)
            {
                AfricanElephant AfricanElephantEdited = AddEditAfricanElephant();
                AfricanElephant.Copy(AfricanElephantEdited);
                Console.Write("African Elephant after edit:");
                AfricanElephant.Display();
            }
            else
            {
                Console.WriteLine("African Elephant not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Add/edit specific African Elephant.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private AfricanElephant AddEditAfricanElephant()
    {
        Console.Write("What name of the African Elephant? ");
        string? name = Console.ReadLine();
        Console.Write("What is the African Elephant age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("What is the African Elephant height? ");
        string? heightAsString = Console.ReadLine();
        Console.Write("What is the African Elephant weight? ");
        string? weightAsString = Console.ReadLine();
        Console.Write("What is the African Elephant tusk lenght? ");
        string? tuskLenghtAsString = Console.ReadLine();
        Console.Write("What is the African Elephant long life span? ");
        string? longLifespanAsString = Console.ReadLine();
        Console.Write("What is social behavior of the African Elephant? ");
        string? socialBehavior = Console.ReadLine();

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (heightAsString is null)
        {
            throw new ArgumentNullException(nameof(heightAsString));
        }
        if (weightAsString is null)
        {
            throw new ArgumentNullException(nameof(weightAsString));
        }
        if (tuskLenghtAsString is null)
        {
            throw new ArgumentNullException(nameof(tuskLenghtAsString));
        }
        if (longLifespanAsString is null)
        {
            throw new ArgumentNullException(nameof(longLifespanAsString));
        }
        if (socialBehavior is null)
        {
            throw new ArgumentNullException(nameof(socialBehavior));
        }
        try
        {
            int age = int.Parse(ageAsString);
            float height = float.Parse(heightAsString);
            float weight = float.Parse(weightAsString);
            float tuskLenght = float.Parse(tuskLenghtAsString);
            int longLifespan = int.Parse(longLifespanAsString);
            AfricanElephant AfricanElephant = new(name, age, height, weight, tuskLenght, longLifespan, socialBehavior);
            return AfricanElephant;
        }
        catch (Exception)
        {
            throw new ArgumentNullException();
        }
    }
   
    #endregion // Private Methods
}
