using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rosies_pie_shared.Services
{
    public interface IQrScanningServices
    {
        Task<string> ScanAsync();

    }
}
