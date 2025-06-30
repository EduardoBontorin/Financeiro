using MudBlazor.Utilities;
using MudBlazor;
using static System.Net.WebRequestMethods;

namespace Dima.Web
{
    public static class Configuration
    {
        public const string HttpClientName = "dima";
        public static string BackednUrl { get; set; } = string.Empty;

        public static MudTheme Theme = new()
        {
            Typography = new Typography()
            {
                Default = new DefaultTypography()
                {
                    FontFamily = new[] { "Raleway", "sans-serif" }
                }
            },
            PaletteLight = new PaletteLight()
            {
                Primary = new MudColor("#1EFA2D"), //Criar uma nova cor
                Secondary = Colors.LightGreen.Darken3, // Pegar cores padrões
                Background = Colors.Gray.Lighten4,
                AppbarBackground = new MudColor("#1EFA2D"),
                AppbarText = Colors.Shades.Black,
                PrimaryContrastText = new MudColor("#000000"),
                TextPrimary = Colors.Shades.Black,
                DrawerText = Colors.Shades.White,
                DrawerBackground = Colors.LightGreen.Darken4
            },
            PaletteDark = new PaletteDark()
            {
                Primary = Colors.LightGreen.Accent3,
                Secondary = Colors.Shades.White,
                AppbarBackground = Colors.LightGreen.Accent3,
                AppbarText = Colors.Shades.Black,
                PrimaryContrastText = Colors.Shades.Black
            }
        };
    }
}
