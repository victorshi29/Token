# Token

This is just some personal practice with HTTP requests, JSONs, serialization, and SQL Server. Clarification: Token and Token2 aren't related

## Token
The program sends a HTTP POST request, receives the message body, and deserializes into a token object.
Then, the program uses a provided list of VINs and authentication info from the token to send another HTTP POST request. 
The program receives the message body, and deserializes it into an object that contains a list of data associated with each VIN.

## Token2
Similar to above, the program uses a HTTP POST request and deserialization to obtain a token object. 
The token is used to send another HTTP POST to receive a large message body that contains a list of VINs and other related data in XML form.
This data is then deserialized. Afterwards, some of the data is extracted from the object and inserted into a local SQL Server database.


