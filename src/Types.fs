module Types

[<RequireQualifiedAccess>]
type Page =
    |Counter
    |Todo
    member this.toStringReadable () =
        match this with
        |Counter -> "Counter" 
        |Todo -> "Todo-Liste" //zu einem lesbaren string umwandeln (wird angezeigt auf der website) 




