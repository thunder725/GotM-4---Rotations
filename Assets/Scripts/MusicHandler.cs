using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    
    public static MusicHandler instance;

    // ======================== [DEFAULT UNITY METHODS] ========================
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // ======================== [SCRIPT METHODS] ========================

}
