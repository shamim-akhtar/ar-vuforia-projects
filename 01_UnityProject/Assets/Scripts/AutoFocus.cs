using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AutoFocus : MonoBehaviour
{
    private bool m_vuforiaStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        VuforiaARController vuforia = VuforiaARController.Instance;
        if (vuforia != null)
        {
            vuforia.RegisterVuforiaStartedCallback(InitCameraAutoFocus);
        }
    }

    private void InitCameraAutoFocus()
    {
        m_vuforiaStarted = true;
        SetAutoFocus();
    }

    private void SetAutoFocus()
    {
        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
        {
            Debug.Log("Success in setting camera to autofocus continuously.");
        }
        else
        {
            Debug.Log("Failed to set camera to autofocus continuously.");
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // since app has resumed we will start autofocus.
            SetAutoFocus();
        }
    }
}
