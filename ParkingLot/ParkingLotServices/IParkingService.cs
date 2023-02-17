using ParkingLot.ParkingLotModels.Enums;
using ParkingLot.ParkingLotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.ParkingLotServices
{
    public interface IParkingService
    {
        void Initializer();
        int ExitEntry();
        void Exit();

    }
}
