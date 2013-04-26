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
let log (logger : IFlog) = logger.FLog

// Default procedures ->
//
let dLog  message = log consoleLogger LogLevel message
let dFlog message = log fileLogger LogLevel message