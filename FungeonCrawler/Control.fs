module Control

open System
open Types

let MoveCreature creature move = 
    let newCoordinates = {x = creature.Coordinates.x + move.x ; y = creature.Coordinates.y + move.y }
    {Name = creature.Name ; Health = creature.Health ; Damage = creature.Damage ; Level = creature.Level ; ExperiencePoints = creature.ExperiencePoints ; Coordinates = newCoordinates}

let Control creature =
    let key = Console.ReadKey(true)
    match key.Key with
    | ConsoleKey.UpArrow -> if creature.Coordinates.y > 0 then MoveCreature creature {XYTuple.x = 0; y = -1} else creature
    | ConsoleKey.RightArrow -> if creature.Coordinates.x < 20 then MoveCreature creature {XYTuple.x = 1; y = 0} else creature
    | ConsoleKey.DownArrow -> if creature.Coordinates.y < 20 then MoveCreature creature {XYTuple.x = 0; y = 1} else creature
    | ConsoleKey.LeftArrow -> if creature.Coordinates.x > 0 then MoveCreature creature {XYTuple.x = -1; y = 0} else creature
    | _ -> creature

let checkGetMove creature =
    match Console.KeyAvailable with
    | true -> Control creature
    | _ -> creature