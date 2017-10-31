module Renderer

open TypeRepository
open System
open ShapeRenderer
open Draw

let TileToChar tile = 
    match tile with
    | Unblocked -> " "
    | Block -> "¥"
    | Creature -> "M"

let DrawItem item worldCoordinates =
    match item with
    | TypeRepository.Weapon -> TileToChar item |> Draw ConsoleColor.Red worldCoordinates //Vi behöver göra konstruktorer för dessa verkar det som :/
    | Utility -> TileToChar item |> Draw ConsoleColor.Yellow worldCoordinates

let DrawTile xYTuple tile x y = 
    let playerScreenCoordinates = {x = 20 ; y = 10}
    let worldCoordinates = {x = playerScreenCoordinates.x + x - xYTuple.x ; y = playerScreenCoordinates.y + y - xYTuple.y}
    Draw ConsoleColor.Yellow playerScreenCoordinates "O"
    
    match tile with
    | Unblocked -> TileToChar tile |> Draw ConsoleColor.DarkGreen worldCoordinates
    | Block -> TileToChar tile |> Draw ConsoleColor.DarkGreen worldCoordinates
    | Item ->  DrawItem tile worldCoordinates
    | Monster -> TileToChar tile |> Draw ConsoleColor.DarkRed worldCoordinates
                
    
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