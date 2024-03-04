using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListGQL.Data;
using TodoListGQL.Models;

namespace TodoListGQL.GraphQL
{
    
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetList( [Service(ServiceKind.Pooled)]  ApiDbContext context)
        {
            return context.Lists;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemData> GetDatas( [Service(ServiceKind.Pooled)]  ApiDbContext context)
        {
            return context.Items;
        }
    }
}