module Program

open System
open Types
open Initialization
open Render
open Control

let newStateFromCreature state creature =
    {State.Creature = creature ; World = state.World}

let rec mainLoop state =
    //Threading.Thread.Sleep(10)
    //Console.Clear()

    let creature = checkGetMove state.World state.Creature
    let newState = newStateFromCreature state creature

    PresentToConsole creature
    RenderWorld state.World creature.Coordinates

    mainLoop newState


[<EntryPoint>]
let game argv = 
    let creature = InitializeCreature
    let world = CreateWorld 100
    
    Console.Clear()
    mainLoop {World = world ; Creature = creature}

    let line = Console.ReadLine();

    0 // return an integer exit code
