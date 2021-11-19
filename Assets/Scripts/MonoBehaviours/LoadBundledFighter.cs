using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBundledFighter : MonoBehaviour
{
    public string bundleToLoad = "testfighter.ptf";

    // Start is called before the first frame update
    void Start()
    {
        AssetBundle fighterBundle = AssetBundle.LoadFromFile($"Assets/AssetBundles/{bundleToLoad}");
        string[] fighterScenes = fighterBundle.GetAllScenePaths();
        SceneManager.LoadScene(fighterScenes[0], LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
