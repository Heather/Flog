[<AutoOpen()>]
module Flog.Core

open System.IO

/// Flog Version
//
let Version = "0.0.1"

// Default logger ->
//
let mutable Logger = consoleLogger

// Log ->
//
let log (logger : IFlog) ll mm = 
    using logger <|
        fun flog -> flog.FLog ll mm

// Default procedures ->
//
let fM message = format LogLevel message
let fL message = log consoleLogger LogLevel message
let fF message = log fileLogger LogLevel message