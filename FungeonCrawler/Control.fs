module Control

open System
open Types

let MoveCreature creature move = 
    let newCoordinates = {x = creature.Coordinates.x + move.x ; y = creature.Coordinates.y + move.y }
    {Name = creature.Name ; Health = creature.Health ; Damage = creature.Damage ; Level = creature.Level ; ExperiencePoints = creature.ExperiencePoints ; Coordinates = newCoordinates}
    
let checkMoveValid (world:Tile[][]) x newX y newY = 
    if x + newX > 0 && x + newX < world.Length && y + newY > 0 && y + newY < world.Length then
        let tile = world.[x + newX].[y + newY]
        if tile = Unblocked then 
            true
        else false
    else false

let Control (world:Tile[][]) creature =
    let key = Console.ReadKey(true)
    match key.Key with
    | ConsoleKey.UpArrow -> if checkMoveValid world creature.Coordinates.x 0 creature.Coordinates.y -1 then MoveCreature creature {XYTuple.x = 0; y = -1} else creature
    | ConsoleKey.RightArrow -> if checkMoveValid world creature.Coordinates.x 1 creature.Coordinates.y 0 then MoveCreature creature {XYTuple.x = 1; y = 0} else creature
    | ConsoleKey.DownArrow -> if checkMoveValid world creature.Coordinates.x 0 creature.Coordinates.y 1 then MoveCreature creature {XYTuple.x = 0; y = 1} else creature
    | ConsoleKey.LeftArrow -> if checkMoveValid world creature.Coordinates.x -1 creature.Coordinates.y 0 then MoveCreature creature {XYTuple.x = -1; y = 0} else creature
    | _ -> creature

let checkGetMove world creature =
    match Console.KeyAvailable with
    | true -> Control world creature
    | _ -> creature