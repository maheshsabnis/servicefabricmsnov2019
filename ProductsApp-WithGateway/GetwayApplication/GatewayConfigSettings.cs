using System;
using System.Collections.Generic;
using System.Fabric;
using System.Fabric.Description;
using System.Linq;
using System.Threading.Tasks;

namespace GetwayApplication
{
    public class GatewayConfigSettings
    {
        public string ProductServiceName { get; set; }
        public string CategoryServiceName { get; set; }
        public int ReverseProxyEndPointPort { get; set; }
        public GatewayConfigSettings(StatelessServiceContext serviceContext)
        {
            serviceContext.CodePackageActivationContext.ConfigurationPackageModifiedEvent += CodePackageActivationContext_ConfigurationPackageModifiedEvent;
            UpdateGatewayConfiguration(serviceContext.CodePackageActivationContext.GetConfigurationPackageObject("Config").Settings);
        }

        private void CodePackageActivationContext_ConfigurationPackageModifiedEvent(object sender, PackageModifiedEventArgs<ConfigurationPackage> e)
        {
            UpdateGatewayConfiguration(e.NewPackage.Settings);
        }

        private void UpdateGatewayConfiguration(ConfigurationSettings configuration)
        {
            ConfigurationSection section = configuration.Sections["MyGatewatConfig"];
            ProductServiceName = section.Parameters["ProductsServiceName"].Value;
            CategoryServiceName = section.Parameters["CategoryServiceName"].Value;
            ReverseProxyEndPointPort = Convert.ToInt32(section.Parameters["ReverseProxyEndPointPort"].Value);
        }
    }
}
