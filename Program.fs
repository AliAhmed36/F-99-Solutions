// Learn more about F# at http://fsharp.org

open System

let rec func my_last l =
    match l with 
    | a :: [] -> a
    | _ :: b -> my_last b
    
let rec func my_butlast l =
    match l with
    | a :: _ :: [] -> a
    | _ :: _ :: k -> my_butlast k

let rec func elem_at l n =
    match l with
    | a :: b -> 
        if n = 1 then a else elem_at b (n-1)

let func num_elem l = 
    let rec elem_counter ls n =
        match ls with
            | _ :: [] -> (n+1)
            | _ :: m -> elem_counter m (n+1)
    elem_counter l 0

let rev_list l =
    let rec list_rev l1 l2 =
        match l1 with
            | a :: [] -> (a :: l2)
            | a :: b -> list_rev b (a :: l2)
    list_rev l []

let isp l =
    let rec ispcheck l1 l2 acc =
        match l1,l2 with
            | a :: b, c :: d -> if acc = false then false else
                                if a = c then ispcheck b d true else ispcheck b d false
    ispcheck l (rev_list l) true

let my_flatten l = 
    let rec sub_flatten l1 acc =
        match l1 with 
            | a :: [] -> (a :: acc)
            | a :: b -> sub_flatten b (a :: acc)
    rev_list (sub_flatten l [])

let compress ls =
    let rec uc l1 l2 =
        match l1 with
            | [] -> l2
            | a :: b -> if a = List.head(b) then uc b l2 else uc b (a :: l2)
    rev_list (uc ls (List.head(ls) :: []))

let pack ls =
    let rec subpack l1 acc l2 =
        match l1 with
            | [] -> l2
            | a :: b -> if a = List.head(acc) then subpack b (a :: acc) l2 else subpack b (a :: []) (acc :: l2)
    rev_list (subpack ls [] [])

let encode ls =
    let l = pack ls
    let rec subenc l1 l2 =
        match l1 with
            | [] -> l2
            | a :: b -> subenc b ([List.length(a) :: List.head(a):: []] :: l2)
    rev_list (subenc l [])

let rec list_print l =
    match l with
        | a :: [] -> printfn(a)
        | a :: b -> printfn(a)
                    list_print b


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    list_print [[1];[[2];[3;4];[5]]]
    0 // return an integer exit code
