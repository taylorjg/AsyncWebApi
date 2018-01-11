# Description

This repo contains a little C# ASP.NET Core application with a single Web API endpoint:

* GET /api/async

When invoked, the action method performs a couple of async operations:

* GET http://httpbin.org/delay/1
* GET http://httpbin.org/bytes/10000

Finally, it returns the number of bytes in the response of the second async operation.

The idea is to observe web server threads handling multiple overlapped requests. To help see this, I have added some logging. I use a middleware class to increment a RequestId for each request received. This is made available to the Serilog LogContext (3rd column). The Serilog logging also includes the thread id (2nd column).

![Console](Screenshots/console.png)

In the above screenshot, about half way down, we can see that
during the interval 19:20:11.310 to 19:20:11.373, thread 18 contributes to the processing of three different requests (00000002, 00000003 and 00000004). Looking at it another way, we can see that request 00000002 starts off on thread 17 at 19:20:09.861, then hops to thread 18 at 19:20:11.310 and ends up on thread 19 at 19:20:11.504.

# Load Test

* Download [Gatling](https://gatling.io/) from the [zip bundle](https://repo1.maven.org/maven2/io/gatling/highcharts/gatling-charts-highcharts-bundle/2.3.0/gatling-charts-highcharts-bundle-2.3.0-bundle.zip)
* Extract the zip bundle
* Set `GATLING_HOME` to the directory where the zip bundle was extracted
* Run the load test:
    * `./gatling/run.sh`

# Links

* [httpbin(1): HTTP Request & Response Service](http://httpbin.org)
* [Enriching Serilog Output with HttpContext Information in ASP.NET Core v1.0](http://mylifeforthecode.com/enriching-serilog-output-with-httpcontext-information-in-asp-net-core/)
