// Lets JsonUtility turn this class into JSON text and back
using UnityEngine;

[System.Serializable]
// The data we save; a plain class, not a MonoBehaviour
public class CounterData
{
    // How many times Space has been pressed; [SerializeField] lets JsonUtility save it
    [SerializeField] private int count;

    // Adds one to the count
    public void AddOne()
    {
        // One more
        count++;
    }

    // Reads the count without changing it
    public int GetCount()
    {
        // Hand back the count
        return count;
    }
}