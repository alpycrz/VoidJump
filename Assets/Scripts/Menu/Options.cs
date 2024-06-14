using UnityEngine;

namespace Menu
{
    public static class Options
    {
        public static string easy = "easy";
        public static string medium = "medium";
        public static string hard = "hard";        
        
        public static string easyScore = "easyScore";
        public static string mediumScore = "mediumScore";
        public static string hardScore = "hardScore";        
        
        public static string easyGold = "easyGold";
        public static string mediumGold = "mediumGold";
        public static string hardGold = "hardGold";

        public static string musicOn = "musicOn";

        
        // Difficulty
        public static void SetValueEasy(int easy) => PlayerPrefs.SetInt(Options.easy, easy);
        public static int GetValueEasy() => PlayerPrefs.GetInt(Options.easy);

        public static void SetValueMedium(int medium) => PlayerPrefs.SetInt(Options.medium, medium);
        public static int GetValueMedium() => PlayerPrefs.GetInt(Options.medium);

        public static void SetValueHard(int hard) => PlayerPrefs.SetInt(Options.hard, hard);
        public static int GetValueHard() => PlayerPrefs.GetInt(Options.hard);
        
        //Score Diff
        public static void SetValueEasyScore(int easyScore) => PlayerPrefs.SetInt(Options.easyScore, easyScore);
        public static int GetValueEasyScore() => PlayerPrefs.GetInt(Options.easyScore);

        public static void SetValueMediumScore(int mediumScore) => PlayerPrefs.SetInt(Options.mediumScore, mediumScore);
        public static int GetValueMediumScore() => PlayerPrefs.GetInt(Options.mediumScore);

        public static void SetValueHardScore(int hardScore) => PlayerPrefs.SetInt(Options.hardScore, hardScore);
        public static int GetValueHardScore() => PlayerPrefs.GetInt(Options.hardScore);
        
        //Gold Diff
        public static void SetValueEasyGold(int easyGold) => PlayerPrefs.SetInt(Options.easyGold, easyGold);
        public static int GetValueEasyGold() => PlayerPrefs.GetInt(Options.easyGold);

        public static void SetValueMediumGold(int mediumGold) => PlayerPrefs.SetInt(Options.mediumGold, mediumGold);
        public static int GetValueMediumGold() => PlayerPrefs.GetInt(Options.mediumGold);

        public static void SetValueHardGold(int hardGold) => PlayerPrefs.SetInt(Options.hardGold, hardGold);
        public static int GetValueHardGold() => PlayerPrefs.GetInt(Options.hardGold);
        
        //Music on/off
        public static void SetMusicOn(int musicOn) => PlayerPrefs.SetInt(Options.musicOn, musicOn);
        public static int GetMusicOn() => PlayerPrefs.GetInt(Options.musicOn);

        // checks is there any save
        public static bool HadSave()
        {
            if (PlayerPrefs.HasKey(Options.easy) || 
                PlayerPrefs.HasKey(Options.medium) || 
                PlayerPrefs.HasKey(Options.hard))
                return true;
            else
                return false;
        }

        public static bool isMusicOn()
        {
            if (PlayerPrefs.HasKey(Options.musicOn))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
