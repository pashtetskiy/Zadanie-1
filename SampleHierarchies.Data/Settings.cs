using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using System.Net.Http.Json;
using System.Runtime;

namespace SampleHierarchies.Data
{
    /// <summary>
    /// Settings
    /// </summary>
    
    public class Settings : ISettings
    {
        #region Properties And Ctor

        /// <summary>
        /// Ctor.
        /// Screens
        /// JSONPATH
        /// </summary>

        public Dictionary<ScreensEnum, Screen> Screens { get; set; }

        private readonly string JSONPATH = "Colors.json";

        public Settings()
        {
            Screens = new Dictionary<ScreensEnum, Screen>();
        }

        #endregion Properties And Ctor

        #region Public Methods

        /// <summary>
        /// Used to update the color
        /// </summary>

        public void UpdateScreenColor(ScreensEnum id)
        {
            Console.ForegroundColor = Screens[id].ConsoleScreenColor;
        }

        /// <summary>
        /// Used to set the color
        /// </summary>
      
        public void SetScreenColor(ScreensEnum id)
        {
            Console.Write("Write color: ");
            string? SecondchoiceAsString = Console.ReadLine();
            if (Enum.TryParse(SecondchoiceAsString, out ConsoleColor secondchoice))
            {
                Screens[id].ConsoleScreenColor = secondchoice;
                Console.WriteLine("Color successfully changed");
            }
            else Console.WriteLine("Incorrect input");
            SaveJson(this);
        }

        /// <summary>
        /// Used to load settings from json
        /// </summary>
        
        public void LoadJsonData(Settings jsonContent)
        {
            Screens = jsonContent.Screens;
        }

        /// <summary>
        /// Used to Autoload settings from json named "Colors.json"
        /// </summary>
        
        public void LoadAutoJson()
        {
            try
            {
                string jsonSource = File.ReadAllText(JSONPATH);
                if (jsonSource == null)
                {
                    throw new ArgumentNullException(nameof(jsonSource));
                }
                Settings? jsonContent = System.Text.Json.JsonSerializer.Deserialize<Settings>(jsonSource) ?? throw new ArgumentNullException(nameof(jsonSource));
                Screens = jsonContent.Screens;
            }
            catch (Exception)
            {
                CreateAllScreens();
                Console.WriteLine($"Failed to load {JSONPATH}");
            }

        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// Сreates default settings if "Colors.json" failed to load.
        /// </summary>

        private void CreateAllScreens()
        {
            Screens.Add(ScreensEnum.MainScreen, new Screen());
            Screens.Add(ScreensEnum.SettingsScreen, new Screen());
            Screens.Add(ScreensEnum.AnimalsScreen, new Screen());
            Screens.Add(ScreensEnum.MammalScreen, new Screen());
            Screens.Add(ScreensEnum.DogsScreen, new Screen());
            Screens.Add(ScreensEnum.AfricanElephantScreen, new Screen());
            Screens.Add(ScreensEnum.Chimpanzee, new Screen());
            Screens.Add(ScreensEnum.Platypus, new Screen());
        }

        /// <summary>
        /// Used to save settings 
        /// </summary>

        private void SaveJson(Settings? settings)
        {
            try
            {
                if (settings == null)
                {
                    throw new ArgumentNullException(nameof(settings));
                }
                string? jsonContent = System.Text.Json.JsonSerializer.Serialize<Settings>(settings) ?? throw new ArgumentNullException(nameof(settings));
                File.WriteAllText(JSONPATH, jsonContent);
            }
            catch (Exception)
            {
                Console.WriteLine($"Failed to save {settings}");
            }
        }
    }

    #endregion // Private Methods
}
