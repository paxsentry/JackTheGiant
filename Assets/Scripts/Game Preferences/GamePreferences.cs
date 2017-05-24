using UnityEngine;

public static class GamePreferences
{
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string HardDifficultyHighScore = "HardDifficultyHighScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";

    public static void SetEasyDifficulty(int state) { PlayerPrefs.SetInt(EasyDifficulty, state); }
    public static int GetEasyDifficulty() { return PlayerPrefs.GetInt(EasyDifficulty); }

    public static void SetMediumDifficulty(int state) { PlayerPrefs.SetInt(MediumDifficulty, state); }
    public static int GetMediumDifficulty() { return PlayerPrefs.GetInt(MediumDifficulty); }

    public static void SetHardDifficulty(int state) { PlayerPrefs.SetInt(HardDifficulty, state); }
    public static int GetHardDifficulty() { return PlayerPrefs.GetInt(HardDifficulty); }

    public static void SetEasyDifficultyHighScore(int state) { PlayerPrefs.SetInt(EasyDifficultyHighScore, state); }
    public static int GetEasyDifficultyHighScore() { return PlayerPrefs.GetInt(EasyDifficultyHighScore); }

    public static void SetMediumDifficultyHighScore(int state) { PlayerPrefs.SetInt(MediumDifficultyHighScore, state); }
    public static int GetMediumDifficultyHighScore() { return PlayerPrefs.GetInt(MediumDifficultyHighScore); }

    public static void SetHardDifficultyHighScore(int state) { PlayerPrefs.SetInt(HardDifficultyHighScore, state); }
    public static int GetHardDifficultyHighScore() { return PlayerPrefs.GetInt(HardDifficultyHighScore); }

    public static void SetEasyDifficultyCoinScore(int state) { PlayerPrefs.SetInt(EasyDifficultyCoinScore, state); }
    public static int GetEasyDifficultyCoinScore() { return PlayerPrefs.GetInt(EasyDifficultyCoinScore); }

    public static void SetMediumDifficultyCoinScore(int state) { PlayerPrefs.SetInt(MediumDifficultyCoinScore, state); }
    public static int GetMediumDifficultyCoinScore() { return PlayerPrefs.GetInt(MediumDifficultyCoinScore); }

    public static void SetHardDifficultyCoinScore(int state) { PlayerPrefs.SetInt(HardDifficultyCoinScore, state); }
    public static int GetHardDifficultyCoinScore() { return PlayerPrefs.GetInt(HardDifficultyCoinScore); }

    public static void SetIsMusicOn(int state) { PlayerPrefs.SetInt(IsMusicOn, state); }
    public static int GetIsMusicOn() { return PlayerPrefs.GetInt(IsMusicOn); }
}