
# Native Stats

A web page that displays recent and upcoming football matches for the
following leagues:

* Primeira Liga (Portugal)
* Premier League (England)
* Eredivisie (Netherlands)
* Bundesliga (Germany)
* Serie A (Italy)
* La Liga (Spain)
* Serie A (Brazil)






## Installation

This project does not need download or installation of dependecies. Just clone this repo and open it on Visual Studio.


* After launching the application in Visual Studio, navigate to the URL localhost.
* If accessed from a non-mobile device, you will be redirected to localhost/Home/NotMobile.
## Considerations

The external API used in this project supports data retrieval within a 7-day range. Since the desired approach or specific number of days per request was not defined, the following logic was implemented:

* Recent Matches: By default, or when the "Recent Matches" button is clicked, the application retrieves data from the previous six days up to the current day.
* Upcoming Matches: Clicking the "Upcoming Matches" button retrieves data for the current day and the following six days.

It’s worth noting that the API does not always provide data for all championships. To maintain simplicity, the application displays only the data returned by the API.

Additionally, the order of the displayed data was not specified. As a result, the data is sorted by the championship ID.

Lastly, the carousel feature was implemented using the Swiper library, which facilitated a simplified and efficient way to build this component.



## Authors

- [@andradediego](https://www.github.com/andradediego)

