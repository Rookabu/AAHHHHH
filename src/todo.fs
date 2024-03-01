namespace Components

open Feliz
open Feliz.Bulma

 
//Hier ist die Todo definiert


type TodoElement = {
    Eintrag: string
    Checkbox: bool     
}

//state: liste aus record typen

type Todo =
    [<ReactComponent>]
    static member Main() = 
        let beispiel = [
            {Eintrag = "Beispiel: Einkaufen gehen"; Checkbox = false}
        ]
        let (table, settable) = React.useState(beispiel) //ANSATZ: neue funktion schreiben die wie settable etwas an den hinzufügen button schickt
        let (input, setinput) = React.useState("") //setinput soll den input(string) neu setzen. 
       
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
                    prop.placeholder "Eintrag" //Der string der hier eingegeben wird soll gespeichert werden und den button "Eintrag hinzufügen" geshickt werden welcher mit propon click den table neu settet
                    prop.onChange (fun (x:string) -> setinput x)
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
                         {Eintrag = input; Checkbox = false} ::table |> settable  //fügt einen neuen Eintrag zu liste hinzu und settet diesen neuen table. X soll den input von "Eintrag" erhalten                       
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
            
        
                
            
            
            
                
            
        
  

        
        


    