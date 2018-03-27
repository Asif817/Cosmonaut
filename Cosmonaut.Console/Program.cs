﻿using System;
using System.Threading.Tasks;
using Cosmonaut.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Cosmonaut.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var databaseName = "localtest";

            var newUser = new TestUser
            {
                Test = "Some nick",
                Id = Guid.NewGuid().ToString()
            };

            var book = new Book
            {
                Name = "book name",
                Author = newUser
            };

            var documentClient = new DocumentClient(new Uri("https://localhost:8081"), "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");

            var cosmoStore = new CosmoStore<Book>(documentClient, databaseName);

            var added = cosmoStore.AddAsync(book).GetAwaiter().GetResult();
            //var result = cosmoStore.FirstOrDefaultAsync(x => x.Name == "book name").Result;

            //var results = cosmoStore.ToListAsync().Result;

           // System.Console.ReadKey();
        }
    }
}