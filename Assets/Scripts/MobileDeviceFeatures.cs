using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileDeviceFeatures : MonoBehaviour
{
    public bool forceShow = false;
    public GameObject UIControls;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android || forceShow) {
            Debug.Log("MobileDeviceFeatures: Mobile device detected");
            UIControls.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
