using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListGQL.Models
{
    public class ItemList
    {
        public ItemList()
        {
            ItemDatas = new HashSet<ItemData>();
        }
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public virtual ICollection<ItemData> ItemDatas {get; set;}
    }
}