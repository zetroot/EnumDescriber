using System.ComponentModel;

namespace Benchmark.EnumDescriber
{
    public enum StubEnum
    {
        Item0 = 0,
        Item1,
        Item2,
        Item3,
        Item4,
        Item5,
        Item6,
        [Description("desc 7")]Item7,
        [Description("desc 8")]Item8,
        [Description("desc 9")]Item9,
        [Description("desc 10")]Item10,
        [Description("desc 11")]Item11,
        [Description("desc 12")]Item12,
        [Description("desc 13")]Item13,
        [Description]Item14,
        [Description]Item15,
        [Description]Item16,
        [Description]Item17,
        [Description]Item18,
        [Description]Item19,
        [Description]Item20,
    }
}