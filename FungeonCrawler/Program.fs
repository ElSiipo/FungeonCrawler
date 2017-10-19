module Program

open System
open TypeRepository
open Initialization
open Renderer
open Control

let newStateFromCreature state creature =
    {State.Creature = creature ; World = state.World}

let rec mainLoop state =
    let creature = checkGetMove state.World state.Creature
    let newState = newStateFromCreature state creature
    
    Render state creature
    
    mainLoop newState


[<EntryPoint>]
let game argv = 
    printf "Name of creature: "
    let name = Console.ReadLine()
    let creature = InitializeCreature name
    let world = CreateWorld 100
    
    Console.Clear()
    mainLoop {World = world ; Creature = creature}

    let line = Console.ReadLine();

    0 // return an integer exit code
