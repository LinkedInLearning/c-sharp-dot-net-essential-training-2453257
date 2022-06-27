// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

string td = "";
DateTime today = DateTime.Today;

do{
    Console.WriteLine("write date or exit");
    td = Console.ReadLine();

    if (td == "exit"){
        break;
    }

    DateTime pd;
    TimeSpan ts;
    if (DateTime.TryParse(td, out pd)){
        if (pd > today){
            ts = pd - today;
            Console.WriteLine($"{ts.Days} days to go!");
        }
        else if (pd == today){
            Console.WriteLine("It's today!");
        }
        else{
            ts = today - pd;
            Console.WriteLine($"It was {ts.Days} days ago!");
        }
    }
    else{
        Console.WriteLine("Invalid date!");
    }

}
while (td != "exit");


