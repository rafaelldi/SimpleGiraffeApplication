namespace SimpleGiraffeApplication

open Giraffe
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting

module Program =
    let webApp =
        choose [
            route "/" >=> text "Hello World!"
            ]

    [<EntryPoint>]
    let main args =
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                fun webBuilder ->
                    webBuilder
                        .ConfigureServices(fun services -> services.AddGiraffe() |> ignore)
                        .Configure(fun builder -> builder.UseGiraffe webApp)
                        |> ignore)
            .Build()
            .Run()

        0