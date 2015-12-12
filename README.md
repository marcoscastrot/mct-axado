# mct-axado
This is a project that allow the user consult, create, update, delete and rate carriers.

## Configuration

In the web.config file, configure the server and change the connection string name to TesteAxadoContext and Initial Catalog to TesteAxado
The code below use a local instance of SqlServer express.

```xml
<configuration>
	<connectionStrings>
		<add name="TesteAxadoContext" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=TesteAxado;Integrated Security=SSPI;" providerName="System.Data.SqlClient" />
	</connectionStrings>
</configuration>
```

## DataBase

I used the entity framework 6 with code first migrations.
To create the database, just follow the steps below:

```
Open the "Package Manager Console" (TOOLS > Library Package Manager > Package Manager Console)
Select the project (TesteAxado) in "Default project"
Run the following commands: 
Install-Package EntityFramework
enable-migrations
update-database
```

This is it! The project is ready to run.

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/marcoscastrot/mct-axado. This project is intended to be a safe, welcoming space for collaboration, and contributors are expected to adhere to the [Contributor Covenant](contributor-covenant.org) code of conduct.


## License

The gem is available as open source under the terms of the [MIT License](http://opensource.org/licenses/MIT).

