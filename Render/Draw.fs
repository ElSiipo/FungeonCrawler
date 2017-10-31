module Draw
open System
open TypeRepository

let cprintf color value = 
    Printf.kprintf 
        (fun string -> 
            Console.CursorVisible <- false
            Console.ForegroundColor <- color;
            Console.Write string)
        value
        
let Draw color xYTuple (text : string) =
    Console.SetCursorPosition(xYTuple.x, xYTuple.y)
    cprintf color "%s" text