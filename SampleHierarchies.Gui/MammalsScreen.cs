using SampleHierarchies.Data;
using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private readonly DogsScreen _dogsScreen;
    private readonly AfricanElephantScreen _africanElephantScreen;
    private readonly ChimpanzeeScreen _chimpanzeeScreen;
    private readonly Settings _settings;
    private readonly PlatypusScreen _platypusScreen;
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    public MammalsScreen(DogsScreen dogsScreen, Settings settings, AfricanElephantScreen africanElephantScreen, ChimpanzeeScreen chimpanzeeScreen, PlatypusScreen platypusScreen)
    {
        _dogsScreen = dogsScreen;
        _settings = settings;
        _africanElephantScreen = africanElephantScreen;
        _chimpanzeeScreen = chimpanzeeScreen;
        _platypusScreen = platypusScreen;
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            _settings.UpdateScreenColor(ScreensEnum.MammalScreen);
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Dogs");
            Console.WriteLine("2. African Elephant");
            Console.WriteLine("3. Chimpanzee");
            Console.WriteLine("4. Platypus");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MammalsScreenChoices choice = (MammalsScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MammalsScreenChoices.Dogs:
                        _dogsScreen.Show();
                        break;
                    case MammalsScreenChoices.AfricanElephants:
                        _africanElephantScreen.Show();
                        break;
                    case MammalsScreenChoices.Chimpanzee:
                        _chimpanzeeScreen.Show();
                        break;
                    case MammalsScreenChoices.Platypus:
                        _platypusScreen.Show();
                        break;
                    case MammalsScreenChoices.Exit:
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
}
