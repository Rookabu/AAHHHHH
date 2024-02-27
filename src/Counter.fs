namespace Components

open Feliz


//Hier ist der Counter definiert

type Counter =
    /// <summary>
    /// The simplest possible React component. (h1)
    /// </summary>
    /// A stateful React component that maintains a counter
    /// </summary>
    [<ReactComponent>]
    static member Main() =
        let (count, setCount) = React.useState(0)
        Html.div [
            
            Html.h1 [
                prop.text count
                prop.style [
                    style.textAlign.center
                    style.fontSize 60
                ]  
            ]            
            Html.button [            
                prop.onClick (fun _ -> setCount(count + 1))
                prop.text "Erhöhe mich!"
                prop.className "transition-all hovereffektplus"
                prop.style [
                    style.borderRadius 40
                    style.padding (length.rem 2)
                    style.marginLeft (length.rem 4)


                ]
            ]
            Html.div [
                prop.text "Ich erhöhe die Zahl!"
                prop.className "hiddenuntilhoverplus" //solange nicht drüber gehovert wird, hat hiddenuntilhover display:none. 
                                                      //Sobald gehovert wird überschreibt sich die + klasse da sie spezifischer ist und es wird sichtbar
            ]

            Html.button [
                prop.onClick (fun _ -> setCount(count - 1))
                prop.text "Erniedrige mich!"
                prop.className "transition-all hovereffektminus"
                prop.style [
                    style.borderRadius 40
                    style.backgroundColor.aqua
                    style.padding (length.rem 2)
                    style.marginLeft (length.rem 30)
                ]
            ]
            Html.div [
                prop.text "Ich erniedrige die Zahl!"
                prop.className "hiddenuntilhoverminus"
            ] 
        ]     
         
