UnitConversion API is built using  below configurations:
Framework: .net core 6.0
Database : MS sql server 16.0
API Testing tool : Swagger

API functionality:

This API is designed to convert three types of Metric units to Imperial units and vice versa.
Below are the Metric units that can be converted using this API:

1. Celcius
2. Kilometre
3. Kilogram

Below are the Imperial units that can be converted using this API:

1. Fahrenheit
2. Mile
3. Pound

API URL:
https://localhost:7062/swagger/index.html ( Please use your local port number )

API Request Parameters Example for Metric to Imperial Conversion:
 UnitValue (float): 20

{

  "metricName": "Kilometre"
  
}

Response:

12.40 Mile


API Request Parameters Example for Imperial to Metric Conversion:

 UnitValue (float): 77

{
  
  "Imperialname": "Fahrenheit"

}

Response:

25 Celcius


Database Connection string:

"dbconn": "Server=XXXX;Database=Unit_Conversion;Trusted_Connection=True;TrustServerCertificate=True;"

database_scripts file is placed in project folder.







