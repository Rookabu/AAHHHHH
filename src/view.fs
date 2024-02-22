namespace App

open Feliz
open Feliz.Router

//Ist beim aufrufen der Seite sichtbar und ruft den Counter auf mit der navbar.todo
type View =
    [<ReactComponent>]
    static member Main() =
        let page,setpage = React.useState(Types.Page.Counter) //Reagiert beim clicken. Start state ist der Counter
        printfn "%A" page //wird in console geprinted
        Html.div [
            
            prop.children [
                Html.nav [     
                    Components.NavBar.Überschrift()            
                    Components.NavBar.Todo(setpage)
                    Components.NavBar.Counter(setpage)
                
                ]
                match page with
                |Types.Page.Counter -> Components.Counter.Main()
                |Types.Page.Todo -> Components.Todo.Main() //Matched beim aufrufen es mit der jeweiligen definition
            ]
        ]



