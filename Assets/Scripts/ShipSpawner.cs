using UnityEngine;
using UnityEditor;

public class ShipSpawner : MonoBehaviour
{
    // If you want to have fun, put startingShipAmount at 5000, you'll see the whole spawning range, it's fun


    [SerializeField] GameObject enemyShipPrefab;
    [SerializeField] int startingShipAmount, buttonShipAmount;

    public static ShipSpawner _instance;


    // ======================== [DEFAULT UNITY METHODS] ========================
    void Awake()
    {
        _instance = this;
    
        // In awake and not start because the ring will take its first target in start
        for (int i = 0; i < startingShipAmount; i++)
        {
            Instantiate(enemyShipPrefab, Vector3.zero, Quaternion.identity);
        }

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // ======================== [SCRIPT METHODS] ========================

    public void SpawnShipWave()
    {
        for (int i = 0; i < buttonShipAmount; i++)
        {
            Instantiate(enemyShipPrefab, Vector3.zero, Quaternion.identity);
        }
    }

}

[CustomEditor(typeof(ShipSpawner))]
public class ShipSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Spawn Ship Wave"))
        {
            ShipSpawner._instance.SpawnShipWave();
        }
    }
}
