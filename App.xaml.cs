using Lepo.i18n;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Windows;

namespace MultiLangTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string langPath = "MultiLangTest.Language.";

        protected override void OnStartup(StartupEventArgs e)
        {
            // Load language file
            Translator.LoadLanguages(
                Assembly.GetExecutingAssembly(),
                new Dictionary<string, string>
                {
                    { "en_US", langPath + "en_US.yaml" },
                    { "zh_TW", langPath + "zh_TW.yaml" }
                }
            );

            // Get OS current language And Make UI language Displayed
            CultureInfo ci = CultureInfo.CurrentUICulture;

            if (ci.Name == "zh-TW")
                Translator.SetLanguage("zh_TW");
            else
                Translator.SetLanguage("en_US");
        }
    }

}
