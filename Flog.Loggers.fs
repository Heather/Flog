[<AutoOpen()>]
module Flog.Loggers

open System
open System.IO

let mutable internal file = null

let format level msg = 
    Printf.kprintf (
        match LogFormat with
        | X -> sprintf "%s | %s" 
                    <| DateTime.Now.ToString("hh:mm:ss fff")
        | _ -> sprintf "[%s][%A] %s" 
                    <| level.ToString() 
                    <| System.DateTime.Now) msg

let consoleLogger = {
    new IFlog with
        member i.FLog level format =
            Printf.kprintf
               (match LogFormat with
                | X -> printfn "%s | %s" 
                    <| DateTime.Now.ToString("hh:mm:ss fff")
                | _ -> printfn "[%s][%A] %s"
                        <| level.ToString()
                        <| DateTime.Now)
                        format
        member i.Dispose() = ()
    }

let fileLogger = {
    new IFlog with
        member i.FLog level format = 
            if file = null then
                file <-   match File.Exists(LogFileName) with
                            | false -> File.CreateText(LogFileName)
                            | true  -> File.AppendText(LogFileName)
            Printf.kprintf (
                match LogFormat with
                | X -> fprintfn file "%s | %s" 
                            <| DateTime.Now.ToString("hh:mm:ss fff")
                | _ -> fprintfn file "[%s][%A] %s" 
                            <| level.ToString() 
                            <| System.DateTime.Now) format
        member i.Dispose() = 
            file.Flush()
            file.Dispose()
            file <- null
    }