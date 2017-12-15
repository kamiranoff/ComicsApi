using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MarvelEncyclopedia
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var database = CreateDatabase("marvelapi");
            
            
            var collection = database.GetCollection<BsonDocument>("characters");
            var characterFirst = collection.Find(new BsonDocument()).First();
            Console.WriteLine(characterFirst);
            var count = collection.Count(new BsonDocument());
            Console.WriteLine(count);
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler();
            }


            app.UseStatusCodePages();
            app.UseMvc();

        }

        public static IMongoDatabase CreateDatabase(string _dbName)
        {
            MongoClient mongoClient = new MongoClient();
        
            Console.WriteLine("Successfully connected to MongoDB: " + _dbName);
            Console.WriteLine("-----------------------------");   
            
            return mongoClient.GetDatabase(_dbName);


            
        }
    }
}
