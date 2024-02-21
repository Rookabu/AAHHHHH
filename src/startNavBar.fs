namespace App

open Feliz
open Feliz.Router

type navComponents =
    [<ReactComponent>]

    static member Counter() = 
        
        Html.div [
            Html.a [
                prop.text "Cooler Counter"
                prop.className "todoliste"
                prop.href "https://www.youtube.com/"
            ]
        ]

    static member Todo() =     
        Html.div [
            Html.a [ 
                prop.text "Freshe To-Do-Liste"
                prop.className "todoliste"
                prop.href "https://www.youtube.com/"
            ]
        ]
    /// A React component that uses Feliz.Router
    /// to determine what to show based on the current URL
    /// </summary>


        
        

    