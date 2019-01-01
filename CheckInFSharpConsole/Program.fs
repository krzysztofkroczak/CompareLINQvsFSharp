// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System
open System.Diagnostics
open System.IO

let test () =
    [0..500_000] 
    |> List.filter (fun x -> x % 5  = 0)
    |> List.map (fun x -> x * 2)
    |> List.map (fun x -> x.ToString())
    |> String.concat "+"

let writeFile i (result: String) = 
    use stream = new StreamWriter(
    new FileStream(sprintf "C:\\Users\\Krzysztof.Kroczak\\source\\repos\\CheckTransformations\\CheckTransformations\\a%d.txt" i,FileMode.Append))
    stream.Write(result);

[<EntryPoint>]
let main argv = 
    let stopWatch = new Stopwatch();

    printfn "First execution"
    stopWatch.Start()
    let result1 = test()
    stopWatch.Stop()
    writeFile 1 result1
    printfn "result %A" stopWatch.Elapsed
    stopWatch.Reset()

    printfn "Second execution"
    stopWatch.Start()
    let result2 = test()
    stopWatch.Stop()
    writeFile 2 result2
    printfn "result %A" stopWatch.Elapsed

    0
