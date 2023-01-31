using System.ComponentModel;

namespace Movie43.Enums
{
    public enum Verdict : byte
    {
        [Description("Говняшка")]
        SHITHEAD = 0,
        [Description("Отстой")]
        SUCKS = 1,
        [Description("Чертовщина")]
        DEVILRY = 2,
        [Description("Треш")]
        TRASH = 3,

        //плохо
        //скука
        //проходняк
        //на один раз
        //не плохо
        //интересно
        //хорошо
        //отлично
        //супер
        //фантастика
        //превосходно
        //шедевр

    }
}
