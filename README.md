# Acora
Acora Employee Application

To install follow the steps below...
1. Open the Acora.sql file in (MS SQL Management Studio) and execute using 
2. Open the AcoraEmployeeManagement folder
3. Double click on the AcoraEmployeeManagement.sln to open with Microsoft Visual Studio IDE
4.  We need to change the connection string to point to your DB
5. Open Web.config file
    <connectionStrings>
        <add name="ACORAEntities" connectionString="metadata=res://*/Models.EmployeeModel.csdl|res://*/Models.EmployeeModel.ssdl|res://*/Models.EmployeeModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=SMARTAPT\SQLEXPRESS;initial catalog=ACORA;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    </connectionStrings>
6. Change this part 
    source=SMARTAPT\SQLEXPRESS;...................to your DB connection string e.g. (source=your_DB_connection;)
7. Save and run the application