extends Control


func _on_new_game_pressed() -> void:
	get_tree().change_scene_to_file("res://main.tscn")

func _on_load_game_pressed() -> void:
	pass # Replace with function body.


func _on_option_pressed() -> void:
	pass # Replace with function body.


func _on_exit_pressed() -> void:
	get_tree().quit() # Replace with function body.
