#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CitasMantenimiento.Data;
using CitasMantenimiento.Data.Entities;
using CitasMantenimiento.Models;
using CitasMantenimiento.Helpers;

namespace CitasMantenimiento.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public VehiclesController(DataContext context, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicles
                .Include(a=>a.Appointments)
                .ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View(new Vehicle());
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(vehicle);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "La placa ya existe.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }

        public async Task<IActionResult> DetailsVehicle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehicle vehicle = await _context.Vehicles
                .Include(d => d.Appointments)
                .ThenInclude(d => d.AppointmentTime)
                .Include(d => d.Appointments)
                .ThenInclude(d => d.statusVehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        public async Task<IActionResult> AddAppointment(int? id)
        {
            Vehicle vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            AppointmentViewModel model = new()
            {
                AppointmentTimes = _combosHelper.GetComboAppointmentTimes(),
                StatusVehicles = _combosHelper.GetComboStatusVehicle(),
                VehicleId = vehicle.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAppointment(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Appointment appointment = new()
                     {
                        Vehicle= await _context.Vehicles.FindAsync(model.VehicleId),
                        Date = model.Date,
                        AppointmentTime = await _context.AppointmentTimes.FindAsync(model.AppointmentTimeId),
                        statusVehicle = await _context.StatusVehicles.FindAsync(model.StatusVehicleId),
                    };
                     _context.Add(appointment);
                     await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsVehicle)}", new { Id = model.VehicleId });
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            model.AppointmentTimes = _combosHelper.GetComboAppointmentTimes();
            model.StatusVehicles = _combosHelper.GetComboStatusVehicle();
            return View(model);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> DeleteAppointment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointent = await _context.Appointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointent == null)
            {
                return NotFound();
            }

            return View(appointent);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointent = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
