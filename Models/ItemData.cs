using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListGQL.Models
{
    public class ItemData
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public bool IsDone {get; set;}
        public int ListId {get; set;}
        public virtual ItemList ItemList {get; set;}
    }
}