using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using TodoListGQL.Data;
using TodoListGQL.Models;

namespace TodoListGQL.GraphQL.DataItem
{
    public class ItemType : ObjectType<ItemList>
    {
        protected override void Configure(IObjectTypeDescriptor<ItemList> descriptor)
        {
            descriptor.Description("This model is used as an Item for the to list ");
            descriptor.Field(x => x.ItemDatas)
            .ResolveWith<Resolvers>(x => x.GetItems(default!, default!))
            .UseDbContext<ApiDbContext>()
            .Description("This is the list that the item belongs to");
        }
     private class Resolvers 
     {
        public IQueryable<ItemData> GetItems(ItemList list,  [Service(ServiceKind.Pooled)]  ApiDbContext context) 
        {
            return context.Items.Where(x => x.ListId == list.Id);
        }
     }
    }
}