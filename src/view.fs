namespace App

open Feliz

//Ist beim aufrufen der Seite sichtbar und ruft den Counter auf mit der navbar.todo
type View =
    [<ReactComponent>]
    static member Main() =
        let currentpage,setpage = React.useState(Types.Page.Counter) //Reagiert beim clicken. Start state ist der Counter ->noch in Srat menü umändern
        printfn "%A" currentpage //wird in console geprinted
        Html.div [
            prop.children [ 
                Html.a [ 
                    //Components.NavBar.Überschrift()          
                    Components.NavBar.Subpagelink(setpage,currentpage)
                    //Components.NavBar.Counter(setpage, currentpage)
                ]
                match currentpage with
                |Types.Page.Counter -> Components.Counter.Main()
                |Types.Page.Todo -> Components.Todo.Main() //wird gemachted da die jeweilige component aufgerufen werden soll je nach page (application state)
            ]
        ]




