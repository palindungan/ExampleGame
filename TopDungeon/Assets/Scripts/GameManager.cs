using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // PlayerPrefs.DeleteAll();

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public Player player;
    public FloatingTextManager floatingTextManager;

    // Logic
    public int pesos;
    public int experience;

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Save state
    /*
     * INT preferedSkin
     * INT pesos
     * INT experience
     * INT weaponLevel
     */
    public void SaveState()
    {
        Debug.Log("SaveState");

        string save = "";

        save += "0" + "|";
        save += pesos.ToString() + "|";
        save += experience.ToString() + "|";
        save += "0" + "|";

        PlayerPrefs.SetString("SaveState", save);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        Debug.Log("LoadState");

        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        // "0|10|15|2" -> ["0","10","15","2"]
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // preferedSkin = int.Parse(data[0]);
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        // weaponLevel = int.Parse(data[3]);
    }
}
