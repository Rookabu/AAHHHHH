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
        let recordtypeliste = [
            {Eintrag = "Beispiel: Einkaufen gehen"; Checkbox = false}
        ]
        let (table:Listenelement list), addtable = React.useState(recordtypeliste) //state: liste aus record typen //todoliste: string + bool
        Html.div [
            Bulma.tag[
                color.isLink
                prop.text "Erstelle dir eine Todo-Liste! Du kannst diese abhaken und wieder entfernen."
                prop.style [
                    style.margin (length.rem 1)
                    style.fontSize 20
                ]
            ]
            Html.h1 [
                Bulma.button.button [
                    color.isInfo;
                    prop.text "Eintrag hinzufügen"
                    //prop.onClick (fun _ -> addtableslot(Listenelement))
                    prop.style [
                        style.margin (length.rem 1)
                        style.fontSize 20
                    ]
                ]
            ]
        //     Bulma.tag[
        //         prop.text table
        //         prop.style [
        //             style.margin (length.rem 1)
        //             style.fontSize 20
        //         ]
        //     ]
         ]




        
        
        


    