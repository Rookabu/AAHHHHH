namespace App

open Feliz
open Feliz.Router

type Components =
    [<ReactComponent>]

    static member Todo () = 
        Html.div [
            prop.text "Todo-Lsite"

        ]
    [<ReactComponent>]
    static member RouterTodo() =
        let (currentUrl, updateUrl) = React.useState(Router.currentUrl())
        React.router [
            router.onUrlChanged updateUrl
            router.children [
                match currentUrl with
                | [ ] -> Html.h1 "Index"
                | [ "todo" ] -> Components.Todo()
                | otherwise -> Html.h1 "Not found"
            ]
        ]

    