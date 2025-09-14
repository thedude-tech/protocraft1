extends CharacterBody3D

var state := PlayerState.new()

func _ready():
    apply_state(state)

func get_state() -> Dictionary:
    state.position = global_transform.origin
    return state.to_dict()

func apply_state(data: Dictionary) -> void:
    state.from_dict(data)
    global_transform.origin = state.position
