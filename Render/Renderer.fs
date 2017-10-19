module Renderer

open TypeRepository
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
    | Item ->  match tile with
                | Utility -> TileToChar tile |> Draw ConsoleColor.Yellow worldCoordinates.x worldCoordinates.y 
                | Weapon -> TileToChar tile |> Draw ConsoleColor.Red worldCoordinates.x worldCoordinates.y // Send in worldCoordinates instead
    
let RenderWorld (world:Tile[][]) heroPosition =
    for x = heroPosition.x - 15 to heroPosition.x + 15 do
        for y = heroPosition.y - 7 to heroPosition.y + 7 do
            if x > 0 && x < world.Length && y > 0 && y < world.Length then 
                DrawTile heroPosition world.[x].[y] x y
                
let PrintCreatureInfo (creature:Creature) = 
    Console.SetCursorPosition(0, 0)
    cprintf ConsoleColor.White "Name: %O, level: %A, experience points: %A\n" creature.Name creature.Level creature.ExperiencePoints
    cprintf ConsoleColor.White "Health: %O, damage: %A" creature.Health creature.Damage

let RenderUI creature =
    PrintCreatureInfo creature
    DrawRect ConsoleColor.Cyan 5 18 35 28 
    DrawRect ConsoleColor.DarkYellow 36 2 46 17

let Render state hero =
    RenderUI hero
    RenderWorld state.World hero.Coordinates