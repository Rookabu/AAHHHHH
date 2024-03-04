namespace Components

open Feliz
open Feliz.Bulma
open Fable.SimpleJson


 
//Hier ist die Todo definiert


type TodoElement = {
    Eintrag: string
    Checkbox: bool 
    Number: int
}

//state: liste aus record typen
//typen in json objekt umschreiben 

type Todo =
    [<ReactComponent>]
    static member Main() = 
    
         //ANSATZ: neue funktion schreiben die wie settable etwas an den hinzufügen button schickt
        let (input, setinput) = React.useState("") //setinput soll den input(string) neu setzen. 
        let (count, setcount) = React.useState(0)
        let beispiel = [
            {Eintrag = "Beispiel: Einkaufen gehen"; Checkbox = false; Number = count}
        ]
        let (table, settable) = React.useState(beispiel)

        let stringconverter (eingabe:string) =
            SimpleJson.parse eingabe

        let setLocalStorage (key:string) (info: string) =
            Browser.WebStorage.localStorage.setItem (key, info)

        let getLocalStorage (key: string) =
            Browser.WebStorage.localStorage.getItem (key)

        //let (storage, setstorage) = React.useState()
        let removeElementFromTable (elementToRemove: int) =
            let mutable newTable = []
            for element in table do
                if element.Number <> elementToRemove then
                    newTable <- newTable @ [element] //wenn das jeweilige element nicht dem elementtoremove entspricht, 
            newTable                                //wird dieses zum table hinzugefügt. So entsteht eine neue liste ohne das jeweilige element
        Html.div [
            prop.className "childstyle"
            prop.children[    
            Html.h1[                
                color.isWhite
                prop.text "Erstelle dir eine Todo-Liste! Du kannst die Einträge abhaken und wieder entfernen."
                prop.style[
                    style.marginLeft (length.rem 2)
                    style.marginBottom (length.rem 5)
                    style.fontSize 20
                ]
            ] 
                                 
            Bulma.control.div[
                Bulma.input.text[
                    prop.placeholder "Eintrag" //Der string der hier eingegeben wird soll gespeichert werden und den button "Eintrag hinzufügen" geshickt werden welcher mit propon click den table neu settet
                    prop.onChange (fun (x:string)->  setinput x)                            
                    prop.style[
                        style.fontSize 20
                        style.width 700
                    ]            
                ]
            ]
            Html.div[
                Bulma.button.button[
                    color.isInfo;
                    prop.text "Eintrag hinzufügen"
                    prop.onClick (fun _ -> (
                        let nextnumber = count + 1 
                        setcount nextnumber     
                        {Eintrag = input; Checkbox = false; Number = nextnumber} ::table |> settable  //fügt einen neuen Eintrag zu liste hinzu und settet diesen neuen table. X soll den input von "Eintrag" erhalten                       
                    ))
                    // prop.onKeyPress (fun _ -> (
                    //      {Eintrag = input; Checkbox = false} ::table |> settable  //fügt einen neuen Eintrag zu liste hinzu und settet diesen neuen table. X soll den input von "Eintrag" erhalten                       
                    // )) 
                    prop.style [
                        style.fontSize 20
                    ]
                ]               
            ]            
            Html.div[                     
                    Bulma.table[
                        Html.thead[
                            Html.tr[
                                Html.th "Eintrag"
                                Html.th "Erledigt"
                                Html.th "Löschen"
                            ]
                        ]
                        Html.tbody[ 
                            for element in table do 
                                //let element = List.item i table
                                Html.tr[
                                    Html.td element.Eintrag //fügt Eintrag hinzu
                                    Html.td [Bulma.control.div [Bulma.input.checkbox[]]]
                                    Html.td [
                                        Bulma.delete[
                                            delete.isMedium
                                            prop.onClick (fun _ -> 
                                            element.Number |> removeElementFromTable |> settable)
                                                // let newlist = List.take (element:int) table |> settable //noch umschreiben das nur der jeweilige eintrag gelöscht wird
                                                // newlist) 
                                                // auf uniquen parameter zugreifen --> Integer!! 
                                        ]
                                    ]
                                ]
                        ]
                    ]
            ]
            ]
             
        ]
            
        
                
            
            
            
                
            
        
  

        
        


    