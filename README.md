# Token
Sends a Http POST request, receives the message body, and deserialzies into a token object.
Then, it uses a list of VINs and authentication info from the token to send another Http POST request, receives the message body, and deserializes it into an object that contains a list of data associated with each VIN.
