<h1>What is GreenOneFoodTrucks?</h1>
GreenOneFoodTrucks is an REST API that consumes the City of San Francisco's open dataset API, which can be found <a href="https://data.sfgov.org/Economy-and-Community/Mobile-Food-Facility-Permit/rqzj-sfat/data" target="_blank">here</a>. GreenOneFoodTrucks REST API allows a consumer to enter in Latitude and Longitude values and the REST API will return all San Francisco Food Trucks within a radius of the coordinates provided.


<h1>How to Consume</h1>
Currently, the GreenOneFoodTrucks REST API exposes 1 End Point.  The End Point is located at: <b><i>http://mydomain.com/api/foodtrucks/latitude/{value}/longitude/{value}</i></b>.  <Br><Br>Example: <Br>
http://mydomain.com/api/foodtrucks/latitude/37.7678524427181/longitude/-122.416104892532



<h1>Technology Used</h1>
<ul>
	<li>ASP.Net Core 2.0</li>
	<li>FluentAssertions</li>
	<li>Lamar IoC Container</li>
	<li>NUnit</li>
	<li>SODA.Net</li>
</ul>


<h1>Patterns/Practices Used</h1>
<ul>
	<li>Dependency Injection</li>
	<li>Design By Contract</li>
	<li>Strategy Pattern</li>
	<li>TDD</li>
	<li>Unit Testing</li>
</ul>



<h1>AppSettings</h1>
GreenOneFoodTrucks has some preset application settings below is a list of the application settings and what they are used for:
<ul>
	<li>AppToken - The Application Token that was registered with <a href="https://data.sfgov.org" target="_blank">https://data.sfgov.org</a> so the application can consume the San Francisco open dataset API </li>
	<li>SoqlQueryLimit - Setting is used to limit the number of records that are returned from the San Francisco open dataset API</li>
	<li>RadiusOfCentralCoordinateInMeters - Setting is used to determine how wide the radius will be for a given Latitude and Longitude.  All Food Trucks will be returned that fall within this radius</li>
	<li>ResourceId - The ResourceId is the resource that is being queried by SODA.Net, in this case, it is the San Francisco Food Truck API</li>
	<li>SanFranciscoFoodTruckApiUrl - The web address of the San Francisco Food Truck API</li>
</ul>


<h1>Controllers</h1>
<ul>
	<li>FoodTruckController - Exposes one End Point to get all Food Trucks within a radius of a given Latitude and Longitude</li>
</ul>


<h1>GreenOneFoodTrucks.Common</h1>
This library is used to provide common objects that are used throughout the application. <br>
<ul>
	<li>AppSettings - Object is used to encapsulate all of the application settings in the app.{environment}.json file</li>
	<li>AppSettingsManager - Object is used to access the AppSettings object</li>
</ul>


<h1>GreenOneFoodTrucks.Domain</h1>
This library is used to provide domain objects that are used throughout the application. <br>
<ul>
	<li>Coordinates - Object is used to capture the Latitude and Longitude values the consumer has passed to the REST API</li>
	<li>FieldFilter - Object is used to hold the field name/field value that the consumer has passed to the REST API</li>
	<li>FoodTruck - Object is used to deserialize the object that is returned from the SODA.Net API when querying the San Francisco Food Truck API<li>
</ul>


<h1>GreenOneFoodTrucks.Services</h1>
This library is used to expose services that contain domain logic that is used by the REST API. <br>
<ul>
	<li>SodaService - Service is used as a wrapper around the SODA.Net web client</li>
	<li>WithinQueryBuilder - Service implements IQueryBuilder and is used to build the query that will be submitted to the SODA.Net web client</li>
	<li>FoodTruck - Object is used to deserialize the object that is returned from the SODA.Net API when querying the San Francisco Food Truck API</li>
</ul>