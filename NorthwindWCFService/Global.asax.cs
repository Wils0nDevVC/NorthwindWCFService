using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace NorthwindWCFService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Crear una instancia de ServiceHost para el servicio
            var host = new ServiceHost(typeof(NorthwindWCFService.CustomerService));

            // Agregar el comportamiento de CORS a cada endpoint
            foreach (var endpoint in host.Description.Endpoints)
            {
                endpoint.Behaviors.Add(new CustomCorsBehavior());
            }

            // Abrir el host para que acepte solicitudes
            try
            {
                host.Open();
                Console.WriteLine("El servicio está corriendo en: " + host.BaseAddresses[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al iniciar el servicio: " + ex.Message);
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            // Código para cerrar el host si es necesario
        }
    }
}