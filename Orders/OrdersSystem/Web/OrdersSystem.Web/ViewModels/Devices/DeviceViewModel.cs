namespace OrdersSystem.Web.ViewModels.Devices
{
    using Infrastructure.Mapping;
    using Models;

    public class DeviceViewModel : IMapFrom<Device>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }
    }
}