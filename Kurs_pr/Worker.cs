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
    
    public partial class Worker
    {
        public Worker()
        {
            this.Visits = new HashSet<Visits>();
        }
    
        public int id { get; set; }
        public string FCs { get; set; }
        public int positions { get; set; }
        public string adress { get; set; }
        public string Telephone { get; set; }
        public string Photo { get; set; }
    
        public virtual Positions Positions1 { get; set; }
        public virtual ICollection<Visits> Visits { get; set; }

        public override string ToString()
        {
            return FCs;
        }
    }
}
