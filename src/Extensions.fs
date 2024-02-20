[<AutoOpen>]
module Extensions

open System
open Fable.Core
open Fable.Core.JsInterop

[<RequireQualifiedAccess>]
module StaticFile =

    /// Function that imports a static file by it's relative path.
    let inline import (path: string) : string = importDefault<string> path

/// Stylesheet API
/// let private stylesheet = Stylesheet.load "./fancy.module.css"
/// stylesheet.["fancy-class-name"] which returns a string


