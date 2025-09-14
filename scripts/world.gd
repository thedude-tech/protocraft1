extends Node3D

var state := WorldState.new()

func get_state() -> Dictionary:
    state.machines.clear()
    for m in get_tree().get_nodes_in_group("machines"):
        state.machines.append(m.get_state())
    return state.to_dict()

func apply_state(data: Dictionary) -> void:
    state.from_dict(data)
    # Later: spawn/restore machines here
