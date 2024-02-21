namespace App

open Feliz
open Feliz.Router


type View =
    [<ReactComponent>]
    static member Main() =
        let page,setpage = React.useState(Types.Page.Counter)
        printfn "%A" page
        Html.div [
            prop.children [
                Html.nav [
                   // Components.NavBar.Counter(setpage)
                    Components.NavBar.Todo(setpage)//fixxen
                ]
                match page with
                |Types.Page.Counter -> Components.Counter.Main()
                |Types.Page.Todo -> Components.Todo.Main()
            ]
        ]



