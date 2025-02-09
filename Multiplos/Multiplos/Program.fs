open System

[<EntryPoint>]
let main argv =
    // Lê a entrada do usuário e converte para uma lista de inteiros
    let numeros = Console.ReadLine().Split() |> Array.map int
    
    // Extrai os dois números da entrada
    let primeiro = numeros.[0]
    let segundo = numeros.[1]

    // Função auxiliar para verificar se são múltiplos
    let saoMultiplos a b =
        a % b = 0

    // Verifica se os números são múltiplos
    if saoMultiplos primeiro segundo || saoMultiplos segundo primeiro then
        printfn "Sao Multiplos"
    else
        printfn "Nao sao Multiplos"

    0 // Retorno da função principal
