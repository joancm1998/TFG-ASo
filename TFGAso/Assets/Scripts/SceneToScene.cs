using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneToScene : MonoBehaviour
{
    public static TextAsset songInformation;

    public static int targetScene;

    public void setTargetScene(int target)
    {
        targetScene = target;
    }
}
