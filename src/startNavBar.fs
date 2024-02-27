
namespace Components

open Feliz
open Feliz.Bulma

//Definition der NavBar und design (css datei)



type NavBar =
    //let mutable ungeklickt = (prop.className "remainHighlight")  
    static member private Subpagelink(setPage: Types.Page -> unit, statePage: Types.Page) = //öffnet etwas beim click und gibt den text an von toStingreadable
        Bulma.navbarMenu [                        
            Bulma.navbarStart.div [  
                Bulma.navbarItem.a [ Html.img [ prop.src "https://bulma.io/images/bulma-logo-white.png"; prop.height 28; prop.width 112; ]]
     
                Bulma.navbarItem.a [                
                    prop.text "Nav Bar";   
                    prop.className "ofa_buttonmenü"                                
                ]             
                Bulma.navbarItem.a [                
                    prop.text "Todo-Liste";   
                    prop.onClick (fun _ -> setPage(Types.Page.Todo))
                    if Types.Page.Todo = statePage then  //target page = gewollter state, statepage= aktueller state                
                        prop.className "remainHighlight"   
                    else prop.className "ofa_button"                                
                ]
                Bulma.navbarItem.a [                
                    prop.text "Counter";   
                    prop.onClick (fun _ -> setPage(Types.Page.Counter))
                    if Types.Page.Counter = statePage then  //target page = gewollter state, statepage= aktueller state                
                        prop.className "remainHighlight"   
                    else prop.className "ofa_button"                                
                ]
            ]  
        ]  
         
        
        //Definiert den subpage link und ihr aussehen (ofa button)

        // Bulma.navbarMenu [
        //     Bulma.navbarStart.div [
        //         Bulma.navbarItem.a [prop.text (targetpage.toStringReadable()); 
        //                             prop.onClick (fun _ -> setPage(targetpage));
        //                             if targetpage = statePage then  //target page = gewollter state, statepage= aktueller state                
        //                                 prop.className "remainHighlight"   
        //                             else prop.className "ofa_button"]                
        //                 ]
        //             ]
        


    
    // static member Counter(setPage, currentpage) = 
    //     NavBar.Subpagelink( setPage, currentpage)   //verlinkt den richten suppage link mit dem typen
     
    static member Allgemein(setPage, currentpage) =   
        NavBar.Subpagelink(setPage, currentpage)  //verlinkt den richten suppage link mit dem typen

    // static member Überschrift() =
    //      Bulma.navbarMenu [
    //         Bulma.navbarStart.div [
    //             Bulma.navbarItem.a [prop.text "NavBar"; prop.className "ofa_buttonmenü"]
    //         ]
    //     ]








        
        

    