namespace Components

open Feliz
open Feliz.Bulma

 
//Hier ist die Todo definiert


type Listenelement = {
    Eintrag: string
    Checkbox: bool     
}

type Todo =
    [<ReactComponent>]
    static member Main() = 
        let beispiel = [
            {Eintrag = "Beispiel: Einkaufen gehen"; Checkbox = false}
        ]

        let (table:Listenelement list), settable = React.useState(beispiel) //ANSATZ: neue funktion schreiben die wie settable etwas an den hinzufügen button schickt
        let userinput (x:string) = {Eintrag = x ; Checkbox = false} //state: liste aus record typen //todoliste: string + bool
        Html.div [
            Html.h1[                
                color.isWhite
                prop.text "Erstelle dir eine Todo-Liste! Du kannst die Einträge abhaken und wieder entfernen."
                prop.style [
                    style.margin (length.rem 1)
                    style.fontSize 20
                    style.width 1000
                ]
            ]              
            Bulma.control.div[
                Bulma.input.text [
                    prop.placeholder "Eintrag"
                    prop.onChange (fun (x:string) ->
                                    ({Eintrag = x ; Checkbox = false}::table |> *funktion die es an button weiterschickt*) 
                                    )
                    prop.style [
                        style.marginLeft (length.rem 37)
                        style.marginTop (length.rem 4)
                        style.fontSize 20
                        style.width 700
                    ]            
                ]
            ]
            Html.h1[
                Bulma.button.button [
                    color.isInfo;
                    prop.text "Eintrag hinzufügen"
                    prop.onClick (fun _ -> (
                        {Eintrag = "Staubsaugen"; Checkbox = false} ::table |> settable  //fügt einen neuen Eintrag zu liste hinzu und settet diesen neuen table                       
                    ))
                    prop.style [
                        style.marginLeft (length.rem 52)
                        style.marginTop (length.rem 2)
                        style.fontSize 20
                    ]
                ]               
            ]
            
            Html.h1[                     
                    Bulma.table [
                        Html.thead [
                            Html.tr [
                                Html.th "Eintrag"
                                Html.th "Erledigt"
                                Html.th "Löschen"
                            ]
                        ]
                        Html.tbody [ 
                            for element in table do 
                                Html.tr [
                                    Html.td element.Eintrag //fügt Eintrag hinzu
                                    Html.td [
                                        Bulma.control.div [Bulma.input.checkbox[]]
                                    ]
                                    Html.td [
                                        Bulma.delete [
                                            delete.isMedium
                                            prop.onClick (fun _ -> (
                                                {Eintrag = ""; Checkbox = false} ::table |> settable   //soll löschen                      
                                            ))
                                            ]
                                    ]
                                ]
                        ]
                    ]
                
            
             ]
        ]
            
        
                
            
            
            
                
            
        
  

        
        


    