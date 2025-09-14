using Godot;
using System;

public partial class SaveManager : Node
{
    private const string SAVE_PATH = "user://saves/savegame.json";

    public void SaveGame(Player player, World world)
    {
        var data = new Godot.Collections.Dictionary
        {
            {"player", player.GetState()},
            {"world", world.GetState()}
        };
        using var file = FileAccess.Open(SAVE_PATH, FileAccess.ModeFlags.Write);
        file.StoreString(JSON.Stringify(data, "	"));
        GD.Print("Game saved to " + SAVE_PATH);
    }

    public void LoadGame(Player player, World world)
    {
        if (!FileAccess.FileExists(SAVE_PATH))
        {
            GD.Print("No save file found.");
            return;
        }
        using var file = FileAccess.Open(SAVE_PATH, FileAccess.ModeFlags.Read);
        var text = file.GetAsText();
        var data = (Godot.Collections.Dictionary)Json.ParseString(text);
        player.ApplyState((Godot.Collections.Dictionary)data["player"]);
        world.ApplyState((Godot.Collections.Dictionary)data["world"]);
        GD.Print("Game loaded.");
    }
}
