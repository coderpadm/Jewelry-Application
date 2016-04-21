namespace Jewelry_Application
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class JewelerModel : DbContext
    {
        // Your context has been configured to use a 'JewelerModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Jewelry_Application.JewelerModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'JewelerModel' 
        // connection string in the application configuration file.
        public JewelerModel()
            : base("name=JewelerModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Jewelry> Jewels { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}