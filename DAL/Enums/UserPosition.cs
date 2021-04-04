using System.ComponentModel;

namespace DAL.Enums
{
    public enum UserPosition
    {
        [Description("Инженер")]
        Engineer,
        [Description("Техник")]
        Technician,
        [Description("Механик")]
        Mechanic,
        [Description("Оператор")]
        Operator,
        [Description("Начальник смены")]
        Supervisor
    }
}
