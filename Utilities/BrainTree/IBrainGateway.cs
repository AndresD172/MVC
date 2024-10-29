using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.BrainTree
{
    internal interface IBrainGateway
    {
        IBraintreeGateway CreateGateway();
        IBraintreeGateway GetGateway();
    }
}
