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
    
    public partial class Visits
    {
        public int id { get; set; }
        public int client { get; set; }
        public int service { get; set; }
        public int worker { get; set; }
        public System.DateTime data { get; set; }
        public byte RenderingServices { get; set; }
    
        public virtual Client Client1 { get; set; }
        public virtual Service Service1 { get; set; }
        public virtual Worker Worker1 { get; set; }
    }
}
