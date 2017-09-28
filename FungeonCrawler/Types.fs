module Types

type XYTuple = {x : int ; y : int}
type Creature = {Name : string; Health : int; Damage : int; Level : int; ExperiencePoints : int; Coordinates : XYTuple}
type Tile = Unblocked | Block | Monster

type State = {World : Tile [][] ; Creature : Creature}