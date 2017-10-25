using AutoMax.Models;
using AutoMax.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Repository.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// The context
        /// </summary>
        private AutoMaxContext context = new AutoMaxContext();

        /// <summary>
        /// The vehclie title repository
        /// </summary>

        private GenericRepository<AutoBodyStyle> _autoBodyStyleRepository;
        private GenericRepository<AutoCondition> _autoConditionRepository;
        private GenericRepository<AutoDoor> _autoDoorRepository;
        private GenericRepository<AutoEngine> _autoEngineRepository;
        private GenericRepository<AutoExteriorColor> _autoExteriorColorRepository;
        private GenericRepository<AutoGlobalization> _autoGlobalizationRepository;
        private GenericRepository<AutoInteriorColor> _autoInteriorColorRepository;
        private GenericRepository<AutoSteering> _autoSteeringRepository;
        private GenericRepository<AutoTransmission> _autoTransmissionRepository;
        private GenericRepository<DriveType> _driveTypeRepository;
        private GenericRepository<FuelType> _fuelTypeRepository;
        private GenericRepository<InventoryStatus> _inventoryStatusRepository;
        private GenericRepository<Maker> _makerRepository;
        private GenericRepository<MotorizedType> _motorizedTypeRepository;
        private GenericRepository<User> _userRepository;
        private GenericRepository<VehclieTitle> _vehclieTitleRepository;
        private GenericRepository<VehicleImage> _vehicleImageRepository;
        private GenericRepository<VehiclePrice> _vehiclePriceRepository;
        private GenericRepository<VehicleTemplate> _vehicleTemplateRepository;
        private GenericRepository<SubModel> _vehicleTrimRepository;
        private GenericRepository<VehicleType> _vehicleTypeRepository;
        private GenericRepository<VehicleWizard> _vehicleWizardRepository;
        private GenericRepository<Year> _yearRepository;

        public GenericRepository<AutoBodyStyle> AutoBodyStyleRepository
        {
            get
            {
                if (this._autoBodyStyleRepository == null)
                {
                    this._autoBodyStyleRepository = new GenericRepository<AutoBodyStyle>(context);
                }
                return _autoBodyStyleRepository;
            }
        }
        public GenericRepository<AutoCondition> AutoConditionRepository
        {
            get
            {
                if (this._autoConditionRepository == null)
                {
                    this._autoConditionRepository = new GenericRepository<AutoCondition>(context);
                }
                return _autoConditionRepository;
            }
        }
        public GenericRepository<AutoDoor> AutoDoorRepository
        {
            get
            {
                if (this._autoDoorRepository == null)
                {
                    this._autoDoorRepository = new GenericRepository<AutoDoor>(context);
                }
                return _autoDoorRepository;
            }
        }
        public GenericRepository<AutoEngine> AutoEngineRepository
        {
            get
            {
                if (this._autoEngineRepository == null)
                {
                    this._autoEngineRepository = new GenericRepository<AutoEngine>(context);
                }
                return _autoEngineRepository;
            }
        }
        public GenericRepository<AutoExteriorColor> AutoExteriorColorRepository
        {
            get
            {
                if (this._autoExteriorColorRepository == null)
                {
                    this._autoExteriorColorRepository = new GenericRepository<AutoExteriorColor>(context);
                }
                return _autoExteriorColorRepository;
            }
        }
        public GenericRepository<AutoGlobalization> AutoGlobalizationRepository
        {
            get
            {
                if (this._autoGlobalizationRepository == null)
                {
                    this._autoGlobalizationRepository = new GenericRepository<AutoGlobalization>(context);
                }
                return _autoGlobalizationRepository;
            }
        }
        public GenericRepository<AutoInteriorColor> AutoInteriorColorRepository
        {
            get
            {
                if (this._autoInteriorColorRepository == null)
                {
                    this._autoInteriorColorRepository = new GenericRepository<AutoInteriorColor>(context);
                }
                return _autoInteriorColorRepository;
            }
        }
        public GenericRepository<AutoSteering> AutoSteeringRepository
        {
            get
            {
                if (this._autoSteeringRepository == null)
                {
                    this._autoSteeringRepository = new GenericRepository<AutoSteering>(context);
                }
                return _autoSteeringRepository;
            }
        }
        public GenericRepository<AutoTransmission> AutoTransmissionRepository
        {
            get
            {
                if (this._autoTransmissionRepository == null)
                {
                    this._autoTransmissionRepository = new GenericRepository<AutoTransmission>(context);
                }
                return _autoTransmissionRepository;
            }
        }
        public GenericRepository<DriveType> DriveTypeRepository
        {
            get
            {
                if (this._driveTypeRepository == null)
                {
                    this._driveTypeRepository = new GenericRepository<DriveType>(context);
                }
                return _driveTypeRepository;
            }
        }
        public GenericRepository<FuelType> FuelTypeRepository
        {
            get
            {
                if (this._fuelTypeRepository == null)
                {
                    this._fuelTypeRepository = new GenericRepository<FuelType>(context);
                }
                return _fuelTypeRepository;
            }
        }
        public GenericRepository<InventoryStatus> InventoryStatusRepository
        {
            get
            {
                if (this._inventoryStatusRepository == null)
                {
                    this._inventoryStatusRepository = new GenericRepository<InventoryStatus>(context);
                }
                return _inventoryStatusRepository;
            }
        }
        public GenericRepository<Maker> MakerRepository
        {
            get
            {
                if (this._makerRepository == null)
                {
                    this._makerRepository = new GenericRepository<Maker>(context);
                }
                return _makerRepository;
            }
        }
        public GenericRepository<MotorizedType> MotorizedTypeRepository
        {
            get
            {
                if (this._motorizedTypeRepository == null)
                {
                    this._motorizedTypeRepository = new GenericRepository<MotorizedType>(context);
                }
                return _motorizedTypeRepository;
            }
        }
        /// <summary>
        /// Gets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<User>(context);
                }
                return _userRepository;
            }
        }
        /// <summary>
        /// Gets the vehclie title repository.
        /// </summary>
        /// <value>
        /// The vehclie title repository.
        /// </value>
        public GenericRepository<VehclieTitle> VehclieTitleRepository
        {
            get
            {
                if (this._vehclieTitleRepository == null)
                {
                    this._vehclieTitleRepository = new GenericRepository<VehclieTitle>(context);
                }
                return _vehclieTitleRepository;
            }
        }
        public GenericRepository<VehicleImage> VehicleImageRepository
        {
            get
            {
                if (this._vehicleImageRepository == null)
                {
                    this._vehicleImageRepository = new GenericRepository<VehicleImage>(context);
                }
                return _vehicleImageRepository;
            }
        }
        public GenericRepository<VehiclePrice> VehiclePriceRepository
        {
            get
            {
                if (this._vehiclePriceRepository == null)
                {
                    this._vehiclePriceRepository = new GenericRepository<VehiclePrice>(context);
                }
                return _vehiclePriceRepository;
            }
        }
        public GenericRepository<VehicleTemplate> VehicleTemplateRepository
        {
            get
            {
                if (this._vehicleTemplateRepository == null)
                {
                    this._vehicleTemplateRepository = new GenericRepository<VehicleTemplate>(context);
                }
                return _vehicleTemplateRepository;
            }
        }
        public GenericRepository<SubModel> VehicleTrimRepository
        {
            get
            {
                if (this._vehicleTrimRepository == null)
                {
                    this._vehicleTrimRepository = new GenericRepository<SubModel>(context);
                }
                return _vehicleTrimRepository;
            }
        }
        public GenericRepository<VehicleType> VehicleTypeRepository
        {
            get
            {
                if (this._vehicleTypeRepository == null)
                {
                    this._vehicleTypeRepository = new GenericRepository<VehicleType>(context);
                }
                return _vehicleTypeRepository;
            }
        }
        public GenericRepository<VehicleWizard> VehicleWizardRepository
        {
            get
            {
                if (this._vehicleWizardRepository == null)
                {
                    this._vehicleWizardRepository = new GenericRepository<VehicleWizard>(context);
                }
                return _vehicleWizardRepository;
            }
        }
        public GenericRepository<Year> YearRepository
        {
            get
            {
                if (this._yearRepository == null)
                {
                    this._yearRepository = new GenericRepository<Year>(context);
                }
                return _yearRepository;
            }
        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
