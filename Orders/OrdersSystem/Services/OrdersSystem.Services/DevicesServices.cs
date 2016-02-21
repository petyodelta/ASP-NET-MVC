namespace OrdersSystem.Services
{
    using System.Linq;
    using Data.Repository;
    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Models;

    public class DevicesServices : IDevicesServices
    {
        private IRepository<Device> devices;

        public DevicesServices(IRepository<Device> devices)
        {
            this.devices = devices;
        }

        public IQueryable<Device> GetAll()
        {
            return this.devices.All().OrderBy(x => x.Name);
        }

        public Device Add(Device device)
        {
            this.devices.Add(device);
            this.devices.SaveChanges();

            return device;
        }
    }
}
