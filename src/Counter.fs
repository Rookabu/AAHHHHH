namespace App

open Feliz
open Feliz.Router

type Components =
    /// <summary>
    /// The simplest possible React component.
    /// Shows a header with the text Hello World
    /// </summary>
    [<ReactComponent>]
    static member HelloWorld() = Html.h1 "Hello World"
    ///Warum wird dieser component nicht angezeigt?
    /// <summary>
    /// A stateful React component that maintains a counter
    /// </summary>
    [<ReactComponent>]
    static member Counter() =
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
                    style.padding (length.rem 7)
                    style.margin (length.rem 4)

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
                    style.padding (length.rem 7)
                    style.margin (length.rem 4)

                ]
            ]
            Html.div [
                prop.text "Ich erniedrige die Zahl!"
                prop.className "hiddenuntilhoverminus"
            ]  
            // Html.a [
            //     prop.text "Freshe To-Do-Liste"
            //     prop.className "todoliste"
            //     prop.href "https://www.youtube.com/"
            // ]         
         ]

    
    /// <summary>
    /// A React component that uses Feliz.Router
    /// to determine what to show based on the current URL
    /// </summary>
    [<ReactComponent>]
    static member Router() =
        let (currentUrl, updateUrl) = React.useState(Router.currentUrl())
        React.router [
            router.onUrlChanged updateUrl
            router.children [
                match currentUrl with
                | [ ] -> Html.h1 "Index"
                | [ "hello" ] -> Components.HelloWorld()
                | [ "counter" ] -> Components.Counter()
                | otherwise -> Html.h1 "Not found"
            ]
        ]