using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.ParkingLotModels
{
    public class Vehicle
    {
        public string? number;
        public int type;
        public int slot;
        public string? inTime;
        public string? outTime;
    }
    public class ParkingSlots
    {
        public int TwoWheelerSlots { get; set; }
        public int FourWheelerSlots { get; set;  }
        public int HeavyVehicleSlots { get;set; }
        public int TypeofVehicle { get; set; }

        public List<bool> TwoWheelerSlotsAvailable = new List<bool>();
        public List<bool> FourWheelerSlotsAvailable = new List<bool>();
        public List<bool> HeavyVehicleSlotsAvailabe = new List<bool>();
        public List<Vehicle> Vehicles = new List<Vehicle>();
    }
}

