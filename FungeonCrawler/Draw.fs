module Draw
open System

let cprintf color value = 
    Printf.kprintf 
        (fun string -> 
            Console.CursorVisible <- false
            Console.ForegroundColor <- color;
            Console.Write string)
        value
        
let Draw color x y (text : string) =
    Console.SetCursorPosition(x, y)
    cprintf color "%s" text