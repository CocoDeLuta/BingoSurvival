using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Localization/Language Table")]
public class LocalizationTable : ScriptableObject
{
    public string languageCode; // "pt-BR", "en-US"

    public List<Entry> entries = new();

    [System.Serializable]
    public class Entry
    {
        public string key;
        [TextArea] public string value;
    }

    private Dictionary<string, string> _dict;

    public void Init()
    {
        _dict = new Dictionary<string, string>();
        foreach (var e in entries)
        {
            if (!_dict.ContainsKey(e.key))
                _dict.Add(e.key, e.value);
        }
    }

    public string Get(string key)
    {
        if (_dict == null) Init();
        return _dict.TryGetValue(key, out var value) ? value : $"#{key}#";
    }
}
