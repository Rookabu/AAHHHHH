namespace Components

open Feliz
open Feliz.Router

//Definition der NavBar und design (css datei)

type NavBar =
    static member private Subpagelink(page: Types.Page,setPage: Types.Page -> unit) = 
        Html.div [
            Html.a [
                prop.text (page.toStringReadable())
                prop.className "ofa_button"
                prop.onClick (fun _ -> setPage(page))
            ]
        ] //Definiert subpage link und ihr aussehen
    
    static member Counter(setPage) = 
        NavBar.Subpagelink(Types.Page.Counter, setPage)   //verlinken

    static member Todo(setPage) =   
        NavBar.Subpagelink(Types.Page.Todo, setPage)  //verlinken
    static member Überschrift() =
        Html.div[
            prop.text "Navigier Bar"
            prop.className "ueberschrift"
            prop.style[
                style.fontWeight.bold
                //style.textAlign.center  
            ]
        ]      




        
        

    