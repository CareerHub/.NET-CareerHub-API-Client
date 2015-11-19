.NET-CareerHub-API-Client
=========================
[![Build status](https://ci.appveyor.com/api/projects/status/bjbrbqn32f42tn7p?svg=true)](https://ci.appveyor.com/project/visualeyes-builder/net-careerhub-api-client)
[![Halcyon Nuget Version](https://img.shields.io/nuget/v/CareerHub.Client.API.svg)](https://www.nuget.org/packages/CareerHub.Client.API/)
[![Halcyon Nuget Downloads](https://img.shields.io/nuget/dt/CareerHub.Client.API.svg)](https://www.nuget.org/packages/CareerHub.Client.API/)

# Getting Started with the CareerHub API Client

Install one of the API Client Libraries
``` nuget
Install-Package CareerHub.Client.API.JobSeekers.Public # or one of the other packages
```

Start using in your code

``` c#
string baseUrl = "http://dev.careerhub.com.au/version3";
string accessToken = "xxx"; // Get your access token an using OAuth 2.0 flow

IApiFactory apiFactory = new ApiFactory(baseUrl, accessToken);
var jobsApi = apiFactory.GetApi<IJobsApi>();

var jobs = await jobsApi.GetJobsAsync();

// Do your stuff with jobs
```

# Packages

TODO: Docs

### Integrations

### JobSeekers Authorised

### JobSeekers Public

### Meta
