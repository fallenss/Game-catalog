//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Курсилио
{
    using System;
    using System.Collections.Generic;
    
    public partial class Избранное
    {
        public int ID_избранного { get; set; }
        public int Номер_игры { get; set; }
        public int ID_пользователя { get; set; }
    
        public virtual Видеоигра Видеоигра { get; set; }
        public virtual Пользователи Пользователи { get; set; }
    }
}
