

class Weapon():
    
    def __init__(self, name:str, dammage:int, cost:int, weight:int, weapon_range:int = None, ranged_dammage:int = None):
        
        self.name = name
        self.dammage = dammage
        self.cost = cost
        self.weight = weight
        
        self.range = weapon_range
        self.ranged_dammage = ranged_dammage

class Armour():
    
    def __init__(self, name:str, protection:float, cost:int, weight:int):
        
        self.name = name
        self.protection = protection
        self.cost = cost
        self.weight = weight

class Shield():
    
    def __init__(self, name:str, protection:float, cost:int, weight:int):
        
        self.name = name
        self.protection = protection
        self.cost = cost
        self.weight = weight

class Horse():
    
    def __init__(self,name:str, speed:int, strength:int, cost:int, weight:int):
        
        self.name = name
        self.speed = speed
        self.strength = strength
        self.cost = cost
        self.weight = weight

class Unit():
    
    def __init__(
            self,
            row : int = 0,
            name : str = "New unit",
            tag : str = "NWU",
            rank: int = 1,
            weapon : Weapon = None,
            secondary_weapon : Weapon = None,
            armour : Armour = None,
            shield : Shield = None,
            horse : Horse = None,
            owner : object = None
        ):
        
        self.row = row
        self.name = name
        self.rank = rank
        
        self.weapon = weapon
        self.secondary_weapon = secondary_weapon
        self.armour = armour
        self.shield = shield
        self.horse = horse
        
        self.owner = owner
        self.tag = tag
        
        self.pv = None
        self.morale = None
        self.armour_level = armour.protection
        self.weight = weapon.weight + secondary_weapon.weight + armour.weight + shield.weight + horse.weight
        self.speed = (41 - self.weight + horse.strength) / 20 + 2
        self.attack = None
        self.defense = None
        self.shield_level = shield.protection
        self.dammage = weapon.dammage
        self.range = secondary_weapon.range
        self.ranged_dammage = secondary_weapon.ranged_dammage
        self.special_capacity = None
    
    def fight(self,target:object):
        
        inflicted_dammage = self.dammage * (1 + self.attack + self.speed - target.defense) * (1-target.armour)
        
        return inflicted_dammage
    
    def __repr__(self):
        
        return f"{self.tag}-{self.name}({self.weapon.cost + self.secondary_weapon.cost + self.armour.cost + self.shield.cost + self.horse.cost}pts)"
    
    def __str__(self):
        
        return f"{self.tag} | {self.name} ({(self.weapon.cost + self.secondary_weapon.cost + self.armour.cost + self.shield.cost + self.horse.cost)} pts) : [PV] {self.pv}, [MOR] {self.morale}, [ATT] {self.attack}, [DEF] {self.defense}, [WGH] {self.weight}, [SPD] {self.speed}"

### OBJECT DEFINITION

heavy_sword = Weapon(
    name = "Heavy sword",
    dammage = 10,
    cost = 5,
    weight = 5,
    weapon_range = 1,
    ranged_dammage = None
)

plated_armour = Armour(
    name = "Plated armour",
    protection = 0.5,
    cost = 10,
    weight  = 20
)

ecusson_shield = Shield(
    name = "Ecusson",
    protection = 0.2,
    cost = 5,
    weight = 5
)

mustang_horse = Horse(
    name = "Mustang",
    speed = 10,
    strength = 35,
    cost = 10,
    weight = 30
)

###

knight = Unit(
    row = 0,
    name = "Knight",
    tag = "KNI",
    rank = 1,
    weapon = heavy_sword,
    secondary_weapon = heavy_sword,
    armour = plated_armour,
    shield = ecusson_shield,
    horse = mustang_horse,
    owner = None
)