using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.ParkingLotServices
{
    public interface IVehicleService
    {
        void GetVehicleType();
        bool IsValidVehicle(String vehicleNumber);
        bool CanVehicleEnter();
    }
}
