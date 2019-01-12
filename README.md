# AWS Cloud Map Register Me

## Allows ASP.Net Core-based microservices to register themselves with an already existing AWS Cloud Map Service.

In Startup.cs, in Configure method:

var client = new CloudMapClient();
var regTask = client.RegisterEc2Async(<your service Id>);
regTask.Wait();

Alternatively you can change the Configure method to be async.
