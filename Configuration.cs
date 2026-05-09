using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

/// Class used for keybinds and other configurable settings 
internal static class Configuration
{
    // Keybinds
    static ConfigEntry<KeyCode>? _freezeCamera;
    public static KeyCode FreezeCamera => _freezeCamera?.Value ?? KeyCode.None;
    static ConfigEntry<KeyCode>? _hideUI;
    public static KeyCode HideUI => _hideUI?.Value ?? KeyCode.None;

    public static void Init(ConfigFile config)
    {
        // Keybinds
        _freezeCamera = config.Bind("Keybinds", "Freeze Camera", KeyCode.B);
        _hideUI = config.Bind("Keybinds", "Hide UI", KeyCode.L);
    }
}
