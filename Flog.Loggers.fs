[<AutoOpen()>]
module Flog.Loggers

open System
open System.IO

let mutable internal file = null

let consoleLogger = {
    new IFlog with
        member i.FLog level format =
            Printf.kprintf
                (printfn
                    "[%s][%A] %s"
                        <| level.ToString()
                        <| DateTime.Now)
                        format
        member i.Dispose() = ()
    }

let fileLogger = {
    new IFlog with
        member i.FLog level format = 
            file <-   match File.Exists(LogFileName) with
                        | false -> File.CreateText(LogFileName)
                        | true  -> File.AppendText(LogFileName)
            Printf.kprintf (fprintfn file "[%s][%A] %s" 
                            <| level.ToString() 
                            <| System.DateTime.Now) format
        member i.Dispose() = 
            file.Flush()
            file.Dispose()
    }