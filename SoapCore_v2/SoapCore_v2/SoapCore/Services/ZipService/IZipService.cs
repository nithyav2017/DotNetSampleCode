using Services.DataContract;
using System.Collections.Generic;
using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface IZipService
    {
        [OperationContract]
        ZipCodeModel GetZipInfo(string zip);
        IEnumerable<ZipCodeModel> GetZips(string state);
       
    }
}