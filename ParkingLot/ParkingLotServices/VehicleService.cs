using ParkingLot.ParkingLotModels;
using ParkingLot.ParkingLotModels.Enums;
using ParkingLot.ParkingLotServices.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParkingLot.ParkingLotServices
{
    public class VehicleService : IVehicleService
    {
        private ParkingSlots parkingSlots;
        public VehicleService(ParkingSlots parkingSlots)
        {
            this.parkingSlots = parkingSlots;
        }

        public void GetVehicleType()
        {
            try
            {
                Console.WriteLine("Enter Vehicle Type");
                Console.WriteLine("1. Two Wheeler");
                Console.WriteLine("2. Four Wheeler");
                Console.WriteLine("3. Heavy Vehicle");

                int TypeofVehicle = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                parkingSlots.TypeofVehicle = TypeofVehicle;
            }
            catch(Exception) 
            {
                Console.WriteLine(" Enter a valid option!");
                GetVehicleType();
            }
        }

        public bool IsValidVehicle(String vehicleNumber)
        {
            string pattern1 = @"[A-Z]{2} [0-9]{2} [A-Z]{2} [0-9]{4}$";
            string pattern2 = @"[A-Z]{2} [0-9]{2} [A-Z]{1} [0-9]{4}$";

            Regex regex1 = new Regex(pattern1);
            Regex regex2 = new Regex(pattern2);
            if (regex1.IsMatch(vehicleNumber) || regex2.IsMatch(vehicleNumber))
            {
                return true;
            }
            return false;
        }

        public bool CanVehicleEnter()
        {
            bool isAvailable = false;
            int availableSlots = 100;    
            
            if (parkingSlots.TypeofVehicle == VehicleType.TwoWheeler.GetIndex())
            {
                int slot = parkingSlots.TwoWheelerSlotsAvailable.IndexOf(true);
                if (slot >= 0)
                {
                    parkingSlots.TwoWheelerSlotsAvailable[slot] = false;
                    isAvailable = true;
                    availableSlots = slot + 1;
                }
            }

            else if (parkingSlots.TypeofVehicle == VehicleType.FourWheeler.GetIndex())
            {
                int slot = parkingSlots.FourWheelerSlotsAvailable.IndexOf(true);
                if (slot >= 0)
                {
                    parkingSlots.FourWheelerSlotsAvailable[slot] = false;
                    isAvailable = true;
                    availableSlots = slot + parkingSlots.TwoWheelerSlots + 1;
                }
            }

            else if(parkingSlots.TypeofVehicle == VehicleType.HeavyVehicle.GetIndex())
            {
                int slot = parkingSlots.HeavyVehicleSlotsAvailabe.IndexOf(true);
                if(slot >= 0)
                {
                    parkingSlots.HeavyVehicleSlotsAvailabe.IndexOf(true);
                    isAvailable= true;
                    availableSlots = parkingSlots.TwoWheelerSlots + parkingSlots.FourWheelerSlots + slot + 1;
                }
            }

            if (isAvailable)
            {
                GenerateTicket(availableSlots);
                return true;
            }
            Console.WriteLine("Sorry, No Slots Available!");
            Console.WriteLine();
            return false;
        }

        private void GenerateTicket(int availableSlots)
        {
            Vehicle newVehicle = new Vehicle();
            Console.WriteLine("Enter a Vehicle Number");
            string? vehicleNumber = Console.ReadLine();
            if (IsValidVehicle(vehicleNumber))
            {
                newVehicle.number = vehicleNumber;
            }
            else
            {
                GenerateTicket(availableSlots);
                return;
            }
            newVehicle.type = parkingSlots.TypeofVehicle;
            newVehicle.slot = availableSlots;
            newVehicle.inTime = DateTime.Now.Tohhmmsstt();
            parkingSlots.Vehicles[availableSlots-1] = newVehicle;
            Console.WriteLine("Your slot is confirmed");
            Console.WriteLine("Slot :"+ availableSlots);
            Console.WriteLine("Your In Time is"+ newVehicle.inTime.ToString());
        }
    }
}

