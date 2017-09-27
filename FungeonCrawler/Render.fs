module Render

open Types
open System

let PresentToConsole creature = 
    Console.SetCursorPosition(0, 0)
    printfn "Name: %O, level: %A, experience points: %A" creature.Name creature.Level creature.ExperiencePoints
    printfn "Health: %O, damage: %A" creature.Health creature.Damage

let Draw x y (char : string) =
    Console.SetCursorPosition(x, y)
    Console.Write(char)

let TileToChar tile = 
    match tile with
    |Tile.Unblocked -> " "
    |_ -> "#"

let DrawTile xYTuple tile x y = 
    let playerScreenCoordinates = {x = 20 ; y = 10}
    let worldCoordinates = {x = playerScreenCoordinates.x + x - xYTuple.x ; y = playerScreenCoordinates.y + y - xYTuple.y}
    
    Draw playerScreenCoordinates.x playerScreenCoordinates.y "O"
    TileToChar tile |> Draw worldCoordinates.x worldCoordinates.y
    

let RenderWorld (world:Tile[][]) xYTuple =
    for x = xYTuple.x - 5 to xYTuple.x + 5 do
        for y = xYTuple.y - 2 to xYTuple.y + 2 do
            DrawTile xYTuple world.[x].[y] x y
            // Todo: Fix out of bounds exception