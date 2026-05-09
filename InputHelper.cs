using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

internal static class InputHelper
{
    public static bool FreezeCameraDown => Input.GetKeyDown(Configuration.FreezeCamera);
}
