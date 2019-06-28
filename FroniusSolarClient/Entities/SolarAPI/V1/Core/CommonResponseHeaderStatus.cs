using System;
using System.Collections.Generic;
using System.Text;

namespace FroniusSolarClient.Entities.SolarAPI.V1
{
    public class CommonResponseHeaderStatus
    {
        /// <summary>
        /// Indicates if the request went OK or gives a hint about what went wrong.
        /// 0 means OK, any other value means something went wrong (e.g. Device not available, 
        /// invalid params, no data in logflash for given time. 
        /// </summary>
        /// TODO: Implement Error Code Enum
        public int Code { get; set; }

        /// <summary>
        /// Error message, may be empty. 
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        ///  Error message to be displayed to the user, may be empty. 
        /// </summary>
        public string UserMessage { get; set; }

    }
}