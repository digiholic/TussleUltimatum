using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FighterInfoLoader : MonoBehaviour
{
    public FighterInfo infoObject;
    public TextAsset infoFile;

    // Start is called before the first frame update
    void Start()
    {
        if (infoFile != null) infoObject = FighterInfo.fromJson(infoFile.text);
        Debug.Log(infoObject.DisplayName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log(infoObject.toJson());
            File.WriteAllText("Assets/test.json", infoObject.toJson());
        }
    }
}
