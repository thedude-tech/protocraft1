extends Resource
class_name MachineState

@export var machine_id: String = ""
@export var position: Vector3 = Vector3.ZERO
@export var input: Dictionary = {}
@export var output: Dictionary = {}
@export var progress: float = 0.0

func to_dict() -> Dictionary:
    return {
        "machine_id": machine_id,
        "position": position,
        "input": input,
        "output": output,
        "progress": progress
    }

func from_dict(data: Dictionary) -> void:
    machine_id = data.get("machine_id", machine_id)
    position = data.get("position", position)
    input = data.get("input", input)
    output = data.get("output", output)
    progress = data.get("progress", progress)
