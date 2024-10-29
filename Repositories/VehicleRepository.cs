using Microsoft.EntityFrameworkCore;
using WebAplicacion.Abstractions;
using WebAplicacion.Context;
using WebAplicacion.Model;

namespace WebAplicacion.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly TestDbContext _context;

        public VehicleRepository(TestDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }
        public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }
        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task DeleteVehicleAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
        {
            var existingvehicle = await _context.Vehicles.FindAsync(vehicle.Id);

            if (existingvehicle == null)
            {
                throw new NotFoundException("Vehicle not found");
            }

            // Actualiza las propiedades según sea necesario
            existingvehicle.Brand = vehicle.Brand;
            existingvehicle.Model = vehicle.Model;
            existingvehicle.Year = vehicle.Year;
            existingvehicle.Plate = vehicle.Plate;

            _context.Entry(existingvehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingvehicle;
        }
    }
}
