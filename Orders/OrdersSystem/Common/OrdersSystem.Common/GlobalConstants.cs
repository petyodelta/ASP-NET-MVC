namespace OrdersSystem.Common
{
    public class GlobalConstants
    {
        public const string AdministratorRoleName = "Admin";
        public const string WorkerRoleName = "Worker";
        public const string BossRoleName = "Boss";

        public const string InOrderCreateNotify = "Incoming order created";
        public const string InOrderUpdateNotify = "Incoming order updated";

        public const string OutOrderCreateNotify = "Outgoing order created";
        public const string OutOrderUpdateNotify = "Outgoing order updated";

        public const string RepairOrderCreateNotify = "Repair order created";
        public const string RepairOrderUpdateNotify = "Repair order updated";

        public const string DeviceAddNotify = "Device added";
        public const string DeviceUpdateNotify = "Device updated";
        public const string DeviceDeletedNotify = "Device deleted";

        public const string CategoryUpdateNotify = "Category updated";
        public const string CategoryAddNotify = "Category added";
        public const string CategoryExistsNotify = "Category already exists";
        public const string CategoryDeletedNotify = "Category deleted";
    }
}
