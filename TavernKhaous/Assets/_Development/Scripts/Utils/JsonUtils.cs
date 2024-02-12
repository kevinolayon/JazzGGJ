using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Newtonsoft.Json;

public static class JsonUtils
{
    public static T Read<T>(TextAsset file)
    {
        var text = JsonConvert.DeserializeObject<T>(file.text);

        if (text != null)
            return text;

        return default(T);
    }
}
