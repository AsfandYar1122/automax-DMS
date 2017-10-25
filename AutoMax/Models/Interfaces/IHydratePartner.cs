using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Interfaces
{
    interface IHydratePartner
    {
        void ValidateAllDependenciesPresent();

        /// <summary>
        /// Adapts Automax data to specific partner website form requirement
        /// </summary>
        void AdaptData();

        /// <summary>
        /// Creates Request, initializes headers, hydrates data to form, submits, waits for response. 
        /// </summary>
        void TriggerSerialization();

    }
}
