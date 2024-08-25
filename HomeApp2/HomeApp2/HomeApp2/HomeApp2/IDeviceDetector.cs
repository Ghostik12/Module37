using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp2
{
    public interface IDeviceDetector
    {
        /// <summary>
        /// Получение информации об устройстве
        /// </summary>
        string GetDevice();
    }
}
