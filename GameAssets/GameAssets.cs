/*===========================================================================================
----------------------------------------REFERENCE CLASS--------------------------------------
This class is used as a static reference to multiple usable objects.
-----------------------------------------OBSERVATIONS----------------------------------------
To ensure this works as expected, follow these steps:
1. Create a folder named "Resources" inside your main Assets folder.
2. Inside the Resources folder, create an empty prefab and name it "GameAssets".
3. Attach the GameAssets script as a component to this prefab.
This setup allows the script to dynamically instantiate the GameAssets prefab from the
Resources folder at runtime.
===========================================================================================*/
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;

    public static GameAssets instance
    {
        get
        {
            if (_instance == null) _instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _instance;
        }
        private set { }
    }

    // It is recommended to organize your script with headers for better readability. 
    // This approach also helps to keep track of different categories of variables.
    [Header("Loaded On Start")]
    public GameObject Player;

    // Example of using Awake to load the Player reference.
    // Note: This will throw an exception if there is no GameObject named "Player" in the scene.
    private void Awake()
    {
        try
        {
            Player = GameObject.Find("Player");
            if (Player == null) throw new System.Exception("GameAssets couldn't locate the Player.");
        }
        catch (System.Exception e) { Debug.LogException(e); }
    }

    // Example of how to store different types of data in this script.
    // Each category is organized with headers to separate the purpose of the variables.
    /*
    [Header("Datas")]
    public PlayerMovementData PlayerMovementData;
    public EnhancedCollisionData EnhancedCollisionData;
    public RenderData RenderData;

    [Header("Settings")]
    public GameplaySettingsData GameplaySettingsData;
    */
}