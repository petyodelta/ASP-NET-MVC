using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersSystem.Common
{
    public class ValidationConstants
    {
        public const string DiviceDisplayName = "Device Name";
        public const string CustomerDisplayName = "Customer Name";
        public const string WorkerDisplayName = "Worker Name";
        public const string EndDateDisplayName = "End Date";
        public const string SupplierDisplayName = "Supplier Name";
        public const string DeviceCountDisplayName = "Device Count";
        public const string CategoryDisplayName = "Category";

        public const string DescriptionErrorMessage = "Description name must be between 3 and 2000 symbols";
        public const string DeviceCountErrorMessage = "Device count must be greater than 0";
    }
}
