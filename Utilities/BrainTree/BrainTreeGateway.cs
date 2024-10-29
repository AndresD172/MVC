using Braintree;
using Microsoft.Extensions.Options;

namespace Utilities.BrainTree
{
    public class BrainTreeGateway : IBrainGateway
    {
        private BrainTreeInfo _sessionInfo { get; set; }
        private IBraintreeGateway _gateway { get; set; }

        public BrainTreeGateway(IOptions<BrainTreeInfo> options)
        {
            _sessionInfo = options.Value;
        }

        public IBraintreeGateway CreateGateway()
        {
            _gateway = new BraintreeGateway(_sessionInfo.Environment, _sessionInfo.MerchantId, _sessionInfo.PublicKey, _sessionInfo.PrivateKey);
            return _gateway;
        }


    }
}
