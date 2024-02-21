namespace Components

open Feliz
open Feliz.Router

type Todo =
    [<ReactComponent>]

    static member Main() = 
        Html.div [
            prop.text "Todo-Liste"
        ]



    