using ParkingLot.ParkingLotModels;
using ParkingLot.ParkingLotModels.Enums;
using ParkingLot.ParkingLotServices.Extensions;


namespace ParkingLot.ParkingLotServices
{
    public class ParkingService : IParkingService
    {
        private ParkingSlots parkingSlots;
        public ParkingService(ParkingSlots slots)
        {
            this.parkingSlots = slots;
        }

        private void SetSlots(int TwoWheelerSlots, int FourWheelerSlots, int HeavyVehicleSlots)
        {
            Vehicle vehicle = new Vehicle();

            parkingSlots.TwoWheelerSlots = TwoWheelerSlots;
            parkingSlots.FourWheelerSlots = FourWheelerSlots;
            parkingSlots.HeavyVehicleSlots = HeavyVehicleSlots;
            int TotalSlots = TwoWheelerSlots + FourWheelerSlots + HeavyVehicleSlots ;

            parkingSlots.TwoWheelerSlotsAvailable = Enumerable.Range(0,TwoWheelerSlots).Select(n => true).ToList();
            parkingSlots.FourWheelerSlotsAvailable = Enumerable.Range(0,FourWheelerSlots).Select(n => true).ToList();
            parkingSlots.HeavyVehicleSlotsAvailabe = Enumerable.Range(0,HeavyVehicleSlots).Select(n => true).ToList();
            parkingSlots.Vehicles = Enumerable.Range(0,TotalSlots).Select(n => vehicle).ToList();

        }

        public void Initializer()
        {
            try
            {
                ParkingService setSlots = new ParkingService(parkingSlots);
                Console.WriteLine("Enter number of two wheeler slots");
                int TwoWheelerSlots = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter number of four wheeler slots");
                int FourWheelerSlots = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter number of heavy vehicle slots");
                int HeavyVehicleSlots = Convert.ToInt32(Console.ReadLine());

                setSlots.SetSlots(TwoWheelerSlots, FourWheelerSlots, HeavyVehicleSlots);
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid integer");
                Initializer();
            }
        }

        public int ExitEntry()
        {
            Console.WriteLine("Choose a option");
            Console.WriteLine("1. Entry");
            Console.WriteLine("2. Exit");
            Console.WriteLine("3. Hold");
            int vehicleStatus = Convert.ToInt32(Console.ReadLine());

            if (vehicleStatus == VehicleStatus.Entry.GetIndex() || vehicleStatus == VehicleStatus.Exit.GetIndex() || vehicleStatus == VehicleStatus.Hold.GetIndex())
            {
                return vehicleStatus;
            }
            else
            {
                Console.WriteLine("Choose the correct option");
                ExitEntry();
            }
            return 0;
        }

        public void Exit()
        {
            VehicleService vehicleService = new VehicleService(parkingSlots);
            Console.WriteLine("Enter a valid Vehicle Number");
            string vehicleNumber = Console.ReadLine()!;
            if (!vehicleService.IsValidVehicle(vehicleNumber!))
            {
                Exit();
                return;
            }
            Console.WriteLine("Enter a valid slot Number");
            int slot = Convert.ToInt32(Console.ReadLine());
            if (parkingSlots.Vehicles[slot-1].number != vehicleNumber)
            {
                Console.WriteLine("Enter the correct vehicle and slot number");
                Exit();
                return;
            }
            if(slot < parkingSlots.TwoWheelerSlots)
            {
                parkingSlots.TwoWheelerSlotsAvailable[slot-1] = true;
                Console.WriteLine(slot);
            }
            else if (slot < parkingSlots.FourWheelerSlots)
            {
                parkingSlots.FourWheelerSlotsAvailable[slot-parkingSlots.TwoWheelerSlots-1] = true;
            }
            else if (slot < parkingSlots.HeavyVehicleSlots)
            {
                parkingSlots.HeavyVehicleSlotsAvailabe[slot-parkingSlots.TwoWheelerSlots-parkingSlots.FourWheelerSlots-1] = true;
            }

            string outTime = DateTime.Now.Tohhmmsstt();
            parkingSlots.Vehicles[slot-1].outTime = outTime;
            Console.WriteLine("Vehicle has been exited");
            Console.WriteLine("Vehicle Number" + parkingSlots.Vehicles[slot - 1].number);
            Console.WriteLine("Vehicle In Time" + parkingSlots.Vehicles[slot - 1].inTime);
            Console.WriteLine("Vehicle Out Time" + parkingSlots.Vehicles[slot - 1].outTime);
        }
    }
}
