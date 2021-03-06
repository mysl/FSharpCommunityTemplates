﻿open ServiceStack
open ServiceStack.Common
open ServiceStack.Logging
open HelloService
open ServiceStack.Razor
open System

type AppHost() = 
    inherit AppHostHttpListenerBase("Hello F# Service", 
                                    typeof<HelloService>.Assembly)
    override this.Configure container = 
        this.Plugins.Add(new RazorFormat())
        ignore()

[<EntryPoint>]
let main argv = 
    LogManager.LogFactory <- new ConsoleLogFactory()
    printfn "%A" argv
    let host = "http://localhost:8080/"
    printfn "listening on %s ..." host
    let appHost = new AppHost()
    appHost.Init() |> ignore
    appHost.Start host |> ignore
    while true do
        Console.ReadLine() |> ignore
    0 // return an integer exit code
