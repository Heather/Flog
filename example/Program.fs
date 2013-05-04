open Flog

[<EntryPoint>]
let main argv = 
    
    fL "test 1"
    fL "test %d" 2

    using consoleLogger <|
        fun flog -> flog.FLog Information "test 3"
                    flog.FLog Information "test %d" 4

    System.IO.File.Delete( LogFileName )

    fF "test 5" // Buggy with %d

    printf "%s" <| System.IO.File.ReadAllText ( LogFileName )

    System.IO.File.Delete( LogFileName )

    printfn "%s" <| fM "test %d" 6

    using fileLogger <|
        fun flog -> flog.FLog Information "test 7"
                    flog.FLog Information "test %d" 8

    printf "%s" <| System.IO.File.ReadAllText ( LogFileName )

    System.IO.File.Delete( LogFileName )

    System.Console.ReadKey() |> ignore

    0 // return an integer exit code
