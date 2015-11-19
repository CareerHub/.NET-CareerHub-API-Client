using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.Framework.API {
    public interface IApiFactory {
        T GetApi<T>();
    }
}
