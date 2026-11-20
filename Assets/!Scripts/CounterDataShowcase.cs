using UnityEngine;

public class CounterDataShowcase : MonoBehaviour
{
    [SerializeField] private int count;

    public void AddOne()
    {
        count++;
    }

    public int GetCount()
    {
        return count;
    }
}
