namespace OrdersSystem.Services
{
    using System.Linq;
    using Data.Repository;
    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Models;
    using System;

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

        public Device Update(int id, Device device)
        {
            var deviceToUpdate = this.devices.All().FirstOrDefault(x => x.Id == id);
            deviceToUpdate.Name = device.Name;
            deviceToUpdate.CategoryId = device.CategoryId;
            this.devices.SaveChanges();

            return deviceToUpdate;
        }

        public void Delete(int id)
        {
            this.devices.Delete(id);
            this.devices.SaveChanges();
        }
    }
}
