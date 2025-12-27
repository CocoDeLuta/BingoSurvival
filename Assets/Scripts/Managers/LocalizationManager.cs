using UnityEngine;
using System.Collections.Generic;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    public List<LocalizationTable> languages;
    public string defaultLanguage = "pt-BR";

    private LocalizationTable current;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetLanguage(defaultLanguage);
        }
        else Destroy(gameObject);
    }

    public void SetLanguage(string code)
    {
        current = languages.Find(l => l.languageCode == code);

        if (current == null)
            Debug.LogError("Idioma não encontrado: " + code);
    }

    public string Get(string key)
    {
        if (current == null) return key;
        return current.Get(key);
    }
}
