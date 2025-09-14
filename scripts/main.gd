extends Node

@onready var player = $Player
@onready var world = $World
@onready var save_manager: SaveManager = SaveManager.new()

func _ready():
    add_child(save_manager)

func _input(event):
    if event.is_action_pressed("ui_save"):
        save_manager.save_game(player, world)
    elif event.is_action_pressed("ui_load"):
        save_manager.load_game(player, world)
