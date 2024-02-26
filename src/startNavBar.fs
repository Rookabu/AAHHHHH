namespace Components

open Feliz
open Feliz.Router
//open Feliz.Delay

//Definition der NavBar und design (css datei)

type NavBar =
    let mutable ungeklickt = (prop.className "remainHighlight")  
    static member private Subpagelink(targetpage: Types.Page, setPage: Types.Page -> unit, statePage: Types.Page) = //öffnet etwas beim click und gibt den text an von toStingreadable
        

        Html.div [
            Html.a [
                prop.text (targetpage.toStringReadable())   
                prop.onClick (fun _ -> 
                        setPage(targetpage);
                        if targetpage <> statePage then //target page = gewollter state, statepage= aktueller state
                            ungeklickt <- prop.className "remainHighlight" 
                        else ungeklickt <- prop.className "ofa_button" 
                        )
                ungeklickt
                // if targetpage = statePage then                 
                //       prop.className "remainHighlight"   
                // else prop.className "ofa_button"                                
            ]
        ] //Definiert den subpage link und ihr aussehen (ofa button)

   
    
    static member Counter(setPage) = 
        NavBar.Subpagelink(Types.Page.Counter, setPage, Types.Page.Counter)   //verlinkt den richten suppage link mit dem typen
     

    static member Todo(setPage) =   
        NavBar.Subpagelink(Types.Page.Todo, setPage, Types.Page.Todo)  //verlinkt den richten suppage link mit dem typen
    static member Überschrift() =
        Html.div[
            prop.text "Navigier Bar"
            prop.className "ueberschrift"
        ]      





        
        

    