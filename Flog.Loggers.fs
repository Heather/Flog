[<AutoOpen()>]
module Flog.Loggers

open System
open System.IO

let consoleLogger = {
    new IFlog with
        member i.FLog level format =
            Printf.kprintf
                (printfn
                    "[%s][%A] %s"
                        <| level.ToString()
                        <| DateTime.Now)
                        format
    }

let fileLogger = {
    new IFlog with
        member i.FLog level format =

            // TODO: RECODE THIS STUFF 
            use file = LogFile()

            Printf.kprintf (fprintfn file "[%s][%A] %s" 
                            <| level.ToString() 
                            <| System.DateTime.Now) format
    }