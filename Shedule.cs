//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shedule_diplom
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shedule
    {
        public int ID_record { get; set; }
        public Nullable<int> ID_employee { get; set; }
        public Nullable<int> ID_chart { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> ID_statusDay { get; set; }
        public Nullable<int> ID_dayOfWeek { get; set; }
    
        public virtual Charts Charts { get; set; }
        public virtual DaysOfWeek DaysOfWeek { get; set; }
        public virtual DaysStatuses DaysStatuses { get; set; }
        public virtual Employees Employees { get; set; }
    }
}