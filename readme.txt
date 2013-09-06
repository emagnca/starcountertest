Starcounter DB tests.

Starmap is a load test. It simulates a geolocation application with Position, TrackingObjects and TrackingGroups, where the positions of groups of objects are stored in a database.

The serverside project is located in starcountertest/starmap/servers/starcounter/starmap.sln
A JMeter client is found in starcountertest/starmap/clients/jmeter/tests/starcounter_load.jmx. The IP number of the host is stored as a variable in the TestPlan.
