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
        public int ID_employee { get; set; }
        public Nullable<int> ID_chart { get; set; }
        public Nullable<int> ID_status_Saturday { get; set; }
        public Nullable<int> ID_status_Sunday { get; set; }
        public Nullable<int> NumberOfWeek { get; set; }
        public int ID_record { get; set; }
    
        public virtual DaysStatuses DaysStatuses { get; set; }
        public virtual DaysStatuses DaysStatuses1 { get; set; }
        public virtual Employees Employees { get; set; }
    }
}
