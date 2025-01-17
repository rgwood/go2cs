namespace go {

//import (
    using fmt = fmt_package;
//)
using static builtin;

[package] partial class main_package1 {
    
[func] private static
void main() {

    nint i = 0;

    while (i < 10) {
        // Inner comment
        f(i); // Call function
        // Increment i
        i++; // Post i comment
    } // Post for comment

    fmt.Println();
    fmt.Println("i =", i);
    fmt.Println();

    for (i = 0; i < 10; i++) {
        f(i);

        for (nint j = 0; j < 3; j++) {
            f(i + j);
        }
        fmt.Println();
    }

    fmt.Println("i =", i);
    fmt.Println();

    { nint i__prev1 = i;
    for (i = 0; i < 5; i++) {
        // a
        f(i); // b

        { nint i__prev2 = i;
        for (i = 12; i < 15; i++) {
            f(i);
        } i = i__prev2; } //c
        fmt.Println();
    } i = i__prev1; } //d

    fmt.Println();
    fmt.Println("i =", i);
    fmt.Println();

    while (true) {
        i++;
        f(i);

        if (i > 12) {
            break;
        }
    }

    fmt.Println();
    fmt.Println("i =", i);
}

[func] private static 
void f(nint y) {
    fmt.Print(y);
}

} // end package class
} // end namespace
