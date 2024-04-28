namespace Game
{
    public static class Constants
    {
        public const string AudioConfigPath = "AudioConfig";
        public const string WeatherConfigPath = "WeatherConfig";

        public const string ActivePopupID = "ActivePopup";
        
        public const string ImageViewID = "ImageViewID";
        public const string SliderViewID = "SliderViewID";
        public const string ToggleViewID = "ToggleViewID";
        public const string ButtonViewID = "ButtonViewID";
        public const string TransformViewID = "TransformViewID";
        
        public const string ShowKey = "Show";
        public const string HideKey = "Hide";
        
        public static string Temperature(float temp) => $"Temperature: {temp}°C";

        public const string MusicSaveKey = "MusicSaveKey";
        public const string SoundSaveKey = "SoundSaveKey";
        
        public const string LinkedinURL = "https://www.linkedin.com/in/prokopenko-dmytro/";
        public static string URLWeather(string city) => $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=d75e8f6a11cf5d8048f9066caa637070&units=metric";
        public static string URLImageUrl(string icon) =>  $"http://openweathermap.org/img/wn/{icon}.png";
        
        public const int NumGameScene = 1;
        
        public enum PopupsID
        {
            None,
            Enter,
            Settings,
        }

        public enum TransformObject
        {
            None,
            
            ActiveSoundsParent,
            InactiveSoundsParent,
 
            ActiveWeatherParent,
            InactiveWeatherParent,
        }

        public enum ButtonObject
        {
            None,
            LoadGameScene,
            Linkedin,
            ResetWindow,
            Quit
        }
        
        public enum SliderObject
        {
            None,
            Music,
            Sound,
        }
        
        public enum ToggleObject
        {
            None,
            Music,
            Sound,
        }
        
        public enum ImageObject
        {
            None,
            Loader,
            LoaderBg,
        }
        
        public enum SoundObject
        {
            None,
            Click,
        }
    }
}