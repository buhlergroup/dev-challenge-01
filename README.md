# Developer Challenge

## Feature: Find Food Trucks Near a Location Based on Preferred Food

### Prerequisite

- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [VSCode](https://code.visualstudio.com/download)

### Description

Develop a solution to help the San Francisco team find food trucks near their location and based on their preferred food. The solution should return at least the closest food trucks options based on latitude, longitude, and preferred food.

### Acceptance Criteria

* The solution should accept input for latitude, longitude, amount of results, and preferred food.
* The solution should return a configurable amount of food truck options near the given location and based on the preferred food ordered by distance.
* The food truck data should be sourced from the San Francisco's open dataset.
* The solution should be implemented using ASP.NET Core. However an alternative can be used if required.
* Database technology is open to choose, but it is not required for this POC.

### Additional Information

* San Francisco's food truck open dataset: [dataset_link](https://data.sfgov.org/Economy-and-Community/Mobile-Food-Facility-Permit/rqzj-sfat/data)
* CSV dump of the latest data: [csv_dump_link](./Mobile_Food_Facility_Permit.csv)
* A copy of the CSV data is also included in this repository.
* The solution should be read-only and not require any updates.

### Setup

Follow instructions shown by VSCode to run the project in (dev) container.

![run](/images/run.png)

You start the project by clicking the play button (on the left) as shown in the image blow.

![start](/images/start.png)

If you recevie an error regarging not-trusted certificates, you can run commands below.

```console
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

### Usage

You will be able to access OpenAPI spec via following url https://localhost:7230/swagger/index.html.

Port number can be found in ```launchSettings.json``` in ```Properties``` folder in project root directory.

#### Example Request

```console
curl --location 'https://localhost:7230/api/facilities/search?latitude=37.76008693198698&longitude=-122.41880648110114&item=%20Noodle%20Soups'
```

```json
[
    {
        "Name": "Mini Mobile Food Catering",
        "Foods": "Cold Truck: Corn Dogs: Noodle Soups: Candy: Pre-packaged Snacks: Sandwiches: Chips: Coffee: Tea: Various Beverages",
        "Distance": 0.7,
        "Direction": "N"
    },
    {
        "Name": "Mini Mobile Food Catering",
        "Foods": "Cold Truck: Corn Dogs: Noodle Soups: Candy: Pre-packaged Snacks: Sandwiches: Chips: Coffee: Tea: Various Beverages",
        "Distance": 0.8,
        "Direction": "NE"
    },
    {
        "Name": "Mini Mobile Food Catering",
        "Foods": "Cold Truck: Corn Dogs: Noodle Soups: Candy: Pre-packaged Snacks: Sandwiches: Chips: Coffee: Tea: Various Beverages",
        "Distance": 0.9,
        "Direction": "N"
    }
]
```

#### TODOS

- Validate requests
- Create tests Unit tests

### Resources

- [Add a controller to an ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-controller?view=aspnetcore-8.0&tabs=visual-studio)
- [Create web APIs with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0#apicontroller-attribute)
- [Web API Development in .NET 8 in 2 Hours | ASP.NET CORE | RESTFUL API](https://www.youtube.com/watch?v=SsnpkRNhpmk)
- [IServiceCollection.AddRazorPages | Resolved](https://www.youtube.com/watch?v=uwW4uQXojVI)
- [Dependency injection into controllers](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection?view=aspnetcore-8.0)
- [InstallCsvHelper](https://www.nuget.org/packages/csvhelper/)
- [Install Geolocation](https://www.nuget.org/packages/Geolocation)
- [Handling CSV Files in ASP.NET Core Web APIs](https://www.syncfusion.com/blogs/post/handling-csv-files-in-asp-net-core-web-apis)
- [Read Data From a CSV File With Headers](https://code-maze.com/csharp-read-data-from-csv-file/)
- [Easiest way to handle csv files in c#](https://ravindradevrani.medium.com/easiest-way-to-handle-csv-files-in-c-6cad58d341fa)
- [Return JSON Result with Custom Status Code in ASP.NET Core](https://www.telerik.com/blogs/return-json-result-custom-status-code-aspnet-core)
- [Format response data in ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-8.0)
- [Geolocation](https://github.com/scottschluer/geolocation)
- [Unable to configure HTTPS endpoint](https://stackoverflow.com/questions/53300480/unable-to-configure-https-endpoint-no-server-certificate-was-specified-and-the)