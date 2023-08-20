using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Chimpanzee screen.
/// </summary>
public sealed class ChimpanzeeScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private readonly IDataService _dataService;
    private readonly Settings _settings;
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="settings">Data service reference</param>
    public ChimpanzeeScreen(IDataService dataService, Settings settings)
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
            _settings.UpdateScreenColor(ScreensEnum.Chimpanzee);
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. List all Chimpanzees");
            Console.WriteLine("2. Create a new Chimpanzee");
            Console.WriteLine("3. Delete existing Chimpanzee");
            Console.WriteLine("4. Modify existing Chimpanzee");
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
                        ListChimpanzee();
                        break;

                    case SecondAnimalsScreenChoices.Create:
                        AddChimpanzee(); break;

                    case SecondAnimalsScreenChoices.Delete:
                        DeleteChimpanzee();
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
    /// List all Chimpanzee.
    /// </summary>
    
    private void ListChimpanzee()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Chimpanzee is not null &&
            _dataService.Animals.Mammals.Chimpanzee.Count > 0)
        {
            Console.WriteLine("Here's a list of Chimpanzee");
            int i = 1;
            foreach (Chimpanzee Chimpanzee in _dataService.Animals.Mammals.Chimpanzee.Cast<Chimpanzee>())
            {
                Console.Write($"Chimpanzee number {i}, ");
                Chimpanzee.Display();
                i++;
            }
        }
        else
        {
            Console.WriteLine("The list of Chimpanzee is empty.");
        }
    }

    /// <summary>
    /// Add a Chimpanzee.
    /// </summary>
    
    private void AddChimpanzee()
    {
        try
        {
            Chimpanzee Chimpanzee = AddEditChimpanzee();
            _dataService?.Animals?.Mammals?.Chimpanzee?.Add(Chimpanzee);
            Console.WriteLine("Chimpanzee with name: {0} has been added to a list of Chimpanzees", Chimpanzee.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Delete a Chimpanzee.
    /// </summary>
    private void DeleteChimpanzee()
    {
        try
        {
            Console.Write("What is the name of the Chimpanzee you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Chimpanzee? Chimpanzee = (Chimpanzee?)(_dataService?.Animals?.Mammals?.Chimpanzee
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (Chimpanzee is not null)
            {
                _dataService?.Animals?.Mammals?.Chimpanzee?.Remove(Chimpanzee);
                Console.WriteLine("Chimpanzee with name: {0} has been deleted from a list of Chimpanzees", Chimpanzee.Name);
            }
            else
            {
                Console.WriteLine("Chimpanzee not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing Chimpanzee after choice.
    /// </summary>
    private void EditAfricanElephant()
    {
        try
        {
            Console.Write("What is the name of the Chimpanzee you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Chimpanzee? Chimpanzee = (Chimpanzee?)(_dataService?.Animals?.Mammals?.Chimpanzee
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (Chimpanzee is not null)
            {
                Chimpanzee ChimpanzeeEdited = AddEditChimpanzee();
                Chimpanzee.Copy(ChimpanzeeEdited);
                Console.Write("Chimpanzee after edit:");
                Chimpanzee.Display();
            }
            else
            {
                Console.WriteLine("Chimpanzee not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific Chimpanzee.
    /// </summary>
    
    private Chimpanzee AddEditChimpanzee()
    {
        Console.Write("What name of the Chimpanzee ");
        string? name = Console.ReadLine();
        Console.Write("What is the Chimpanzee age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("Do chimpanzee have opposable thumbs? Write Y or N ");
        bool iopposableThumbs;
        string? describeofopposableThumbs;
        if (Console.ReadLine()?.ToLower() == "y")
        {
            Console.Write("Describe the features of opposable thumbs in chimpanzee: ");
            describeofopposableThumbs = Console.ReadLine();
            iopposableThumbs = true;
        } else
        {
            iopposableThumbs = false; describeofopposableThumbs = "This chimpanzee don't have opposable thumbs";
        };
        Console.Write("Do chimpanzees have complex social behavior? ");
        string? complexSocialBehavior = Console.ReadLine();
        Console.Write("Can a chimpanzee use the tool? Write Y or N ");
        bool itoolUse;
        string? descireofusetools;
        if (Console.ReadLine()?.ToLower() == "y")
        {
            Console.Write("Describe how chimpanzee uses the tool? :");
            descireofusetools = Console.ReadLine();
            itoolUse = true;
        } else
        {
            itoolUse = false; descireofusetools = "This chimpanzee don't know how to use tools";
        };
        Console.Write("What is the high intelligence of chimpanzee? ");
        string? highIntelligenceAsString = Console.ReadLine();
        Console.Write("What is the chimpanzee flexible diet? ");
        string? flexibleDiet = Console.ReadLine();

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (complexSocialBehavior is null)
        {
            throw new ArgumentNullException(nameof(complexSocialBehavior));
        }
        if (highIntelligenceAsString is null)
        {
            throw new ArgumentNullException(nameof(highIntelligenceAsString));
        }
        if (flexibleDiet is null)
        {
            throw new ArgumentNullException(nameof(flexibleDiet));
        }
        if (describeofopposableThumbs is null)
        {
            throw new ArgumentNullException(nameof(describeofopposableThumbs));
        }
        if (descireofusetools is null)
        {
            throw new ArgumentNullException(nameof(descireofusetools));
        }

        int age = int.Parse(ageAsString);
        int highIntelligence = int.Parse(highIntelligenceAsString);

        Chimpanzee Chimpanzee = new(name, age, iopposableThumbs, describeofopposableThumbs, complexSocialBehavior, itoolUse, descireofusetools, highIntelligence, flexibleDiet);

        return Chimpanzee;
    }

    #endregion // Private Methods
}
