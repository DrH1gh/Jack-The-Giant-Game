using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePeferences
{

    public static string EasyDiff = "EasyDiff";
    public static string MediumDiff = "MediumDiff";
    public static string HardDiff = "HardDiff";

    public static string EasyDiffScore = "EasyDiffScore";
    public static string MediumDiffScore = "MediumDiffScore";
    public static string HardDiffScore = "HardDiffScore";

    public static string EasyDiffCoinScore = "EasyDiffCoinScore";
    public static string MediumDiffCoinScore = "MediumDiffCoinScore";
    public static string HardDiffCoinScore = "HardDiffCoinScore";

    public static string IsMusicOn = "IsMusicOn";


    public static int GetMusic()
    {
        return PlayerPrefs.GetInt(IsMusicOn);
    }

    public static void SetMusic(int state)
    {
        PlayerPrefs.SetInt(IsMusicOn, state);
    }

    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(EasyDiff);
    }

    public static void SetEasyDifficulty(int state)
    {
        PlayerPrefs.SetInt(EasyDiff, state);
    }

    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(MediumDiff);
    }

    public static void SetMediuDifficulty(int state)
    {
        PlayerPrefs.SetInt(MediumDiff, state);
    }

    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(HardDiff);
    }

    public static void SetHardDifficulty(int state)
    {
        PlayerPrefs.SetInt(HardDiff, state);
    }

    public static int GetEasyDiffScore()
    {
        return PlayerPrefs.GetInt(EasyDiffScore);
    }

    public static void SetEasyDiffScore(int state)
    {
        PlayerPrefs.SetInt(EasyDiffScore, state);
    }

    public static int GetMediumDiffScore()
    {
        return PlayerPrefs.GetInt(MediumDiffScore);
    }

    public static void SetMediumDiffScore(int state)
    {
        PlayerPrefs.SetInt(MediumDiffScore, state);
    }

    public static int GetHardDiffScore()
    {
        return PlayerPrefs.GetInt(HardDiffScore);
    }

    public static void SetHardDiffScore(int state)
    {
        PlayerPrefs.SetInt(HardDiffScore, state);
    }

    public static int GetEasyDiffCoinScore()
    {
        return PlayerPrefs.GetInt(EasyDiffCoinScore);
    }

    public static void SetEasyDiffCoinScore(int state)
    {
        PlayerPrefs.SetInt(EasyDiffCoinScore, state);
    }

    public static int GetMediumDiffCoinScore()
    {
        return PlayerPrefs.GetInt(MediumDiffCoinScore);
    }

    public static void SetMediumDiffCoinScore(int state)
    {
        PlayerPrefs.SetInt(MediumDiffCoinScore, state);
    }

    public static int GetHardDiffCoinScore()
    {
        return PlayerPrefs.GetInt(HardDiffCoinScore);
    }

    public static void SetHardDiffCoinScore(int state)
    {
        PlayerPrefs.SetInt(HardDiffCoinScore, state);
    }



}