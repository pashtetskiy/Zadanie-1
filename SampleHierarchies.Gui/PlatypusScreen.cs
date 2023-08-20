using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Platypus screen.
/// </summary>
public sealed class PlatypusScreen : Screen
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
    public PlatypusScreen(IDataService dataService,Settings settings)
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
            _settings.UpdateScreenColor(ScreensEnum.Platypus);
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List all Platypus");
            Console.WriteLine("2. Create a new Platypus");
            Console.WriteLine("3. Delete existing Platypus");
            Console.WriteLine("4. Modify existing Platypus");
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
                        ListPlatypus();
                        break;

                    case SecondAnimalsScreenChoices.Create:
                        AddPlatypus(); break;

                    case SecondAnimalsScreenChoices.Delete:
                        DeletePlatypus();
                        break;

                    case SecondAnimalsScreenChoices.Modify:
                        EditPlatypus();
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
    /// List all Platypus.
    /// </summary>
    private void ListPlatypus()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Platypus is not null &&
            _dataService.Animals.Mammals.Platypus.Count > 0)
        {
            Console.WriteLine("Here's a list of Platypus");
            int i = 1;
            foreach (Platypus Platypus in _dataService.Animals.Mammals.Platypus)
            {
                Console.Write($"Platypus number {i}, ");
                Platypus.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of Platypus is empty.");
        }
    }

    /// <summary>
    /// Add a Platypus.
    /// </summary>
    private void AddPlatypus()
    {
        try
        {
            Platypus Platypus = AddEditPlatypus();
            _dataService?.Animals?.Mammals?.Platypus?.Add(Platypus);
            Console.WriteLine("Platypust with name: {0} has been added to a list of Platypus", Platypus.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Delete a Platypus.
    /// </summary>
    private void DeletePlatypus()
    {
        try
        {
            Console.Write("What is the name of the Platypus you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Platypus? Platypus = (Platypus?)(_dataService?.Animals?.Mammals?.Platypus
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (Platypus is not null)
            {
                _dataService?.Animals?.Mammals?.Platypus?.Remove(Platypus);
                Console.WriteLine("Platypus with name: {0} has been deleted from a list of Platypus", Platypus.Name);
            }
            else
            {
                Console.WriteLine("Platypus not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing Platypus after choice made.
    /// </summary>
    private void EditPlatypus()
    {
        try
        {
            Console.Write("What is the name of the Platypus you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Platypus? Platypus = (Platypus?)(_dataService?.Animals?.Mammals?.Platypus
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (Platypus is not null)
            {
                Platypus PlatypusEdited = AddEditPlatypus();
                Platypus.Copy(PlatypusEdited);
                Console.Write("Platypus after edit:");
                Platypus.Display();
            }
            else
            {
                Console.WriteLine("Platypus not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Add/edit specific Platypus.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Platypus AddEditPlatypus()
    {
        Console.Write("What name of the Platypus? ");
        string? name = Console.ReadLine();
        Console.Write("What is the Platypus age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("What is the Platypus height? ");
        string? heightAsString = Console.ReadLine();
        Console.Write("What is the Platypus weight? ");
        string? weightAsString = Console.ReadLine();
        Console.Write("How long is the Platypus habitat? ");
        string? habitatAsString = Console.ReadLine();
        Console.Write("Is Platypus male? Y or N ");
        bool isMale;
        if (Console.ReadLine()?.ToLower() == "y")
            isMale = true;
        else
            isMale = false;
        Console.Write("Is Platypus venomous? True or false ");
        bool isVenomous;
        if (Console.ReadLine()?.ToLower() == "y")
            isVenomous = true;
        else
            isVenomous = false;

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
        if (habitatAsString is null)
        {
            throw new ArgumentNullException(nameof(habitatAsString));
        }
        try
        {
            int age = int.Parse(ageAsString);
            float height = float.Parse(heightAsString);
            float weight = float.Parse(weightAsString);
            float habitat = float.Parse(habitatAsString);
            Platypus Platypus = new(name, age, height, weight, habitat, isMale, isVenomous);
            return Platypus;
        }
        catch (Exception)
        {
            throw new ArgumentNullException();
        }
    }
   
    #endregion // Private Methods
}
