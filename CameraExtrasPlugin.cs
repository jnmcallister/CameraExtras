using BepInEx;
using System;
using UnityEngine;

namespace CameraExtras;

[BepInAutoPlugin(id: "io.github.foxyrobo.cameraextras")]
public partial class CameraExtrasPlugin : BaseUnityPlugin
{
    bool cameraFrozen = false;
    bool uiHidden = false;

    CameraController cameraController;
    HUDCamera hudCamera;
    Camera uiCamera; // Component on hudCamera gameObject

    private void Awake()
    {
        // Put your initialization logic here
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");

        // Initialize classes
        Configuration.Init(Config);
    }

    void Start()
    {
        // Cache camera components
        cameraController = GameObject.FindFirstObjectByType<CameraController>();
        hudCamera = GameObject.FindFirstObjectByType<HUDCamera>();
        if (hudCamera != null) 
            uiCamera = hudCamera.GetComponent<Camera>();
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
        if (InputHelper.HideUIDown)
        {
            Logger.LogInfo("Hide UI button pressed");
            ToggleHideUI();
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
            else
            {
                Logger.LogInfo("Camera controller found!");
            }
        }

        // Toggle freezing/unfreezing camera controller
        if (cameraFrozen)
            cameraController.FreezeInPlace();
        else
            cameraController.StopFreeze();
        cameraFrozen = !cameraFrozen;
    }

    public void ToggleHideUI()
    {
        // Make sure HUDCamera exists
        if (hudCamera == null)
        {
            Logger.LogWarning("No HUDCamera found! Trying again");

            // If none was found, try to find it again
            hudCamera = GameObject.FindFirstObjectByType<HUDCamera>();
            if (hudCamera == null)
            {
                Logger.LogError("No HUDCamera found!");
                return;
            }
            else
            {
                Logger.LogInfo("HUDCamera found!");
            }
        }

        // Make sure camera exists
        if (uiCamera == null)
        {
            Logger.LogWarning("No UI camera found! Trying again");

            // If none was found, try to find it again
            uiCamera = hudCamera.GetComponent<Camera>();
            if (uiCamera == null)
            {
                Logger.LogError("No UI camera found!");
                return;
            }
            else
            {
                Logger.LogInfo("UI camera found!");
            }
        }

        // Toggle hiding/unhiding UI
        uiHidden = !uiHidden;
        uiCamera.enabled = !uiHidden;
    }
}
