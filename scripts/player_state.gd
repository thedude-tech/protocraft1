extends Resource
class_name PlayerState

@export var health: int = 100
@export var stamina: int = 100
@export var position: Vector3 = Vector3.ZERO
@export var inventory: Dictionary = {}
@export var xp: int = 0
@export var skills: Array = []

func to_dict() -> Dictionary:
    return {
        "health": health,
        "stamina": stamina,
        "position": position,
        "inventory": inventory,
        "xp": xp,
        "skills": skills
    }

func from_dict(data: Dictionary) -> void:
    health = data.get("health", health)
    stamina = data.get("stamina", stamina)
    position = data.get("position", position)
    inventory = data.get("inventory", inventory)
    xp = data.get("xp", xp)
    skills = data.get("skills", skills)
