module TypeRepository

type XYTuple = {x : int ; y : int}
type Creature = {Name : string; Health : int; Damage : int; Level : int; ExperiencePoints : int; Coordinates : XYTuple}

type Weapon = {Name : string; Damage : int}
type Utility = {Name : string}
type Item = WeaponItem of Weapon | UtilityItem of Utility

type Tile = Unblocked | Block | MonsterTile of Creature | ItemTile of Item
type Obstacle = Tree | Stone 



type State = {World : Tile [][] ; Creature : Creature}