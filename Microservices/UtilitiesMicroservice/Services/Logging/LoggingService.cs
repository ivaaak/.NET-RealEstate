using Nest;
using System.Reflection.Metadata;

namespace UtilitiesMicroservice.Services.Logging
{
    public class LoggingService
    {
        private ElasticClient client = new ElasticClient(new Uri("http://localhost:9200"));

        /*
        public void CreateIndexAttempt()
        {
            // Create an index
            client.CreateIndex("myindex", c => c
                .Mappings(m => m
                    .Map<Document>(mm => mm
                        .AutoMap()
                    )
                )
            );

            // Add a document to the index
            client.Index(new Document { Id = 1, Name = "John Smith" }, i => i.Index("myindex"));

            // Search the index
            var result = client.Search<Document>(s => s
                .Index("myindex")
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Name)
                        .Query("John")
                    )
                )
            );

        }*/
    }
}
