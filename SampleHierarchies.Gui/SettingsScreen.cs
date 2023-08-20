using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using System;
using System.Net.Http.Json;

namespace SampleHierarchies.Gui;

/// <summary>
/// Settings screen.
/// </summary>
public sealed class SettingsScreen : Screen
{
    #region Properties And Ctor
    private readonly Settings _settings;
    public SettingsScreen(Settings settings)
    {
        _settings = settings;
    }
    /// <summary>
    /// Data service.
    /// </summary>

    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {

        while (true)
        {
            _settings.UpdateScreenColor(ScreensEnum.SettingsScreen);
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Edit");
            Console.WriteLine("2. Read from file");
            Console.WriteLine("3. Save to file");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                SettingsScreenChoicer choice = (SettingsScreenChoicer)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case SettingsScreenChoicer.Edit:
                        EditConsoleColor();
                        break;

                    case SettingsScreenChoicer.Read:
                        ReadFromFile();
                        break;

                    case SettingsScreenChoicer.Save:
                        SaveToFile();
                        break;

                    case SettingsScreenChoicer.Exit:
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
    /// Save to file.
    /// </summary>
    private void SaveToFile()
    {
        try
        {
            Console.Write("Save data to file (Write Colors.json to autoload screen settings): ");
            var jsonPath = Console.ReadLine();
            if (jsonPath is null)
            {
                throw new ArgumentNullException(nameof(jsonPath));
            }
            var jsonSettings = new JsonSerializerSettings();
            var jsonContent = JsonConvert.SerializeObject(_settings, jsonSettings);
            string jsonContentFormatted = jsonContent.FormatJson();
            File.WriteAllText(jsonPath, jsonContentFormatted);
            Console.WriteLine("Data saving to: '{0}' was successful.", jsonPath);
        }
        catch
        {
            Console.WriteLine("Data saving was not successful.");
        }
    }

    /// <summary>
    /// Read, edit data from file.
    /// </summary>

    private void ReadFromFile()
    {
        try
        {
            Console.Write("Read data from file: ");
            var jsonPath = Console.ReadLine();
            if (jsonPath is null)
            {
                throw new ArgumentNullException(nameof(jsonPath));
            }
            var jsonSettings = new JsonSerializerSettings();
            string jsonSource = File.ReadAllText(jsonPath);
            var jsonContent = System.Text.Json.JsonSerializer.Deserialize<Settings>(jsonSource);
            if (jsonContent == null)
            {
                throw new ArgumentNullException(nameof(jsonContent));
            }
            _settings.LoadJsonData(jsonContent);
            Console.WriteLine("Data reading from: '{0}' was successful.", jsonPath);
        }
        catch
        {
            Console.WriteLine("Data reading was not successful.");
        }
    }

    private void EditConsoleColor()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Main Screen");
            Console.WriteLine("2. Settings Screen");
            Console.WriteLine("3. Animals Screen");
            Console.WriteLine("4. Mammals Screen");
            Console.WriteLine("5. Dogs Screen");
            Console.WriteLine("6. African Elephants Screen");
            Console.WriteLine("7. Chimpanzees Screen");
            Console.WriteLine("8. Platypus Screen");
            Console.Write("Please enter your choice: ");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                if (choiceAsString is null)
                {
                    throw new ArgumentNullException(nameof(choiceAsString));
                }

                ScreensEnumChoices choice = (ScreensEnumChoices)Int32.Parse(choiceAsString);
                switch (choice)
                {
                    case ScreensEnumChoices.Exit:
                        Console.WriteLine("Going back to parent menu.");
                        return;
                    case ScreensEnumChoices.MainScreen:
                        _settings.SetScreenColor(ScreensEnum.MainScreen);
                        break;
                    case ScreensEnumChoices.SettingsScreen:
                        _settings.SetScreenColor(ScreensEnum.SettingsScreen);
                        break;

                    case ScreensEnumChoices.AnimalsScreen:
                        _settings.SetScreenColor(ScreensEnum.AnimalsScreen);
                        break;
                    case ScreensEnumChoices.MammalScreen:
                        _settings.SetScreenColor(ScreensEnum.MammalScreen);
                        break;
                    case ScreensEnumChoices.DogsScreen:
                        _settings.SetScreenColor(ScreensEnum.DogsScreen);
                        break;
                    case ScreensEnumChoices.AfricanElephantScreen:
                        _settings.SetScreenColor(ScreensEnum.AfricanElephantScreen);
                        break;
                    case ScreensEnumChoices.Chimpanzee:
                        _settings.SetScreenColor(ScreensEnum.Chimpanzee);
                        break;
                    case ScreensEnumChoices.Platypus:
                        _settings.SetScreenColor(ScreensEnum.Chimpanzee);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
    #endregion // Private Methods
}
