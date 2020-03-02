# heroku_net_core_deploy
Example app deployable to heroku.

## Important setup
Heroku makes only certain port avalible to the app via environment `PORT` variable. When using docker containers only way of recieving port number is during runtime.
In .NET Core you can read environment variables by using `Environment.GetEnvironmentVariable` method. Then you can setup Kestrel to use specified port by using `webBuilder.UseUrls` method.

```c#
 public static IHostBuilder CreateHostBuilder(string[] args)
        {
            // Heroku allows app to use port specified by PORT environment variable
            var port = Environment.GetEnvironmentVariable("PORT");

            return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        
                        if(port != null)
                            webBuilder.UseUrls($"http://*:{port}");
                    });
        }  
```

## Heroku deploy

Login to heroku using:
`heroku container:login`

Push container to heroku using:

`heroku container:push web -a $APP_NAME` where $APP_NAME is name of app created in heroku.

Release container using

`heroku container:release web -a $APP_NAME` 

If you are inside git repository cloned from heroku you can omit -a parameter and its value.
