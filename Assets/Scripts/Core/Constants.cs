namespace Game
{
    public static class Constants
    {
        public const string AudioConfigPath = "AudioConfig";
        public const string WeatherConfigPath = "WeatherConfig";

        public const string ActivePopupID = "ActivePopup";
        
        public const string AnimatorViewID = "CameraAnimator";
        public const string TextViewID = "TextViewID";
        public const string ImageViewID = "ImageViewID";
        public const string SliderViewID = "SliderViewID";
        public const string ToggleViewID = "ToggleViewID";
        public const string ButtonViewID = "ButtonViewID";
        public const string TransformViewID = "TransformViewID";
        
        public const string ShowKey = "Show";
        public const string HideKey = "Hide";

        public const string StartStateCamera = "StartState";
        public const string GameStateCamera = "GameState";

        public const string EnemyIdle = "Idle";
        public const string EnemyRun = "Run";
        
        public static string Temperature(float temp) => $"Temperature: {temp}°C";

        public const string KillsCountText = "Kill: ";
        public const string LevelsCountText = "Level: ";
        
        public const string MusicSaveKey = "MusicSaveKey";
        public const string SoundSaveKey = "SoundSaveKey";
        
        public const string LinkedinURL = "https://www.linkedin.com/in/prokopenko-dmytro/";
        public static string URLWeather(string city) => $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=d75e8f6a11cf5d8048f9066caa637070&units=metric";
        public static string URLImageUrl(string icon) =>  $"http://openweathermap.org/img/wn/{icon}.png";

        public const int DistEnemyMoveToPlayer = 50;
        public const int LevelStep = 105;
        public const int SpeedBullet = 500;
        public const float SpeedEnemy = 0.6f;
        public const int DistStopMove = -12;
        public const int DistDead = -18;
        public const float SpawnSize = 35f;
        
        public const float StepRotTurret = 120f;
        public const float SecBetweenAttack = 0.5f;

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

        }
        
        public enum TextObject
        {
            None,
            KillCounter,
            LvlCounter,
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

        public enum AnimatorObject
        {
            None,
            CameraAnimator,
        }
        
        public enum VFXObjectType
        {
            None,
            EnemyDead,
            EnemyDamage,
            PlayerDamage,
        }
        
    }
}