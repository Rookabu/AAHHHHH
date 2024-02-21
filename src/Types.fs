module Types

[<RequireQualifiedAccess>]
type Page =
    |Counter
    |Todo
    member this.toStringReadable () =
        match this with
        |Counter -> "Counter" 
        |Todo -> "Todo-Liste"
