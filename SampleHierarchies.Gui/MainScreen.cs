using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;
using System.Runtime;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private readonly Settings _settings;
    /// <summary>
    /// Animals and settings screen.
    /// </summary>
    private readonly AnimalsScreen _animalsScreen;
    private readonly SettingsScreen _settingsScreen;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="animalsScreen">Animals screen</param>
    /// <param name="settingsScreen">Data service reference</param>
    /// <param name="settings">Animals screen</param>
    public MainScreen(
        AnimalsScreen animalsScreen,
        SettingsScreen settingsScreen,
        Settings settings
        )

    {
        _settings = settings;
        _animalsScreen = animalsScreen;
        _settingsScreen = settingsScreen;
        _settings.LoadAutoJson();
    }

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        
        while (true)
        {
            _settings.UpdateScreenColor(ScreensEnum.MainScreen);
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Animals");
            Console.WriteLine("2. Create a new settings");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                MainScreenChoices choice = (MainScreenChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.Animals:
                        _animalsScreen.Show();
                        break;

                    case MainScreenChoices.Settings:
                        _settingsScreen.Show();
                        break;

                    case MainScreenChoices.Exit:
                        Console.WriteLine("Goodbye.");
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