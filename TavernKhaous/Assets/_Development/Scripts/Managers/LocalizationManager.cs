using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Language
{
    PT,
    EN
}

public class LocalizationManager : MonoBehaviour
{
    private Dictionary<string, string> PT_BR;
    private Dictionary<string, string> EN;
    private Dictionary<string, string>[] languages;

    public TextAsset [] files;
    private Language gameLanguage;
    private int languageIndex;

    public void Init()
    {
        PT_BR = new Dictionary<string, string>();
        EN = new Dictionary<string, string>();

        languages = new Dictionary<string, string>[2]
        {
            new Dictionary<string, string>(),
            new Dictionary<string, string>()
        };

        gameLanguage = Language.PT;

        for(int i = 0; i < files.Length; i++)
        {
            BuildDictionary(files[i], i);
        }
    }

    private void BuildDictionary(TextAsset file, int index)
    {
        Dictionary<string, string> readFiles = JsonUtils.Read<Dictionary<string,string>>(file);
        
        foreach(KeyValuePair<string, string> entry in readFiles)
        {
            languages[index].Add(entry.Key, entry.Value);
        }

        GetTranslation("waiter_verySatisfiedThanks");
    }

    public string GetTranslation(string key)
    {
        languageIndex = gameLanguage switch
        {
            Language.PT => languageIndex = 0,
            Language.EN => languageIndex = 1,
            _ => throw new ArgumentException(message: "invalid language")
        };

        string txt = languages[0][key];
        
        if(txt != "")
            return txt;

        return null;
    }

    public void ChangeCurrentLanguage(Language newLanguage)
    {
        gameLanguage = newLanguage;
    }
}
