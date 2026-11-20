// Gives access to File and Path
using System.IO;
// Gives access to MonoBehaviour, JsonUtility and Application
using UnityEngine;
// Gives access to Keyboard
using UnityEngine.InputSystem;

// Counts Space presses and saves the count to a JSON file, so it survives pressing Stop
public class SpaceCounter : MonoBehaviour
{
    // The data we save and load
    private CounterData data;
    // Where the save file lives
    private string path;

    // Runs once when you press Play
    private void Start()
    {
        // Unity's save folder plus our file name
        path = Path.Combine(Application.persistentDataPath, "counter.json");
        // Show where the file is, so we can go and look at it
        Debug.Log("Save file: " + path);

        // Load whatever was saved last time
        data = Load();
        Debug.Log("Loaded count: " + data.GetCount());
    }

    // Runs every frame
    private void Update()
    {
        // Space pressed this frame: count it and save straight away
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            data.AddOne();
            Save();
            Debug.Log("Count: " + data.GetCount());
        }
    }

    // Writes the data to the file
    private void Save()
    {
        // Object to text; true makes the text easy to read
        string json = JsonUtility.ToJson(data, true);
        // Text to file; makes the file if it isn't there yet
        File.WriteAllText(path, json);
    }

    // Reads the file back, or hands back a fresh CounterData if there isn't one
    private CounterData Load()
    {
        // First time: no file yet, so start at 0
        if (!File.Exists(path))
        {
            return new CounterData();
        }

        // try: a file someone could have broken is risky to read
        try
        {
            // File to text
            string json = File.ReadAllText(path);
            // Text to object
            CounterData loaded = JsonUtility.FromJson<CounterData>(json);

            // An empty file gives back null: start fresh
            if (loaded == null)
            {
                return new CounterData();
            }

            // Hand back what was saved
            return loaded;
        }
        // catch: the file was broken, so start fresh instead of crashing
        catch (System.Exception e)
        {
            Debug.LogWarning("Couldn't read the save file, starting fresh. (" + e.Message + ")");
            return new CounterData();
        }
    }
}