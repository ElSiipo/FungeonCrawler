module Initialization

open System
open Types

let rnd = Random()

let InitializeCreature name =
    let creature : Creature = {Name = name; Health = Random().Next(80, 120) ; Damage = 1; Level = 1; ExperiencePoints = 0; Coordinates = {x = 10; y = 10}}
    
    creature

let GetRandomTile i = 
    let nextRand = rnd.Next(0, 100)
    match nextRand > 30 with
    |true -> Unblocked
    |_ -> Block

let CreateWorld size = 
    let makeLineOfTiles2 = fun _ -> Array.init size (fun i -> GetRandomTile i)
    Array.init size (fun _ -> makeLineOfTiles2())