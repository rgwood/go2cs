// package main -- go2cs converted at 2018 June 25 19:10:12 UTC
// Original source: D:\Projects\go2cs\src\Tests\Behavioral\StructWithPointer.go

using fmt = go.fmt_package;
using static go.BuiltInFunctions;

namespace go
{
    public static partial class main_package
    {

        private static void Main()
        {
            red:=ColorList{2,"red",nil,nil}blue:=ColorList{2,"blue",nil,nil}red.Next=&bluefmt.Printf("Value of red = %v\n",red)fmt.Printf("Value of blue = %v\n",blue)
        }
    }
}
