using System;
using ParkingLot.ParkingLotModels;
using ParkingLot.ParkingLotModels.Enums;
using ParkingLot.ParkingLotServices;
using ParkingLot.ParkingLotServices.Extensions;

namespace ParkingLot
{
    class ParkingSpace
    {
        public static void Main(string[] args)
        {
            ParkingSlots parkingSlots = new ParkingSlots();
            MainService parking = new MainService(new ParkingService(parkingSlots), new VehicleService(parkingSlots));

            parking.Initializer();

            bool stop = false;

            while(!stop)
            {
                int vehicleStatus = parking.ExitEntry();
                if (vehicleStatus == VehicleStatus.Entry.GetIndex()) 
                {
                    parking.GetVehicleType();
                    parking.CanVehicleEnter();
                    
                }
                else if (vehicleStatus == VehicleStatus.Exit.GetIndex())
                {
                    parking.Exit();
                }
                else if(vehicleStatus == VehicleStatus.Hold.GetIndex())
                {
                    stop = true;
                }
            }
        }
    }
}
