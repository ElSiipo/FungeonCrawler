module Control

open System
open Types

let MoveCreature creature move = 
    let newCoordinates = {x = creature.Coordinates.x + move.x ; y = creature.Coordinates.y + move.y }
    {Name = creature.Name ; Health = creature.Health ; Damage = creature.Damage ; Level = creature.Level ; ExperiencePoints = creature.ExperiencePoints ; Coordinates = newCoordinates}
    
let checkMoveValid (world:Tile[][]) xYTuple = 
    if xYTuple.x > 0 && xYTuple.x < world.Length && xYTuple.y > 0 && xYTuple.y < world.Length then
        match world.[xYTuple.x].[xYTuple.y] with
        | Unblocked -> true
        | _ -> false
    else false

let createTupleXy creature x y =
    {x = creature.Coordinates.x + x; y = creature.Coordinates.y + y}

let Control (world:Tile[][]) creature =
    let key = Console.ReadKey(true)
    match key.Key with
    | ConsoleKey.UpArrow -> if createTupleXy creature 0 -1 |> checkMoveValid world  then MoveCreature creature {XYTuple.x = 0; y = -1} else creature
    | ConsoleKey.RightArrow -> if createTupleXy creature 1 0 |> checkMoveValid world then MoveCreature creature {XYTuple.x = 1; y = 0} else creature
    | ConsoleKey.DownArrow -> if createTupleXy creature 0 1 |> checkMoveValid world then MoveCreature creature {XYTuple.x = 0; y = 1} else creature
    | ConsoleKey.LeftArrow -> if createTupleXy creature -1 0 |> checkMoveValid world then MoveCreature creature {XYTuple.x = -1; y = 0} else creature
    | _ -> creature

let checkGetMove world creature =
    match Console.KeyAvailable with
    | true -> Control world creature
    | _ -> creature