using UnityEngine;
using UnityEngine.Events;

public class SaveSystem : MonoBehaviour
{

    //Player prefs a basic way to save data between sessions

    public string playerHealthKey = "PlayerHealth", sceneKey = "SceneIndex", savePresentKey = "SavePresent";

    public LoadedData LoadedData { get; private set; }

    public UnityEvent<bool> OnDataLoadedResult;

    private bool isInitializes = false;
}


public class LoadedData
{
    public float playerHealth = -1;
    public int sceneIndex = -1;
}
