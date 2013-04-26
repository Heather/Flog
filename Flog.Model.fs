[<AutoOpen()>]
module Flog.Model

open System.IO

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
    abstract FLog : L -> Printf.StringFormat<'a,unit> -> 'a