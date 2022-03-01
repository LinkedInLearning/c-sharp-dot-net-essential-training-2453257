// Exercise file for LinkedIn Learning Course .NET Programming with C# by Joe Marini
// Example file for .NET Data Types

// Declare some types with values
int a = 1;
char c = 'A';
float f = 123.45f;
decimal d = 400.85m;
int b = default;
bool tf = default;

Console.WriteLine($"{a}, {b}, {tf}, {c}, {f}, {d}");

// TODO: implicit type conversion


// TODO: Create an instance of a struct (which is a value type)


// Perform an operation on a struct
void StructOp(s theStruct) {
    // Modify the struct properties inside the function
    theStruct.a = 10;
    theStruct.b = true;
    Console.WriteLine($"{theStruct.a}, {theStruct.b}");
}

// Console.WriteLine("Structs are passed by copy, since they are value types:");
// Console.WriteLine($"{s1.a}, {s1.b}");
// StructOp(s1);
// Console.WriteLine($"{s1.a}, {s1.b}");

// TODO: Create an object instance of a class (which is a reference type)


// Perform an operation on the class
void ClassOp(MyClass theClass) {
    // Modify some of the properties of the class inside the function
    theClass.a = 10;
    theClass.b = true;
    Console.WriteLine($"{theClass.a}, {theClass.b}");
}

// Console.WriteLine("Objects are passed by reference, since they are reference types:");
// Console.WriteLine($"{cl.a}, {cl.b}");
// ClassOp(cl);
// Console.WriteLine($"{cl.a}, {cl.b}");

// These are declared at the bottom of the file because C# requires
// top-level statements to come before type declarations
class MyClass {
    public int a;
    public bool b;
}

struct s {
    public int a;
    public bool b;
}
