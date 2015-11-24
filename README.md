.NET-CareerHub-API-Client
=========================
[![Build status](https://ci.appveyor.com/api/projects/status/bjbrbqn32f42tn7p?svg=true)](https://ci.appveyor.com/project/visualeyes-builder/net-careerhub-api-client)
[![Halcyon Nuget Version](https://img.shields.io/nuget/v/CareerHub.Client.API.svg)](https://www.nuget.org/packages/CareerHub.Client.API/)
[![Halcyon Nuget Downloads](https://img.shields.io/nuget/dt/CareerHub.Client.API.svg)](https://www.nuget.org/packages/CareerHub.Client.API/)

# Getting Started with the CareerHub API Client

Install one of the API Client Libraries
``` nuget
Install-Package CareerHub.Client.API.JobSeekers.Public -Pre # or one of the other packages
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

## Authorization
We have provided a OAuth Client that performs the Client Credentials Authorization flow.
For other authorization flows you will need to use a different [OAuth Client](http://oauth.net/2/). 
Our current recommendation is to use the [Microsoft Owin Security Auth Package](https://www.nuget.org/packages/Microsoft.Owin.Security.OAuth)

``` nuget
Install-Package CareerHub.Client.API.Authorization -Pre 
```

Request an access token using Client Credentials:

``` c#
IAuthorizationApi authApi = new AuthorizationApi(baseUrl, clientId, clientSecret);
var result = await authApi.SendClientCredentialsRequestAsync(new string[] { "SomeScope" }, CancellationToken.None);

//result.AccessToken
//result.ExpiresUtc
```

### Integrations
``` nuget
Install-Package CareerHub.Client.API.Integrations -Pre
```

[API Documentation](https://dev.careerhub.com.au/version3/help/api/area/integrations/v1)

Example (using Authorization package)
``` c#
string baseUrl = "http://dev.careerhub.com.au/version3";
string clientId = "xxx";
string clientSecret = "xxx";

IAuthorizationApi authApi = new AuthorizationApi(baseUrl, clientId, clientSecret);
var result = await authApi.SendClientCredentialsRequestAsync(new string[] { "Integrations.Forms" }, CancellationToken.None);

IApiFactory apiFactory = new ApiFactory(baseUrl, result.AccessToken);
var formReportsApi = apiFactory.GetApi<IFormReportsApi>();

int formId = 1;
int reportId = 2;

var report = await formReportsApi.GetJobsAsync(formId, reportId);

```

### JobSeekers Authorised
``` nuget
Install-Package CareerHub.Client.API.JobSeekers.Authorised -Pre 
```

[API Documentation](https://dev.careerhub.com.au/version3/help/api/area/jobseeker-authorised/v1)


### JobSeekers Public
``` nuget
Install-Package CareerHub.Client.API.JobSeekers.Public -Pre 
```

[API Documentation](https://dev.careerhub.com.au/version3/help/api/area/jobseeker-public/v1)

### Meta

``` nuget
Install-Package CareerHub.Client.API.Meta -Pre 
```

[API Documentation](https://dev.careerhub.com.au/version3/help/api/area/meta/v1)
