using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLibrary;

namespace CommonUILibrary.Models
{
    public interface IUsedLibraryPresenter
    {
        IEnumerable<CopyrightData> CopyrightDataList { get; }

        Task ReadAsync();

        void OpenLicence(string path);
    }
}
