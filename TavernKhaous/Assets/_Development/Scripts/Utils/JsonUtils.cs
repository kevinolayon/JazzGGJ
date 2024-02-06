using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class JsonUtils
{
    public static T Read<T>(TextAsset file)
    {
        var text = JsonUtility.FromJson<T>(file.text);

        if (text != null)
            return text;

        return default(T);
    }
}
