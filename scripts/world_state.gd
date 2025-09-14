extends Resource
class_name WorldState

@export var seed: int = 12345
@export var time_of_day: float = 0.0
@export var machines: Array = []

func to_dict() -> Dictionary:
    return {
        "seed": seed,
        "time_of_day": time_of_day,
        "machines": machines
    }

func from_dict(data: Dictionary) -> void:
    seed = data.get("seed", seed)
    time_of_day = data.get("time_of_day", time_of_day)
    machines = data.get("machines", machines)
