module ShapeRenderer
open Render

let DrawRect color x1 y1 x2 y2 =
    // horizontal lines
    for x = x1 to x2 do
        Draw color x y1 "═"
    for x = x1 to x2 do
        Draw color x y2 "═"
    
    // vertical lines
    for y = y1 to y2 do
        Draw color x1 y "║"
    for y = y1 to y2 do
        Draw color x2 y "║"
    
    // edges
    Draw color x1 y1 "╔"
    Draw color x2 y1 "╗"
    Draw color x2 y2 "╝"
    Draw color x1 y2 "╚"