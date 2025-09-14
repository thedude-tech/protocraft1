extends Node
class_name SaveManager

const SAVE_PATH := "user://saves/savegame.json"

func save_game(player: Node, world: Node) -> void:
    var data = {
        "player": player.get_state(),
        "world": world.get_state()
    }
    var file = FileAccess.open(SAVE_PATH, FileAccess.WRITE)
    file.store_string(JSON.stringify(data, "\t"))
    file.close()
    print("Game saved to ", SAVE_PATH)

func load_game(player: Node, world: Node) -> void:
    if not FileAccess.file_exists(SAVE_PATH):
        print("No save file found.")
        return
    var file = FileAccess.open(SAVE_PATH, FileAccess.READ)
    var data = JSON.parse_string(file.get_as_text())
    file.close()
    if typeof(data) == TYPE_DICTIONARY:
        player.apply_state(data.get("player", {}))
        world.apply_state(data.get("world", {}))
        print("Game loaded.")
