//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kurs_pr
{
    using System;
    using System.Collections.Generic;
    
    public partial class Positions
    {
        public Positions()
        {
            this.Worker = new HashSet<Worker>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int groupServices { get; set; }
        public string workSchedule { get; set; }
    
        public virtual GroupServices GroupServices1 { get; set; }
        public virtual ICollection<Worker> Worker { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
