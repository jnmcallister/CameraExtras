using BepInEx;
using System;
using UnityEngine;

namespace CameraExtras;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.foxyrobo.cameraextras")]
public partial class CameraExtrasPlugin : BaseUnityPlugin
{
    bool cameraFrozen = false;

    CameraController cameraController;

    private void Awake()
    {
        // Put your initialization logic here
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");

        // Initialize classes
        Configuration.Init(Config);
    }

    void Start()
    {
        cameraController = GameObject.FindFirstObjectByType<CameraController>();
    }

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        // Check inputs
        if (InputHelper.FreezeCameraDown)
        {
            Logger.LogInfo("Freeze camera button pressed");
            ToggleFreezeCamera();
        }
    }

    public void ToggleFreezeCamera()
    {
        // Make sure camera controller exists
        if (cameraController == null)
        {
            Logger.LogWarning("No camera controller found! Trying again");

            // If none was found, try to find it again
            cameraController = GameObject.FindFirstObjectByType<CameraController>();
            if (cameraController == null)
            {
                Logger.LogError("No camera controller found!");
                return;
            }
        }

        // Toggle freezing/unfreezing camera controller
        if (cameraFrozen)
            cameraController.FreezeInPlace();
        else
            cameraController.StopFreeze();
        cameraFrozen = !cameraFrozen;
    }
}
