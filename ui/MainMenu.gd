extends Control

func _ready():
	var new_game_btn = $VBoxContainer/NewGameButton
	var load_game_btn = $VBoxContainer/LoadGameButton
	var quit_btn = $VBoxContainer/QuitButton

	new_game_btn.pressed.connect(_on_new_game_pressed)
	load_game_btn.pressed.connect(_on_load_game_pressed)
	quit_btn.pressed.connect(_on_quit_pressed)

func _on_new_game_pressed():
	get_tree().change_scene_to_file("res://main.tscn")

func _on_load_game_pressed():
	print("Load Game pressed (stub)")
	var save_manager = get_node_or_null("/root/SaveManager")
	if save_manager and save_manager.has_method("load_game"):
		save_manager.load_game()
	else:
		print("SaveManager not found, starting new game.")
	get_tree().change_scene_to_file("res://main.tscn")

func _on_quit_pressed():
	get_tree().quit()
