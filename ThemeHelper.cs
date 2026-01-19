using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _7
{
    static class ThemeHelper
    {
        private static readonly string[] _themePath = {
        "DefaultColors.xaml",
        "DarkTheme.xaml"
};
        public static string Current
        {
            get => Properties.Settings.Default.ThemePath == ""
            ? _themePath[0]
            : Properties.Settings.Default.ThemePath;
            set
            {
                Properties.Settings.Default.ThemePath = value;
                Properties.Settings.Default.Save();
            }
        }
        public static void Apply(string themePath)
        {
            var newTheme = new ResourceDictionary
            {
                Source = new Uri(themePath, UriKind.Relative)
            };
            var oldTheme = Application.Current.Resources.MergedDictionaries
            .FirstOrDefault(d => _themePath.Any(path =>
            d.Source != null && d.Source.OriginalString.EndsWith(path,
            StringComparison.OrdinalIgnoreCase)));
            if (oldTheme != null)
            {
                int index =
                Application.Current.Resources.MergedDictionaries.IndexOf(oldTheme);
                Application.Current.Resources.MergedDictionaries[index] =
                newTheme;
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(newTheme);
            }
            Current = themePath;
        }
        public static void ApplySaved()
        {
            var theme = Current;
            Apply(theme);
        }
        public static void Toggle()
        {
            var newTheme = Current == _themePath[0]
            ? _themePath[1]
            : _themePath[0];
            Apply(newTheme);
        }
    }
}


//В классе реализуется поле string[] _themePath , которое включает строки с путями к
//словарям цветов. Свойство Current используя Properties получает и сохраняет
//информацию о текущей теме приложения. Метод Apply устанавливает тему, заменяя
//словарь ресурсов приложения (или устанавливает, если словарь не установлен). Метод
//ApplySaved устанавливает тему, которая сохранена в Properties приложения. Метод
//Toggle меняет тему с одной на другую.