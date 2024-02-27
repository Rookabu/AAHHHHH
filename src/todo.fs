namespace Components

open Feliz
open Feliz.Bulma

 
//Hier ist die Todo definiert

type Todo =
    [<ReactComponent>]
    static member Main() = 
        //let (table, addtableslot) = React.useState()
        Bulma.tag[
            prop.text "Erstelle dir eine Todo-Liste!"
            prop.style [
                style.margin (length.rem 1)
                style.fontSize 20
            ]
        ]



        
        
        


    