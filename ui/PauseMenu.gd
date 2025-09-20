extends Control

func _ready():
	visible = false
	var resume_btn = $VBoxContainer/Resume
	var save_btn = $VBoxContainer/Save
	var quit_btn = $VBoxContainer/Quit

	resume_btn.pressed.connect(_on_resume_pressed)
	save_btn.pressed.connect(_on_save_pressed)
	quit_btn.pressed.connect(_on_quit_pressed)

func _process(_delta):
	if Input.is_action_just_pressed("ui_cancel"):
		visible = not visible
		get_tree().paused = visible

func _on_resume_pressed():
	visible = false
	get_tree().paused = false

func _on_save_pressed():
	print("Save pressed (stub)")
	var save_manager = get_node_or_null("/root/SaveManager")
	if save_manager and save_manager.has_method("save_game"):
		save_manager.save_game()

func _on_quit_pressed():
	get_tree().paused = false
	get_tree().change_scene_to_file("res://ui/MainMenu.tscn")
