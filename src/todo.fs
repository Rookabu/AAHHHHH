namespace Components

open Feliz
open Feliz.Router

// open Feliz.Bulma

//Hier ist die Todo definiert

type Todo =
    [<ReactComponent>]

    static member Main() = 
        Html.div [
            prop.text "Todo-Liste"
            
        ]


    