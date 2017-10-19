module TypeRepository

type XYTuple = {x : int ; y : int}
type Creature = {Name : string; Health : int; Damage : int; Level : int; ExperiencePoints : int; Coordinates : XYTuple}

type Weapon = {Name : string; Damage : int}
type Utility = {Name : string}
type Item = Weapon | Utility

type Tile = Unblocked | Block | Monster | Item
type Obstacle = Tree | Stone 



type State = {World : Tile [][] ; Creature : Creature}