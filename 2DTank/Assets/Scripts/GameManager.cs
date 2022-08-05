using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public SaveSystem saveSystem;

    private void Awake()
    {
        SceneManager.sceneLoaded += Initialize;
        DontDestroyOnLoad(gameObject);
    }

    private void Initialize (Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("Loaded GameManager");
        var playerInput = FindObjectOfType<MoveScript>();
        if (playerInput != null)
            player = playerInput.gameObject;

        saveSystem = FindObjectOfType<SaveSystem>();

        if (player != null && saveSystem.LoadedData != null)
        {
            var damagable = player.GetComponent<TankHealthSystem>();
            damagable.currentHealth = saveSystem.LoadedData.playerHealth;
        }
    }

    public void LoadLevel()
    {
        if (saveSystem.LoadedData != null)
        {
            SceneManager.LoadScene(saveSystem.LoadedData.sceneIndex);
            return;
        }
        LoadNextLevel();

    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveData()
    {
        if (player != null)
        {
            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex + 1, player.GetComponent<TankHealthSystem>().currentHealth);
        }
    }
}
