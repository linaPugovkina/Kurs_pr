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
    
    public partial class Service
    {
        public Service()
        {
            this.Visits = new HashSet<Visits>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int groupp { get; set; }
        public int costPrice { get; set; }
        public int price { get; set; }
        public string description { get; set; }
    
        public virtual GroupServices GroupServices { get; set; }
        public virtual ICollection<Visits> Visits { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
