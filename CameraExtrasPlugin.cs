using BepInEx;
using System;
using UnityEngine;

namespace CameraExtras;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.foxyrobo.cameraextras")]
public partial class CameraExtrasPlugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Put your initialization logic here
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");

        Configuration.Init(Config);
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
        }
    }
}
