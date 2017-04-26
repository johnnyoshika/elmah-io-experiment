# Setup
* Clone this repo
* Open `Startup.cs` and update this line with proper API_KEY and LOG_ID:
```
app.UseElmahIo("API_KEY", new Guid("LOG_ID"));
```
* Run the project

# Testing elmah.io behavior 1

* Test 400 error: [http://localhost:53276/?throw400=true](http://localhost:53276/?throw400=true)
* Test 500 error: [http://localhost:53276/?throw500=true](http://localhost:53276/?throw500=true)

Notice that neither error is logged in elmah.io. This is strange as elmah.io should be able to inspect the response and notice that a 500 response is returned to the client in the second test.

# Testing elmah.io behavior 2

Move registration of `HandleExceptionMiddleware` to before elmah.io in `Startup`:
```
app.UseMiddleware<HandleExceptionMiddleware>();
app.UseElmahIo("API_KEY", new Guid("LOG_ID"));
```

* Test 400 error: [http://localhost:53276/?throw400=true](http://localhost:53276/?throw400=true)
* Test 500 error: [http://localhost:53276/?throw500=true](http://localhost:53276/?throw500=true)

Notice that both errors are logged in elmah.io and both are reported as 500 errors. This makes sense as elmah.io handles the exceptions before `HandleExceptionMiddleware` gets a chance to change the response code.
