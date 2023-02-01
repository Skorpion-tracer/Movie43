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
        [Description("Плохо")]
        BAD = 4,
        [Description("Скука")]
        BOREDOM = 5,
        [Description("Проходняк")]
        PROKHODNYAK = 6,
        [Description("На один раз")]
        FORONETIME = 7,
        [Description("Не плохо")]
        NOTBAD = 8,
        [Description("Интересно")]
        INTERESTING = 9,
        [Description("Хорошо")]
        GOOD = 10,
        [Description("Отлично")]
        EXCELLENT = 11,
        [Description("Супер")]
        SUPER = 12,
        [Description("Фантастика")]
        FICTION = 13,
        [Description("Превосходно")]
        BRILLIANTLY = 14,
        [Description("Шедевр")]
        MASTERPIECE = 15
    }
}
