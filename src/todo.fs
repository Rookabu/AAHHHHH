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
        let beispiel = [{Eintrag = "Beispiel: Einkaufen gehen"; Checkbox = false; Number = count}]
        let (table, settable) = React.useState(beispiel) //table ist ein state der geupdatet wird ruch settable

        let JSONString = Json.stringify table

        let setLocalStorage (key:string) (info: string) =
            Browser.WebStorage.localStorage.setItem (key, info)

        let getLocalStorage (key: string) =
            Browser.WebStorage.localStorage.getItem (key)

        let backfromstring input= Json.parseAs<TodoElement list> (getLocalStorage input)     

        let nextnumber = count + 1

        let removeElementFromTable (elementToRemove: int) =
            let mutable newTable = []
            for element in table do
                if element.Number <> elementToRemove then
                    newTable <- newTable @ [element] //wenn das jeweilige element nicht dem elementtoremove entspricht, 
            newTable                                //wird dieses zum table hinzugefügt. So entsteht eine neue liste ohne das jeweilige element

        Html.div[
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
                    prop.placeholder "Was möchtest du tun?" //Der string der hier eingegeben wird soll gespeichert werden und den button "Eintrag hinzufügen" geshickt werden welcher mit propon click den table neu settet
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
                        //setLocalStorage "Eintrag" JSONString
                        setcount nextnumber     
                        {Eintrag = input; Checkbox = false; Number = nextnumber} ::table |> settable //tabelle wird zu einem string convertiert
                        Browser.Dom.console.log (JSONString) //Jstring wird in web console geprinted
                          //tabelle soll als string local gespeichert (set) werden und bei wieder aufruf der seite geholt werden (get). Da die liste kein string ist muss es als json zu einem string umgewandelt werden                   
                        ))
                    prop.style[
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
                            for element in table do //für jedes Element in table wird folgendes gemacht:
                                //let element = List.item i table
                                Html.tr[
                                    Html.td element.Eintrag //fügt Eintrag hinzu
                                    Html.td[Bulma.control.div [Bulma.input.checkbox[]]]
                                    Html.td[
                                        Bulma.delete[
                                            delete.isMedium
                                            prop.onClick (fun _ ->                                            
                                            element.Number |> removeElementFromTable |> settable
                                            //setLocalStorage "Eintrag" JSONString
                                                )
                                        ]
                                    ]
                                ]
                        ]
                    ]
            ]
            Html.div[
             Bulma.button.button[
                    color.isLink;
                    prop.text "speichern"
                    prop.onClick (fun _ -> (
                        setLocalStorage "Eintrag" JSONString 
                        ))
                    prop.style[
                        style.fontSize 20
                        style.marginTop (length.rem 5)
                    ]
                ]
            ]
            Html.div[
                Bulma.button.button[
                    color.isLink;
                    prop.text "Speicher laden"
                    prop.onClick (fun _ -> (
                        backfromstring "Eintrag"|> settable // ruft über get den local storgae auf über den key, und konvertiert ihn zurück in den table und wird anschließend gesetttet
                                                            //tabelle soll als string local gespeichert (set) werden und bei wieder aufruf der seite geholt werden (get). Da die liste kein string ist muss es als json zu eunem string umgewandelt werden                   
                        ))
                    prop.style[
                        style.fontSize 20
                    ]
                ]               
            ]
            ]          
        ]
            
        
                
            
            
            
                
            
        
  

        
        


    