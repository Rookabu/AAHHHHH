namespace Components

open Feliz
open Feliz.Router

type NavBar =
    static member private Subpagelink(page: Types.Page,setPage: Types.Page -> unit) = 
        Html.div [
            Html.a [
                prop.text (page.toStringReadable())
                prop.className "todoliste"
                prop.onClick (fun _ -> setPage(page))
            ]
        ]
    
    static member Counter(setPage) = 
        NavBar.Subpagelink(Types.Page.Counter, setPage)   


    static member Todo(setPage) =     
        NavBar.Subpagelink(Types.Page.Todo, setPage)

//Matchcase hier hin

        
        

    