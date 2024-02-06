
using System.Collections.Generic;

[System.Serializable]
public class TextEntry
{
    public string Key;
    public string Text;
}

[System.Serializable]
public class LocalizedComponent
{
    public List<TextEntry> textComponents;
}