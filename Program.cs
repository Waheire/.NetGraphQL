using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using TodoListGQL.Data;
using TodoListGQL.GraphQL;
using TodoListGQL.GraphQL.DataItem;
string pattern ="/graphql-ui";
var VOptions = new VoyagerOptions() {
    GraphQLEndPoint = "/graphql"
};
var builder = WebApplication.CreateBuilder(args);


//connect to the db
builder.Services.AddPooledDbContextFactory<ApiDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//add graphql
builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<ItemType>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
app.MapGraphQL();
app.MapGraphQLVoyager( pattern, VOptions);
app.Run();
