//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace QuestionsEntityClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Chapter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chapter()
        {
            this.Quests = new HashSet<Quest>();
            this.Variants = new HashSet<Variant>();
        }
    
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Modify { get; set; }
        public string Editor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quest> Quests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Variant> Variants { get; set; }
    }
}