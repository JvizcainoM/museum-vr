using UnityEngine;

public static class MuseumApp
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Bootstrap()
    {
        var context = new GameObject("MuseumAppContext")
        {
            hideFlags = HideFlags.HideAndDontSave,
            isStatic = true,
        };

        context.AddComponent<AudioManager>();

        Object.DontDestroyOnLoad(context.gameObject);
    }
}