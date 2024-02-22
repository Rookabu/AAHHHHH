namespace Components

open Feliz
open Feliz.Router

//Hier ist die Todo definiert

type Todo =
    [<ReactComponent>]

    static member Main() = 
        Html.div [
            prop.text "Todo-Liste"
            
        ]


    