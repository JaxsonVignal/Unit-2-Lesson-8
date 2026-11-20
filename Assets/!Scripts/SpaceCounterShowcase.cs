using UnityEngine;
//gives access to file writing and reading 
using System.IO;
//gives access to input controls and reading 
using UnityEngine.InputSystem;

public class SpaceCounterShowcase : MonoBehaviour
{
    private CounterData data;
    private string path;






    //our save method to write our data to a JSON file
    private void Save()
    {
        //create a new sting with the data fields from our CounterData sript
        string json = JsonUtility.ToJson(data, true);
        //write the new string to the file on our pc at location "path"
        File.WriteAllText(path, json);
    }


    private CounterData Load()
    {

        if (!File.Exists(path))
        {
            return new CounterData();
        }

        try
        {
            string json = File.ReadAllText(path);

            CounterData loadedData = JsonUtility.FromJson<CounterData>(json);

            if(loadedData == null)
            {
                return new CounterData();
            }
            return loadedData;

        }catch(System.Exception e)
        {
            Debug.LogWarning("Couldnt load data");
            return new CounterData();
        }
    }
}
