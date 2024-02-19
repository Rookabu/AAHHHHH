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

    /// <summary>
    /// A stateful React component that maintains a counter
    /// </summary>
    [<ReactComponent>]
    static member Counter() =
        let (count, setCount) = React.useState(0)
        Html.div [
            Html.h1 count
            Html.button [
                prop.onClick (fun _ -> setCount(count + 1))
                prop.text "Erhöhe mich!!!!!!"
                prop.style [
                    style.borderRadius 35
                    style.backgroundColor.hotPink
                    style.padding (length.rem 7)
                    style.margin (length.rem 8)
                ]
            ]
            Html.button [
                prop.onClick (fun _ -> setCount(count + 1))
                prop.text "Erhöhe mich!!!!!!"
                prop.style [
                    style.borderRadius 35
                    style.backgroundColor.hotPink
                    style.padding (length.rem 7)
                    style.margin (length.rem 8)
                ]
            ]
            Html.button [
                prop.onClick (fun _ -> setCount(count + 1))
                prop.text "Erhöhe mich!!!!!!"
                prop.style [
                    style.borderRadius 35
                    style.backgroundColor.hotPink
                    style.padding (length.rem 7)
                    style.margin (length.rem 8)
                ]
            ]
            
            Html.button [
                prop.onClick (fun _ -> setCount(count - 1))
                prop.text "Erniedrige mich!"
                prop.style [
                    style.borderRadius 35  
                    style.backgroundColor.aquaMarine
                    style.padding (length.rem 7)
                    style.margin (length.rem 8)
                ]
            ]
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