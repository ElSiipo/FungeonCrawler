module Render

open Types
open System
open ShapeRenderer
open Draw

let TileToChar tile = 
    match tile with
    | Unblocked -> " "
    | Block -> "¥"
    | Monster -> "M"

let DrawTile xYTuple tile x y = 
    let playerScreenCoordinates = {x = 20 ; y = 10}
    let worldCoordinates = {x = playerScreenCoordinates.x + x - xYTuple.x ; y = playerScreenCoordinates.y + y - xYTuple.y}
    Draw ConsoleColor.Yellow playerScreenCoordinates.x playerScreenCoordinates.y "O"
    
    match tile with
    | Unblocked -> TileToChar tile |> Draw ConsoleColor.DarkGreen worldCoordinates.x worldCoordinates.y 
    | Block -> TileToChar tile |> Draw ConsoleColor.DarkGreen worldCoordinates.x worldCoordinates.y 
    | Monster -> TileToChar tile |> Draw ConsoleColor.DarkRed worldCoordinates.x worldCoordinates.y
    
let RenderWorld (world:Tile[][]) xYTuple =
    for x = xYTuple.x - 15 to xYTuple.x + 15 do
        for y = xYTuple.y - 7 to xYTuple.y + 7 do
            if x > 0 && x < world.Length && y > 0 && y < world.Length then 
                DrawTile xYTuple world.[x].[y] x y
                
let PrintCreatureInfo creature = 
    Console.SetCursorPosition(0, 0)
    cprintf ConsoleColor.White "Name: %O, level: %A, experience points: %A\n" creature.Name creature.Level creature.ExperiencePoints
    cprintf ConsoleColor.White "Health: %O, damage: %A" creature.Health creature.Damage

let RenderUI creature =
    PrintCreatureInfo creature
    DrawRect ConsoleColor.Cyan 5 18 35 28 
    DrawRect ConsoleColor.DarkYellow 36 2 46 17

let Render state creature =
    RenderUI creature
    RenderWorld state.World creature.Coordinates