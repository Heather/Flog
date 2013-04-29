[<AutoOpen()>]
module Flog.Model

open System
open System.IO

type Format =
    | Default
    | X

type L =
    | Error
    | Warning
    | Information
    | Debug
    override this.ToString() =
        match this with
        | Error         -> "Error"
        | Warning       -> "Warning"
        | Information   -> "Information"
        | Debug         -> "Debug"

/// The inteface
type IFlog = 
    inherit IDisposable
    abstract FLog : L -> Printf.StringFormat<'a,unit> -> 'a