using System.ServiceModel.Syndication;
using System.Xml;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => {

    const string url = "https://blog.cashwu.com/feed/rss";
    using var reader = XmlReader.Create(url, new XmlReaderSettings
    {
        DtdProcessing = DtdProcessing.Ignore
    });
    var feed = SyndicationFeed.Load(reader);

    return feed.Items;
});

app.Run();