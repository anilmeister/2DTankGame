using UnityEngine;
using UnityEngine.Events;

public class SaveSystem : MonoBehaviour
{

    //Player prefs a basic way to save data between sessions

    public string playerHealthKey = "PlayerHealth", sceneKey = "SceneIndex", savePresentKey = "SavePresent";

    public LoadedData LoadedData { get; private set; }

    public UnityEvent<bool> OnDataLoadedResult;

    private void Awake()
    {
        //To not destroy when changing scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        var result = LoadData();
        OnDataLoadedResult?.Invoke(result);
       
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteKey(playerHealthKey);
        PlayerPrefs.DeleteKey(savePresentKey);
        PlayerPrefs.DeleteKey(sceneKey);
        LoadedData = null;
    }
    public void SaveData(int sceneIndex, float playerHealth)
    {
        if (LoadedData == null)
            LoadedData = new LoadedData();
        LoadedData.playerHealth = playerHealth;
        LoadedData.sceneIndex = sceneIndex;
        PlayerPrefs.SetInt(savePresentKey, 1);
        PlayerPrefs.SetFloat(playerHealthKey, playerHealth);
        PlayerPrefs.SetInt(sceneKey, sceneIndex);
    }
    public bool LoadData()
    {
        if (PlayerPrefs.GetInt(savePresentKey) == 1)
        {
            LoadedData = new LoadedData();
            LoadedData.playerHealth = PlayerPrefs.GetFloat(playerHealthKey);
            LoadedData.sceneIndex = PlayerPrefs.GetInt(sceneKey);
            return true;
        }

        return false;
    }
}


public class LoadedData
{
    public float playerHealth = -1;
    public int sceneIndex = -1;
}
