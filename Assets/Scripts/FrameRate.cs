using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    public int target;
    // Start is called before the first frame update
    private void Awake()
    {
        target = 60;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }
    // Update is called once per frame
    void Update()
    {
        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }
}
