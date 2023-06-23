using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class CrusorControler : MonoBehaviour
{
    public Texture2D mouseIcon_Nor;
    Scene m_Scene;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        Cursor.SetCursor(mouseIcon_Nor, Vector2.zero, CursorMode.ForceSoftware);
        if(sceneName== "Scene_2")
        {
            Cursor.visible = false;
        }
    }
}
