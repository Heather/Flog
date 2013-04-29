[<AutoOpen()>]
module Flog.Settings

open System.IO

// Default log level ->
//
let mutable LogLevel = Debug

// Default log level ->
//
let mutable UseLogLevel = true

// Default log file ->
//
let mutable LogFileName = "F.log"