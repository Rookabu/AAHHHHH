namespace Components

open Feliz
open Feliz.Router
//open Feliz.Delay

//Definition der NavBar und design (css datei)

type NavBar =
    static member private Subpagelink(page: Types.Page,setPage: Types.Page -> unit) = //öffnet etwas beim click und gibt den text an von toStingreadable
        
        Html.div [
            Html.a [
                prop.text (page.toStringReadable())   
                prop.onClick (fun _ -> setPage(page)) // reagiert auf click
                prop.className "ofa_button"

                // let mutable geklickt= 
                //     React.useState(Types.Page.Counter, Types.Page.Todo) = true // reagiert auf den state

                // let mutable klickfunktion=
                //     prop.onClick (fun _ -> setPage(page)) = true    
                
                // let klickstatus =
                //     match klickfunktion with
                //     |geklickt
                
                    
                // if React.useState(Types.Page.Counter) =   then prop.className "remainHighlight" 
                // elif React.useState(Types.Page.Todo) =  then prop.className "remainHighlight"
                // else prop.className "ofa_button"   
                

                // if prop.onClick (fun _ -> setPage(page)) = true then prop.className "remainHighlight" 
                // else prop.className "ofa_button" 
            ]
        ] //Definiert den subpage link und ihr aussehen (ofa button)
    
    static member Counter(setPage) = 
        NavBar.Subpagelink(Types.Page.Counter, setPage)   //verlinken

    static member Todo(setPage) =   
        NavBar.Subpagelink(Types.Page.Todo, setPage)  //verlinken
    static member Überschrift() =
        Html.div[
            prop.text "Navigier Bar"
            prop.className "ueberschrift"
        ]      




        
        

    